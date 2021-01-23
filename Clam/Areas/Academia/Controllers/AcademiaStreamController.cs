using System;
using System.Text;
using System.IO;
using System.Net;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Globalization;
using Clam.Models;
using Clam.Filters;
using Clam.Utilities;
using ClamDataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using ClamDataLibrary.DataAccess;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Logging;

namespace Clam.Areas.Academia.Controllers
{
    public class AcademiaStreamController : Controller
    {
        // Database Single File upload test Cases
        private readonly StreamFileUploadDatabase _uploadFile;
        private readonly StreamFileData _uploadContent;

        // Private readonly IFileProvider _fileProvider;
        private readonly ClamUserAccountContext _context;
        private readonly long _fileSizeLimit;
        private readonly ILogger<AcademiaStreamController> _logger;
        private readonly string[] _permittedExtentions = { ".mkv", ".flv", ".mp4" };
        private readonly string _targetFilePath;
        private readonly string _targetFolderPath;
        private readonly IFileProvider _fileProvider;

        // Get the default form options so that we can use them to set the default
        // limits for request body data.
        private static readonly FormOptions _defaultFormOptions = new FormOptions();

        public AcademiaStreamController(ClamUserAccountContext context, IConfiguration config, StreamFileUploadDatabase uploadFile,
            StreamFileData uploadContent, ILogger<AcademiaStreamController> logger, IFileProvider fileProvider)
        {
            //_fileProvider = fileProvider;
            _uploadFile = uploadFile;
            _uploadContent = uploadContent;
            _context = context;
            _logger = logger;
            _fileProvider = fileProvider;

            // Physical Store Provider
            _targetFilePath = config.GetValue<string>("AbsoluteRootFilePathStore");
            _targetFolderPath = config.GetValue<string>("AbsoluteFilePath-Acad");
            _fileSizeLimit = config.GetValue<long>("FileSizeLimit");
        }

        #region StreamUploadToDatabase
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
            var trustedFilePathStorage = string.Empty;
            var trustedFileNameForFileStorage = string.Empty;
            var streamedFileContent = new byte[0];
            var streamedFilePhysicalContent = new byte[0];

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

                        if (!Directory.Exists(_targetFilePath))
                        {
                            string path = String.Format("{0}", _targetFilePath);
                            Directory.CreateDirectory(path);
                        }

                        //streamedFileContent =
                        //    await FileHelpers.ProcessStreamedFile(section, contentDisposition,
                        //        ModelState, _permittedExtentions, _fileSizeLimit);

                        streamedFilePhysicalContent = await FileHelpers.ProcessStreamedFile(
                            section, contentDisposition, ModelState,
                            _permittedExtentions, _fileSizeLimit);


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

            trustedFilePathStorage = String.Format("{0}\\{1}\\{2}\\{3}",
                //_targetFilePath,
                _targetFolderPath,
                formData.AcademicId,
                formData.SubCategoryId,
                Path.GetRandomFileName());

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

            Directory.CreateDirectory(trustedFilePathStorage);

            using (var targetStream = System.IO.File.Create(
                            Path.Combine(trustedFilePathStorage, trustedFileNameForDisplay)))
            {
                await targetStream.WriteAsync(streamedFilePhysicalContent);

                _logger.LogInformation(
                    "Uploaded file '{TrustedFileNameForDisplay}' saved to " +
                    "'{TargetFilePath}' as {TrustedFileNameForFileStorage}",
                    trustedFileNameForDisplay, trustedFilePathStorage,
                    trustedFileNameForDisplay);
            }

            var file = new ClamSectionAcademicSubCategoryItem()
            {
                ItemPath = Path.Combine(trustedFilePathStorage, trustedFileNameForDisplay),
                ItemTitle = untrustedFileNameForStorage,
                //ItemDescription = formData.Note,
                Size = streamedFilePhysicalContent.Length,
                DateAdded = DateTime.Now,
                SubCategoryId = formData.SubCategoryId,
                AcademicId = formData.AcademicId
            };

            _context.Add(file);
            await _context.SaveChangesAsync();

            return RedirectToAction("Episode", "Academia", new { id = formData.AcademicId, said = formData.SubCategoryId });
        }
        #endregion

        #region StreamUploadToPhysical
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
                            string path = String.Format("{0}\\{1}", _targetFilePath, Path.GetRandomFileName());
                            Directory.CreateDirectory(path);
                        }
                        string test = String.Format("{0}\\{1}", _targetFilePath, "Test");
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

        public ActionResult DownloadFile(Guid id)
        {
            var requestFile = _context.ClamSectionAcademicSubCategoryItems.SingleOrDefault(m => m.ItemId == id);
            if (requestFile == null)
            {
                return null;
            }
            var downloadFile = _fileProvider.GetFileInfo(requestFile.ItemTitle);
            return PhysicalFile(requestFile.ItemPath, MediaTypeNames.Application.Octet, WebUtility.HtmlEncode(requestFile.ItemTitle));
        }

        public async Task<IActionResult> DeleteFile(Guid id, Guid said, string category, string section)
        {

            var requestFile = _context.ClamSectionAcademicSubCategoryItems.SingleOrDefault(m => m.ItemId == id);
            if (string.IsNullOrEmpty(id.ToString()))
            {
                ModelState.AddModelError("File",
                    $"The request couldn't be processed (Error 1).");
                // Log error

                return BadRequest(ModelState);
            }
            if (requestFile == null)
            {
                ModelState.AddModelError("File",
                    $"The request couldn't be processed (Error 2).");
                // Log error

                return BadRequest(ModelState);
            }
            //var proc = _context.ClamSectionAcademicSubCategoryItems.SingleOrDefault(m => m.ItemId == id);
            //var aid = proc.AcademicId;
            //var said = proc.SubCategoryId;

            int index = requestFile.ItemPath.LastIndexOf(@"\");
            System.IO.File.Delete(requestFile.ItemPath);
            Directory.Delete(requestFile.ItemPath.Substring(0, index));
            var model = _context.Set<ClamSectionAcademicSubCategoryItem>().Find(id);
            _context.Set<ClamSectionAcademicSubCategoryItem>().Remove(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Episode", "Academia", new { Id = id, Said = said, Category = category, Section = section });
        }

        public FileResult GetFile(Guid id)
        {
            var requestFile = _context.ClamSectionAcademicSubCategoryItems.SingleOrDefault(m => m.ItemId == id);
            if (requestFile == null)
            {
                return null;
            }
            var downloadFile = _fileProvider.GetFileInfo(requestFile.ItemTitle);
            return PhysicalFile(requestFile.ItemPath, MediaTypeNames.Application.Octet, WebUtility.HtmlEncode(requestFile.ItemTitle), enableRangeProcessing: true);
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