using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Clam.Areas.Storage.Models;
using Clam.Filters;
using Clam.Repository;
using Clam.Utilities;
using Clam.Utilities.Security;
using ClamDataLibrary.DataAccess;
using ClamDataLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;

namespace Clam.Areas.Storage.Controllers
{
    [Authorize(Policy = "Level-Three")]
    [Area("Storage")]
    [Route("storage")]
    public class StorageController : Controller
    {

        private readonly UserManager<ClamUserAccountRegister> _userManager;
        private readonly SignInManager<ClamUserAccountRegister> _signInManager;
        private readonly RoleManager<ClamRoles> _roleManager;
        private readonly ClamUserAccountContext _context;
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;

        // Stream Path Host
        private readonly string _targetFolderPath;
        private readonly string _targetFilePath;
        private readonly long _fileSizeLimit;
        private readonly ILogger<StorageController> _logger;
        private readonly string[] _permittedExtentions = { ".pdf", ".jpg", ".png", ".jpeg", ".gif",
            ".mp4", ".mp3", ".zip", ".m4a", ".pdf", ".txt", ".doc", ".docx", ".aax", ".wpd" };

        // WebHosting Enviroment
        private readonly IWebHostEnvironment _environment;
        // Get the default form options so that we can use them to set the default
        // limits for request body data.
        private static readonly FormOptions _defaultFormOptions = new FormOptions();

        public StorageController(UserManager<ClamUserAccountRegister> userManager, SignInManager<ClamUserAccountRegister> signInManager, RoleManager<ClamRoles> roleManager,
            ClamUserAccountContext context, IMapper mapper, IConfiguration config, 
            IWebHostEnvironment environment, ILogger<StorageController> logger, UnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;

            _environment = environment;
            _targetFilePath = config.GetValue<string>("AbsoluteRootFilePathStore");
            _targetFolderPath = config.GetValue<string>("AbsoluteFilePath-Storage");
            _fileSizeLimit = config.GetValue<long>("StorageSizeLimit");
        }

        // GET: Storage
        [ProtectedPersonalData]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // Retrieve user identity
            if (!User.Identity.IsAuthenticated)
            {
                return View("AccessDenied");
            }
            var userName = User.Identity.Name;
            var model = await _unitOfWork.StorageControl.GetStorageHome(userName);
            return View(model);
        }

        [ProtectedPersonalData]
        [HttpGet("view/{id}")]
        public async Task<IActionResult> Open(Guid id)
        {
            var model = await _unitOfWork.StorageControl.GetFile(id);
            return View(model);
        }

        [ProtectedPersonalData]
        [HttpPost("remove")]
        public async Task<IActionResult> Remove(Guid id)
        {
            await _unitOfWork.StorageControl.RemoveFile(id);
            _unitOfWork.Complete();
            return RedirectToAction(nameof(Index));
        }

        [ProtectedPersonalData]
        [HttpGet("download")]
        public IActionResult DownloadFile(Guid id)
        {
            var requestFile = _unitOfWork.StorageControl.SingleOrDefault(x => x.ItemId == id);
            if (requestFile == null)
            {
                return null;
            }
            return PhysicalFile(requestFile.ItemPath, MediaTypeNames.Application.Octet, WebUtility.HtmlEncode(FilePathUrlHelper.GetFileAtEndOfPath(requestFile.ItemPath)));
        }

        [HttpPost("filestream")]
        [ValidateAntiForgeryToken]
        [RequestSizeLimit(4294967295)]
        public async Task<IActionResult> MultipleFiles(StreamStorageFile files)
        {
            // User Profile
            var name = User.Identity.Name;
            var profile = await _userManager.FindByNameAsync(name);

            // Accumulate the form data key-value pairs in the request (formAccumulator).
            var trustedFileNameForDisplay = string.Empty;
            var untrustedFileNameForStorage = string.Empty;
            var trustedFilePathStorage = string.Empty;
            var trustedFileNameForFileStorage = string.Empty;
            var streamedFileImageContent = new byte[0];
            var streamedFilePhysicalContent = new byte[0];

            // List Byte for file storage
            List<byte[]> filesByteStorage = new List<byte[]>();
            List<string> filesNameStorage = new List<string>();
            List<string> storedPaths = new List<string>();
            List<string> storedPathDictionaryKeys = new List<string>();
            var fileStoredData = new Dictionary<string, byte[]>();

            // Test Files
            List<ClamUserPersonalCategoryItem> userFiles = new List<ClamUserPersonalCategoryItem>();

            foreach (var file in files.File)
            {

                untrustedFileNameForStorage = file.FileName;
                // Don't trust the file name sent by the client. To display
                // the file name, HTML-encode the value.
                trustedFileNameForDisplay = WebUtility.HtmlEncode(
                        file.FileName);

                if (!Directory.Exists(_targetFilePath))
                {
                    string path = String.Format("{0}", _targetFilePath);
                    Directory.CreateDirectory(path);
                }

                // Bind form data to the model
                var keyPathFolder = FilePathUrlHelper.GenerateKeyPath(profile.Id);
                var generateKeyFolder = GenerateSecurity.Encode(profile.Id);

                trustedFilePathStorage = String.Format("{0}\\{1}\\{2}\\{3}",
                _targetFolderPath,
                keyPathFolder,
                generateKeyFolder,
                Path.GetRandomFileName());
                Directory.CreateDirectory(trustedFilePathStorage);

                using (var fileStream = new FileStream(Path.Combine(trustedFilePathStorage, untrustedFileNameForStorage),
                    FileMode.Create, FileAccess.Write))
                {
                    await file.CopyToAsync(fileStream);
                    fileStream.Close();
                }

                userFiles.Add(new ClamUserPersonalCategoryItem()
                {
                    FileName = trustedFileNameForDisplay,
                    ItemPath = Path.Combine(trustedFilePathStorage, untrustedFileNameForStorage),
                    Size = file.Length,
                    UserId = profile.Id,
                    DateCreated = DateTime.Now,
                    LastModified = DateTime.Now
                });
            }

            ToDatabase(userFiles);

            return RedirectToAction(nameof(Index));
        }

        public void ToDatabase(List<ClamUserPersonalCategoryItem> files)
        {
            Task.WaitAll(_context.AddRangeAsync(files));
            Task.WaitAll(_context.SaveChangesAsync());
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