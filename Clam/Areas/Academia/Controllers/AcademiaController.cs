using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Clam.Areas.Academia.Models;
using ClamDataLibrary.DataAccess;
using ClamDataLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Clam.Utilities;
using Clam.Repository;
using System.IO;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;
using Microsoft.Net.Http.Headers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Http.Features;
using Clam.Filters;
using Microsoft.AspNetCore.WebUtilities;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Data.SqlClient;

namespace Clam.Areas.Academia.Controllers
{
    [Authorize(Policy = "Level-Two")]
    [Authorize(Policy = "Contributor-Access")]
    [Area("Academia")]
    [Route("academia/manage")]
    public class AcademiaController : Controller
    {

        private readonly UserManager<ClamUserAccountRegister> _userManager;
        private readonly SignInManager<ClamUserAccountRegister> _signInManager;
        private readonly RoleManager<ClamRoles> _roleManager;
        private readonly ClamUserAccountContext _context;
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;

        // Test Web Hosting
        private readonly string _targetFolderPath;

        private readonly long _fileSizeLimit;
        private readonly ILogger<AcademiaController> _logger;
        private readonly string[] _permittedExtentions = { ".mkv", ".flv", ".mp4" };
        private readonly string _targetFilePath;
        private readonly IFileProvider _fileProvider;

        // Get the default form options so that we can use them to set the default
        // limits for request body data.
        private static readonly FormOptions _defaultFormOptions = new FormOptions();

        public AcademiaController(UserManager<ClamUserAccountRegister> userManager, SignInManager<ClamUserAccountRegister> signInManager, RoleManager<ClamRoles> roleManager,
            ClamUserAccountContext context, IMapper mapper, ILogger<AcademiaController> logger, IConfiguration config, IFileProvider fileProvider, UnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _fileProvider = fileProvider;

            // Physical Store Provider
            _targetFilePath = config.GetValue<string>("AbsoluteRootFilePathStore");
            _targetFolderPath = config.GetValue<string>("AbsoluteFilePath-Acad");
            _fileSizeLimit = config.GetValue<long>("FileSizeLimit");
        }

        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################
        // ########################################################### Academic Category Listing

        [HttpGet]
        public async Task<IActionResult> Category()
        {
            var model = await _unitOfWork.AcademiaControl.GetAllCategories();
            return View(model);
        }

        [HttpGet("{category}/details/{id}")]
        public async Task<IActionResult> CategoryDetails(Guid id, string category)
        {
            var model = await _unitOfWork.AcademiaControl.GetCategory(id);
            ViewBag.Name = model.AcademicDisciplineTitle;
            ViewBag.UrlGenre = FilePathUrlHelper.UrlString(model.AcademicDisciplineTitle);
            return View(model);
        }

        [Authorize(Policy = "Contributor-Create")]
        [HttpGet("create")]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [Authorize(Policy = "Contributor-Create")]
        [Authorize(Policy = "Permission-Create")]
        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCategory(SectionAcademicRegister model)
        {
            try
            {
                await _unitOfWork.AcademiaControl.AddAsyncCategory(model);
                _unitOfWork.Complete();
                return RedirectToAction(nameof(Category));
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Policy = "Contributor-Update")]
        [HttpGet("{category}/edit/{id}")]
        public async Task<IActionResult> EditCategory(Guid id, string category)
        {
            var model = await _unitOfWork.AcademiaControl.GetCategory(id);
            ViewBag.Aid = id;
            ViewBag.Name = model.AcademicDisciplineTitle;
            ViewBag.UrlGenre = FilePathUrlHelper.UrlString(model.AcademicDisciplineTitle);
            return View(model);
        }

