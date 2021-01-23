using System;
using System.Text;
using System.IO;
using System.Net;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Globalization;
using System.Collections.Generic;
using Clam.Models;
using Clam.Filters;
using Clam.Utilities;
using ClamDataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using ClamDataLibrary.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace Clam.Controllers
{
    public class StreamController : Controller
    {
        // Database Single File upload test Cases
        private readonly StreamFileUploadDatabase _uploadFile;
        private readonly StreamFileData _uploadContent;

        // Private readonly IFileProvider _fileProvider;
        private readonly ClamUserAccountContext _context;
        private readonly long _fileSizeLimit;
        private readonly ILogger<StreamController> _logger;
        private readonly string[] _permittedExtentions = { ".txt", ".png", ".jpeg", ".jpg", ".mkv", ".flv", ".mp4" };
        private readonly string _targetFilePath;
        private readonly IFileProvider _fileProvider;

        // Get the default form options so that we can use them to set the default
        // limits for request body data.
        private static readonly FormOptions _defaultFormOptions = new FormOptions();

        public StreamController(ClamUserAccountContext context, IConfiguration config, StreamFileUploadDatabase uploadFile,
            StreamFileData uploadContent, ILogger<StreamController> logger, IFileProvider fileProvider)
        {
            //_fileProvider = fileProvider;
            _uploadFile = uploadFile;
            _uploadContent = uploadContent;
            _context = context;
            _logger = logger;
            _fileProvider = fileProvider;

            // Physical Provider
            _targetFilePath = config.GetValue<string>("AcademiaStoredFilesC");

            _fileSizeLimit = config.GetValue<long>("FileSizeLimit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequestSizeLimit(4294967295)]
        public async Task<IActionResult> Create(StreamFileUploadDatabase model)
        {
            // Perform an initial check to catch FileUpload class
            // attribute violations.
            if (!ModelState.IsValid)
            {
                _uploadContent.Result = "Please correct the form.";

                return View();
            }

            var formFileContent =
                await FileHelpers.ProcessFormFile<StreamFileUploadDatabase>(
                    model.FormFile, ModelState, _permittedExtentions,
                    _fileSizeLimit);

            // Perform a second check to catch ProcessFormFile method
            // violations. If any validation check fails, return to the
            // page.
            if (!ModelState.IsValid)
            {
                _uploadContent.Result = "Please correct the form.";

                return View();
            }

            // **WARNING!**
            // In the following example, the file is saved without
            // scanning the file's contents. In most production
            // scenarios, an anti-virus/anti-malware scanner API
            // is used on the file before making the file available
            // for download or for use by other systems. 
            // For more information, see the topic that accompanies 
            // this sample.

            var file = new ClamSectionAcademicSubCategoryItem
            {
                ItemPath = null,
                ItemTitle = model.FormFile.FileName,
                ItemDescription = model.Note,
                Size = model.FormFile.Length,
                SubCategoryId = new Guid("8d7af8fa-4659-4aef-1746-08d7d7789232")
                //AcademicId = new Guid("a7e95d01-3a1c-474c-d5ab-08d7d76073f2")
            };

            _context.Set<ClamSectionAcademicSubCategoryItem>().Add(file);
            //_context.Entry(file).State = EntityState.Modified;
            _context.SaveChanges();
            //await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        #region snippet_UploadDatabase
        [HttpPost]
        [DisableFormValueModelBinding]
        [ValidateAntiForgeryToken]
        [RequestSizeLimit(4294967295)]
        public async Task<IActionResult> UploadDatabase()
        {
            if (!MultipartRequestHelper.IsMultipartContentType(Request.ContentType))
            {
                ModelState.AddModelError("File",
                    $"The request couldn't be processed (Error 1).");
                // Log error

                return BadRequest(ModelState);
            }

            // Accumulate the form data key-value pairs in the request (formAccumulator).
            var formAccumulator = new KeyValueAccumulator();
            var trustedFileNameForDisplay = string.Empty;
            var untrustedFileNameForStorage = string.Empty;
            var streamedFileContent = new byte[0];

            var boundary = MultipartRequestHelper.GetBoundary(
                MediaTypeHeaderValue.Parse(Request.ContentType),
                _defaultFormOptions.MultipartBoundaryLengthLimit);
            var reader = new MultipartReader(boundary, HttpContext.Request.Body);

            var section = await reader.ReadNextSectionAsync();

            while (section != null)
            {
                var hasContentDispositionHeader =
                    ContentDispositionHeaderValue.TryParse(
                        section.ContentDisposition, out var contentDisposition);

                if (hasContentDispositionHeader)
                {
                    if (MultipartRequestHelper
                        .HasFileContentDisposition(contentDisposition))
                    {
                        untrustedFileNameForStorage = contentDisposition.FileName.Value;
                        // Don't trust the file name sent by the client. To display
                        // the file name, HTML-encode the value.
                        trustedFileNameForDisplay = WebUtility.HtmlEncode(
                                contentDisposition.FileName.Value);

                        streamedFileContent =
                            await FileHelpers.ProcessStreamedFile(section, contentDisposition,
                                ModelState, _permittedExtentions, _fileSizeLimit);

                        if (!ModelState.IsValid)
                        {
                            return BadRequest(ModelState);
                        }
                    }
                    else if (MultipartRequestHelper
                        .HasFormDataContentDisposition(contentDisposition))
                    {
                        // Don't limit the key name length because the 
                        // multipart headers length limit is already in effect.
                        var key = HeaderUtilities
                            .RemoveQuotes(contentDisposition.Name).Value;
                        var encoding = GetEncoding(section);

                        if (encoding == null)
                        {
                            ModelState.AddModelError("File",
                                $"The request couldn't be processed (Error 2).");
                            // Log error

                            return BadRequest(ModelState);
                        }

                        using (var streamReader = new StreamReader(
                            section.Body,
                            encoding,
                            detectEncodingFromByteOrderMarks: true,
                            bufferSize: 1024,
                            leaveOpen: true))
                        {
                            // The value length limit is enforced by 
                            // MultipartBodyLengthLimit
                            var value = await streamReader.ReadToEndAsync();

                            if (string.Equals(value, "undefined",
                                StringComparison.OrdinalIgnoreCase))
                            {
                                value = string.Empty;
                            }

                            formAccumulator.Append(key, value);

                            if (formAccumulator.ValueCount >
                                _defaultFormOptions.ValueCountLimit)
                            {
                                // Form key count limit of 
                                // _defaultFormOptions.ValueCountLimit 
                                // is exceeded.
                                ModelState.AddModelError("File",
                                    $"The request couldn't be processed (Error 3).");
                                // Log error

                                return BadRequest(ModelState);
                            }
                        }
                    }
                }

                // Drain any remaining section body that hasn't been consumed and
                // read the headers for the next section.
                section = await reader.ReadNextSectionAsync();
            }

            // Bind form data to the model
            var formData = new FormData();
            var formValueProvider = new FormValueProvider(
                BindingSource.Form,
                new FormCollection(formAccumulator.GetResults()),
                CultureInfo.CurrentCulture);
            var bindingSuccessful = await TryUpdateModelAsync(formData, prefix: "",
                valueProvider: formValueProvider);

            if (!bindingSuccessful)
            {
                ModelState.AddModelError("File",
                    "The request couldn't be processed (Error 5).");
                // Log error

                return BadRequest(ModelState);
            }

            // **WARNING!**
            // In the following example, the file is saved without
            // scanning the file's contents. In most production
            // scenarios, an anti-virus/anti-malware scanner API
            // is used on the file before making the file available
            // for download or for use by other systems. 
            // For more information, see the topic that accompanies 
            // this sample app.

            var file = new ClamSectionAcademicSubCategoryItem()
            {
                ItemPath = null,
                ItemTitle = untrustedFileNameForStorage,
                ItemDescription = formData.Note,
                Size = streamedFileContent.Length,
                DateAdded = DateTime.Now,
                SubCategoryId = new Guid("8d7af8fa-4659-4aef-1746-08d7d7789232")
            };

            _context.Add(file);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region snippet_UploadPhysical
        [HttpPost]
        [DisableFormValueModelBinding]
        [ValidateAntiForgeryToken]
        [RequestSizeLimit(4294967295)]
        public async Task<IActionResult> UploadPhysical()
        {
            if (!MultipartRequestHelper.IsMultipartContentType(Request.ContentType))
            {
                ModelState.AddModelError("File",
                    $"The request couldn't be processed (Error 1).");
                // Log error

                return BadRequest(ModelState);
            }

            var boundary = MultipartRequestHelper.GetBoundary(
                MediaTypeHeaderValue.Parse(Request.ContentType),
                _defaultFormOptions.MultipartBoundaryLengthLimit);
            var reader = new MultipartReader(boundary, HttpContext.Request.Body);
            var section = await reader.ReadNextSectionAsync();
            //var token = await GetToken()

            while (section != null)
            {
                var hasContentDispositionHeader =
                    ContentDispositionHeaderValue.TryParse(
                        section.ContentDisposition, out var contentDisposition);

                if (hasContentDispositionHeader)
                {
                    // This check assumes that there's a file
                    // present without form data. If form data
                    // is present, this method immediately fails
                    // and returns the model error.
                    if (!MultipartRequestHelper
                        .HasFileContentDisposition(contentDisposition))
                    {
                        ModelState.AddModelError("File",
                            $"The request couldn't be processed (Error 2).");
                        // Log error

                        return BadRequest(ModelState);
                    }
                    else
                    {
                        // Don't trust the file name sent by the client. To display
                        // the file name, HTML-encode the value.
                        var trustedFileNameForDisplay = WebUtility.HtmlEncode(
                                contentDisposition.FileName.Value);
                        var trustedFileNameForFileStorage = Path.GetRandomFileName();
                        if (Directory.Exists(_targetFilePath))
                        {
                            string path = String.Format("{0}\\{1}\\{2}", _targetFilePath, Path.GetRandomFileName(), Path.GetRandomFileName());
                            Directory.CreateDirectory(path);
                        }
                        string test = String.Format("{0}\\{1}\\{2}", _targetFilePath, "Test", Path.GetRandomFileName());
                        DirectoryInfo di = Directory.CreateDirectory(test);

                        // **WARNING!**
                        // In the following example, the file is saved without
                        // scanning the file's contents. In most production
                        // scenarios, an anti-virus/anti-malware scanner API
                        // is used on the file before making the file available
                        // for download or for use by other systems. 
                        // For more information, see the topic that accompanies 
                        // this sample.

                        var streamedFileContent = await FileHelpers.ProcessStreamedFile(
                            section, contentDisposition, ModelState,
                            _permittedExtentions, _fileSizeLimit);

                        if (!ModelState.IsValid)
                        {
                            return BadRequest(ModelState);
                        }

                        using (var targetStream = System.IO.File.Create(
                            Path.Combine(_targetFilePath, trustedFileNameForDisplay)))
                        {
                            await targetStream.WriteAsync(streamedFileContent);

                            _logger.LogInformation(
                                "Uploaded file '{TrustedFileNameForDisplay}' saved to " +
                                "'{TargetFilePath}' as {TrustedFileNameForFileStorage}",
                                trustedFileNameForDisplay, _targetFilePath,
                                trustedFileNameForFileStorage);
                        }
                    }
                }

                // Drain any remaining section body that hasn't been consumed and
                // read the headers for the next section.
                section = await reader.ReadNextSectionAsync();
            }

            return RedirectToAction(nameof(Index));
        }
        #endregion

        public ActionResult DeletePhysical(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction(nameof(CreatePhysical));
            }
            var content = _fileProvider.GetFileInfo(id);
            if (content.Exists)
            {
                System.IO.File.Delete(content.PhysicalPath);
            }
            return RedirectToAction(nameof(CreatePhysical));

        }

        // GET: Stream
        public ActionResult Index()
        {
            var model = _context.Set<ClamSectionAcademicSubCategoryItem>().AsNoTracking().ToList();

            List<SectionItem> result = new List<SectionItem>();
            foreach (var item in model)
            {
                result.Add(new SectionItem()
                {
                    ItemId = item.ItemId,
                    ItemTitle = item.ItemTitle,
                    ItemDescription = item.ItemDescription,
                    LastModified = item.LastModified,
                    DateAdded = item.DateAdded,
                    ItemPath = item.ItemPath,
                    Size = item.Size
                });
            }
            StreamFileUploadDatabase test = new StreamFileUploadDatabase() { SectionItems = result };
            return View(test);
        }

        public ActionResult DownloadFile(Guid id)
        {
            var requestFile = _context.ClamSectionAcademicSubCategoryItems.SingleOrDefault(m => m.ItemId == id);
            if (requestFile == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return File(requestFile.ItemPath, MediaTypeNames.Application.Octet, WebUtility.HtmlEncode(requestFile.ItemTitle));
        }

        // GET: Stream/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Stream/Create
        public ActionResult Create()
        {
            var model = _context.Set<ClamSectionAcademicSubCategoryItem>().AsNoTracking().ToList();
            List<SectionItem> result = new List<SectionItem>();
            foreach (var item in model)
            {
                result.Add(new SectionItem()
                {
                    ItemId = item.ItemId,
                    ItemTitle = item.ItemTitle,
                    ItemDescription = item.ItemDescription,
                    LastModified = item.LastModified,
                    DateAdded = item.DateAdded,
                    ItemPath = item.ItemPath,
                    Size = item.Size
                });
            }
            StreamFileUploadDatabase test = new StreamFileUploadDatabase() { SectionItems = result };
            return View(test);
        }

        public ActionResult CreatePhysical()
        {
            var contents = _fileProvider.GetDirectoryContents(string.Empty);
            StreamFileUploadDatabase model = new StreamFileUploadDatabase() { PhysicalFiles = contents };
            return View(model);
        }

        public ActionResult IndexPhysical()
        {
            var contents = _fileProvider.GetDirectoryContents(string.Empty);
            StreamFileUploadDatabase model = new StreamFileUploadDatabase() { PhysicalFiles = contents };
            return View(model);
        }

        public ActionResult DownloadPhysical(string id)
        {
            var downloadFile = _fileProvider.GetFileInfo(id);
            return PhysicalFile(downloadFile.PhysicalPath, MediaTypeNames.Application.Octet, id);
        }


        // GET: Stream/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Stream/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Stream/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Stream/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private static Encoding GetEncoding(MultipartSection section)
        {
            var hasMediaTypeHeader =
                MediaTypeHeaderValue.TryParse(section.ContentType, out var mediaType);

            // UTF-7 is insecure and shouldn't be honored. UTF-8 succeeds in 
            // most cases.
            if (!hasMediaTypeHeader || Encoding.UTF7.Equals(mediaType.Encoding))
            {
                return Encoding.UTF8;
            }

            return mediaType.Encoding;
        }
    }
}