        [Authorize(Policy = "Contributor-Update")]
        [Authorize(Policy = "Permission-Update")]
        [HttpPost("{category}/edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCategory(Guid id, SectionAcademicRegister collection, string category)
        {
            try
            {
                await _unitOfWork.AcademiaControl.UpdateCategory(id, collection);
                _unitOfWork.Complete();
                return RedirectToAction(nameof(Category));

            }
            catch (DbUpdateConcurrencyException)
            {
                return View();
            }
        }

        [Authorize(Policy = "Contributor-Remove")]
        [HttpGet("{category}/delete/{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id, string category)
        {
            var model = await _unitOfWork.AcademiaControl.GetCategory(id);
            ViewBag.Aid = model.AcademicId;
            ViewBag.Name = model.AcademicDisciplineTitle;
            ViewBag.UrlGenre = FilePathUrlHelper.UrlString(model.AcademicDisciplineTitle);
            return View(model);
        }

        [Authorize(Policy = "Contributor-Remove")]
        [Authorize(Policy = "Permission-Remove")]
        [HttpPost("{category}/delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCategory(Guid id, IFormCollection collection, string category)
        {
            try
            {
                await _unitOfWork.AcademiaControl.RemoveCategory(id);
                _unitOfWork.Complete();
                return RedirectToAction(nameof(Category));
            }
            catch
            {
                return View();
            }
        }

        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################

        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################
        // ########################################################### Academic SubCategory Listing --> 31/03/20
        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################


        [HttpGet("{category}/list/{id}")]
        public async Task<IActionResult> Section(Guid id, string category)
        {
            var model = await _unitOfWork.AcademiaControl.GetSections(id, category);
            var getName = await _unitOfWork.AcademiaControl.GetCategory(id);
            ViewBag.Aid = id;
            ViewBag.CategoryName = getName.AcademicDisciplineTitle;
            ViewBag.UrlCategory = FilePathUrlHelper.UrlString(category);
            return View(model);
        }

        [Authorize(Policy = "Contributor-Create")]
        [HttpGet("{category}/create/{id}")]
        public async Task<IActionResult> CreateSection(Guid id, string category)
        {
            //var name = _context.Set<ClamSectionAcademicCategory>().Find(id);
            var model = await _unitOfWork.AcademiaControl.GetCategory(id);
            var categoryTitle = model.AcademicDisciplineTitle;
            ViewBag.UrlCategory = FilePathUrlHelper.UrlString(category);
            ViewBag.CategoryName = categoryTitle;
            ViewBag.Category = categoryTitle;
            ViewBag.Aid = id;
            return View();
        }

        [Authorize(Policy = "Contributor-Create")]
        [Authorize(Policy = "Permission-Create")]
        [HttpPost("{category}/create/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSection(Guid id, string category, SectionRegister entity)
        {
            try
            {
                await _unitOfWork.AcademiaControl.AddAsyncSection(id, entity);
                _unitOfWork.Complete();
                return RedirectToAction(nameof(Section), new { Id = id, Category = category });

            }
            catch (Exception)
            {

                throw;
            }
        }

        [Authorize(Policy = "Contributor-Update")]
        [HttpGet("{category}/{section}/edit/{id}")]
        public async Task<IActionResult> EditSection(Guid id, string category, string section)
        {
            var model = await _unitOfWork.AcademiaControl.GetSelectedSection(id);
            var categoryName = await _unitOfWork.AcademiaControl.GetCategory(model.AcademicId);
            ViewBag.Aid = model.AcademicId;
            ViewBag.Name = model.SubCategoryTitle;
            ViewBag.SectionName = model.SubCategoryTitle;
            ViewBag.CategoryName = categoryName.AcademicDisciplineTitle;
            ViewBag.UrlCategory = FilePathUrlHelper.UrlString(category);
            ViewBag.UrlSection = FilePathUrlHelper.UrlString(section);
            return View(model);
        }

        [Authorize(Policy = "Contributor-Update")]
        [Authorize(Policy = "Permission-Update")]
        [HttpPost("{category}/{section}/edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSection(Guid id, SectionRegister entity, string category, string section)
        {
            try
            {
                var captureModel = await _unitOfWork.AcademiaControl.GetSelectedSection(entity.SubCategoryId);
                await _unitOfWork.AcademiaControl.UpdateSection(id, entity);
                _unitOfWork.Complete();
                return RedirectToAction(nameof(Section), new { Id = captureModel.AcademicId, Category = category });
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Authorize(Policy = "Contributor-Remove")]
        [HttpGet("{category}/{section}/delete/{id}")]
        public async Task<IActionResult> DeleteSection(Guid id, string category, string section)
        {
            var model = await _unitOfWork.AcademiaControl.GetSelectedSection(id);
            var categoryName = await _unitOfWork.AcademiaControl.GetCategory(model.AcademicId);
            ViewBag.Aid = model.AcademicId;
            ViewBag.Name = model.SubCategoryTitle;
            ViewBag.SectionName = model.SubCategoryTitle;
            ViewBag.CategoryName = categoryName.AcademicDisciplineTitle;
            ViewBag.UrlCategory = FilePathUrlHelper.UrlString(category);
            ViewBag.UrlSection = FilePathUrlHelper.UrlString(section);
            return View(model);
        }

        [Authorize(Policy = "Contributor-Remove")]
        [Authorize(Policy = "Permission-Remove")]
        [HttpPost("{category}/{section}/delete/{id}")]
        public async Task<IActionResult> DeleteSection(Guid id, SectionRegister entity, string category, string section)
        {
            try
            {
                var model = await _unitOfWork.AcademiaControl.GetSelectedSection(entity.SubCategoryId);
                await _unitOfWork.AcademiaControl.RemoveSection(id, entity);
                _unitOfWork.Complete();
                return RedirectToAction(nameof(Section), new { Id = model.AcademicId, Category = category });
            }
            catch (Exception)
            {

                return View();
            }
        }

        [HttpGet("{category}/{section}/details/{id}")]
        public async Task<IActionResult> SectionDetails(Guid id, string category, string section)
        {
            var model = await _unitOfWork.AcademiaControl.GetSelectedSection(id);
            var categoryName = await _unitOfWork.AcademiaControl.GetCategory(model.AcademicId);
            ViewBag.Aid = model.AcademicId;
            ViewBag.Name = model.SubCategoryTitle;
            ViewBag.SectionName = model.SubCategoryTitle;
            ViewBag.CategoryName = categoryName.AcademicDisciplineTitle;
            ViewBag.UrlCategory = FilePathUrlHelper.UrlString(category);
            ViewBag.UrlSection = FilePathUrlHelper.UrlString(section);
            return View(model);
        }

        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################
        // ########################################################### Academic SubCategory Listing --> 31/03/20
        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################

        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################
        // ########################################################### Academic SubCategoryItem Listing --> 28/03/20
        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################

        [Authorize(Policy = "Contributor-Create")]
        [Authorize(Policy = "Permission-Create")]
        [Authorize(Policy = "Permission-Update")]
        [Authorize(Policy = "Permission-Remove")]
        [HttpGet("{category}/{section}/{id}/{said}")]
        public async Task<IActionResult> Episode(Guid id, Guid said, string category, string section)
        {
            ViewBag.Aid = id;
            ViewBag.Said = said;
            ViewBag.UrlCategory = FilePathUrlHelper.UrlString(category);
            ViewBag.UrlSection = FilePathUrlHelper.UrlString(section);

            var modelCategory = await _unitOfWork.AcademiaControl.GetCategory(id);
            var modelSection = await _unitOfWork.AcademiaControl.GetSelectedSection(said);
            ViewBag.CategoryName = modelCategory.AcademicDisciplineTitle;
            ViewBag.SectionName = modelSection.SubCategoryTitle;
            var model = await _unitOfWork.AcademiaControl.GetSectionEpisodes(id, said, category, section);
            return View(model);
        }

        [Authorize(Policy = "Contributor-Create")]
        [Authorize(Policy = "Permission-Create")]
        [Authorize(Policy = "Permission-Update")]
        [Authorize(Policy = "Permission-Remove")]
        [HttpGet("{category}/{section}/{sectionitem}/{id}/{said}/{data}")]
        public async Task<IActionResult> Video(Guid id, Guid said, Guid data, string category, string section, string sectionitem)
        {
            var status = false;
            ViewBag.Data = data;
            ViewBag.Said = said;
            ViewBag.Aid = id;
            ViewBag.UrlCategory = FilePathUrlHelper.UrlString(category);
            ViewBag.UrlSection = FilePathUrlHelper.UrlString(section);
            ViewBag.UrlSectionItem = FilePathUrlHelper.UrlString(sectionitem);

            List<SelectListItem> episdoes = new List<SelectListItem>();
            var model = await _unitOfWork.AcademiaControl.GetAllEpisodes();
            foreach (var item in model)
            {
                if (item.AcademicId == id && item.SubCategoryId == said && item.ItemId == data)
                {
                    status = true;
                }
                if (item.SubCategoryId == said)
                {
                    episdoes.Add(new SelectListItem() { Text = FilePathUrlHelper.GetFileName(item.ItemTitle), Value = item.ItemPath });
                }
            }
            if (status == true)
            {
                var result = await _unitOfWork.AcademiaControl.GetVideo(data);
                ViewBag.Title = FilePathUrlHelper.GetFileName(result.ItemTitle);
                ViewBag.Episodes = episdoes;
                ViewBag.Path = FilePathUrlHelper.DataFilePathFilter(result.ItemPath, 3);
                return View(result);
            }
            return RedirectToAction(nameof(Episode), new { Id = id, Said = said, Category = category, Section = section });
        }

        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################
        // ########################################################### Academic SubCategoryItem Listing --> 28/03/20
        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################


        #region StreamUploadToDatabase
        [Authorize(Policy = "Contributor-Create")]
        [Authorize(Policy = "Permission-Create")]
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

            // List Byte for file storage
            List<byte[]> filesByteStorage = new List<byte[]>();
            List<string> filesNameStorage = new List<string>();
            var fileStoredData = new Dictionary<string, byte[]>();
            List<string> storedPaths = new List<string>();
            List<string> storedPathDictionaryKeys = new List<string>();

            // List to Submit
            List<ClamSectionAcademicSubCategoryItem> itemList = new List<ClamSectionAcademicSubCategoryItem>();

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

                        filesNameStorage.Add(trustedFileNameForDisplay);
                        filesByteStorage.Add(streamedFilePhysicalContent);
                        fileStoredData.Add(trustedFileNameForDisplay, streamedFilePhysicalContent);

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

            //trustedFilePathStorage = String.Format("{0}\\{1}\\{2}\\{3}",
            //    //_targetFilePath,
            //    _targetFolderPath,
            //    formData.AcademicId,
            //    formData.SubCategoryId,
            //    Path.GetRandomFileName());

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

            foreach (var item in fileStoredData)
            {
                trustedFilePathStorage = String.Format("{0}\\{1}\\{2}\\{3}",
                _targetFolderPath,
                formData.AcademicId,
                formData.SubCategoryId,
                Path.GetRandomFileName());
                Directory.CreateDirectory(trustedFilePathStorage);

                using (var targetStream = System.IO.File.Create(
                            Path.Combine(trustedFilePathStorage, item.Key)))
                {
                    await targetStream.WriteAsync(item.Value);

                    _logger.LogInformation(
                        "Uploaded file '{TrustedFileNameForDisplay}' saved to " +
                        "'{TargetFilePath}' as {TrustedFileNameForFileStorage}",
                        item.Key, trustedFilePathStorage,
                        item.Key);
                }

                itemList.Add(new ClamSectionAcademicSubCategoryItem()
                {
                    ItemPath = Path.Combine(trustedFilePathStorage, item.Key),
                    ItemTitle = item.Key,
                    //ItemDescription = formData.Note,
                    Size = item.Value.Length,
                    DateAdded = DateTime.Now,
                    SubCategoryId = formData.SubCategoryId,
                    AcademicId = formData.AcademicId
                });

            }


            //using (var targetStream = System.IO.File.Create(
            //                Path.Combine(trustedFilePathStorage, trustedFileNameForDisplay)))
            //{
            //    await targetStream.WriteAsync(streamedFilePhysicalContent);

            //    _logger.LogInformation(
            //        "Uploaded file '{TrustedFileNameForDisplay}' saved to " +
            //        "'{TargetFilePath}' as {TrustedFileNameForFileStorage}",
            //        trustedFileNameForDisplay, trustedFilePathStorage,
            //        trustedFileNameForDisplay);
            //}

            //var file = new ClamSectionAcademicSubCategoryItem()
            //{
            //    ItemPath = Path.Combine(trustedFilePathStorage, trustedFileNameForDisplay),
            //    ItemTitle = untrustedFileNameForStorage,
            //    //ItemDescription = formData.Note,
            //    Size = streamedFilePhysicalContent.Length,
            //    DateAdded = DateTime.Now,
            //    SubCategoryId = formData.SubCategoryId,
            //    AcademicId = formData.AcademicId
            //};

            await _context.AddRangeAsync(itemList);
            await _context.SaveChangesAsync();

            return RedirectToAction("Episode", "Academia", new { id = formData.AcademicId, said = formData.SubCategoryId });
        }
        #endregion

        [Authorize(Policy = "Contributor-Create")]
        [Authorize(Policy = "Permission-Create")]
        [HttpGet("download")]
        public async Task<IActionResult> DownloadFile(Guid id)
        {
            var requestFile = await _unitOfWork.AcademiaControl.GetVideo(id);
            if (requestFile == null)
            {
                return null;
            }
            var downloadFile = _fileProvider.GetFileInfo(requestFile.ItemTitle);
            return PhysicalFile(requestFile.ItemPath, MediaTypeNames.Application.Octet, WebUtility.HtmlEncode(requestFile.ItemTitle));
        }

        [Authorize(Policy = "Contributor-Remove")]
        [Authorize(Policy = "Permission-Remove")]
        [HttpPost("remove-academia-file/{category}/{id}/{section}/{said}")]
        public async Task<IActionResult> DeleteFile(Guid id, Guid said, string category, string section)
        {
            var model = await _unitOfWork.AcademiaControl.GetSelectedSection(said);
            await _unitOfWork.AcademiaControl.RemoveVideo(id);
            _unitOfWork.Complete();
            return RedirectToAction("Episode", "Academia", new { Id = model.AcademicId, Said = said, Category = category, Section = section });
        }

        public async Task<FileResult> GetFile(Guid id)
        {
            //var requestFile = _context.ClamSectionAcademicSubCategoryItems.SingleOrDefault(m => m.ItemId == id);
            var requestFile = await _unitOfWork.AcademiaControl.GetVideo(id);
            if (requestFile == null)
            {
                return null;
            }
            var downloadFile = _fileProvider.GetFileInfo(requestFile.ItemPath);
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