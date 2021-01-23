using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Clam.Areas.TVShows.Models;
using Clam.Filters;
using Clam.Repository;
using Clam.Utilities;
using ClamDataLibrary.DataAccess;
using ClamDataLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;

namespace Clam.Areas.TVShows.Controllers
{
    [Authorize(Policy = "Level-Two")]
    [Authorize(Policy = "Contributor-Access")]
    [Area("TVShows")]
    [Route("tvshows/manage")]
    public class TVShowController : Controller
    {
        private readonly UserManager<ClamUserAccountRegister> _userManager;
        private readonly RoleManager<ClamRoles> _roleManager;
        private readonly ClamUserAccountContext _context;
        private readonly UnitOfWork _unitOfWork;
        private readonly ILogger<TVShowController> _logger;
        private readonly IMapper _mapper;
        private readonly IFileProvider _fileProvider;

        // Stream Path Host
        private readonly string _targetFolderPath;
        private readonly string _targetImagePath;
        private readonly long _fileSizeLimit;
        private readonly string[] _permittedExtentions = { ".png", ".jpeg", ".jpg", ".mkv", ".flv", ".mp4" };

        // limits for request body data.
        private static readonly FormOptions _defaultFormOptions = new FormOptions();

        public TVShowController(UserManager<ClamUserAccountRegister> userManager, SignInManager<ClamUserAccountRegister> signInManager, RoleManager<ClamRoles> roleManager,
            ClamUserAccountContext context, IMapper mapper, IConfiguration config, IFileProvider fileProvider, UnitOfWork unitOfWork, ILogger<TVShowController> logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;
            _fileProvider = fileProvider;


            _targetFolderPath = config.GetValue<string>("AbsoluteFilePath-Show");
            _targetImagePath = config.GetValue<string>("AbsoluteFilePath-Image");
            _fileSizeLimit = config.GetValue<long>("FileSizeLimit");
        }

        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################

        [HttpGet]
        public async Task<IActionResult> Genre()
        {
            var model = await _unitOfWork.TVShowControl.GetAllGenres();
            return View(model);
        }

        [HttpGet("{category}/{id}")]
        public async Task<IActionResult> GenreDetails(Guid id, string category)
        {
            var model = await _unitOfWork.TVShowControl.GetGenre(id);
            ViewBag.Name = model.Genre;
            return View(model);
        }

        [Authorize(Policy = "Contributor-Create")]
        [HttpGet("create", Name = "create_genre")]
        public IActionResult CreateGenre()
        {
            return View();
        }

        [Authorize(Policy = "Contributor-Create")]
        [Authorize(Policy = "Permission-Create")]
        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateGenre(SectionTVShowCategory model)
        {
            try
            {
                await _unitOfWork.TVShowControl.AddAsyncGenre(model);
                _unitOfWork.Complete();
                return View();
            }
            catch
            {
                return View("Error");
            }
        }

        [Authorize(Policy = "Contributor-Update")]
        [HttpGet("{category}/edit/{id}", Name = "edit_genre")]
        public async Task<IActionResult> EditGenre(Guid id, string category)
        {
            var model = await _unitOfWork.TVShowControl.GetGenre(id);
            ViewBag.Name = model.Genre;
            ViewBag.Gid = id;
            return View(model);
        }

        [Authorize(Policy = "Contributor-Update")]
        [Authorize(Policy = "Permission-Update")]
        [HttpPost("{category}/edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditGenre(Guid id, SectionTVShowCategory collection, string category)
        {
            try
            {
                await _unitOfWork.TVShowControl.UpdateGenre(id, collection);
                _unitOfWork.Complete();
                return RedirectToAction(nameof(Genre));
            }
            catch (DbUpdateConcurrencyException)
            {
                return View();
            }
        }

        [Authorize(Policy = "Contributor-Remove")]
        [HttpGet("{category}/delete/{id}", Name = "delete_genre")]
        public async Task<IActionResult> DeleteGenre(Guid id, string category)
        {
            var model = await _unitOfWork.TVShowControl.GetGenre(id);
            ViewBag.Name = model.Genre;
            ViewBag.Gid = model.CategoryId;
            return View(model);
        }

        [Authorize(Policy = "Contributor-Remove")]
        [Authorize(Policy = "Permission-Remove")]
        [HttpPost("{category}/delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteGenre(Guid id, SectionTVShowCategory entity, string category)
        {
            try
            {
                await _unitOfWork.TVShowControl.RemoveGenre(id, entity);
                _unitOfWork.Complete();
                return RedirectToAction(nameof(Genre));
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
        // ############################################################ TVShow SubCategory Listing --> 16/04/20
        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################

        [HttpGet("{category}/list/{id}", Name = "list_show")]
        public async Task<IActionResult> TVShows(Guid id, string category)
        {
            var result = await _unitOfWork.TVShowControl.GetGenre(id);
            ViewBag.Gid = id;
            ViewBag.Genre = result.Genre;
            ViewBag.UrlGenre = result.Genre.ToLower();
            var model = await _unitOfWork.TVShowControl.GetGenreTVShows(id);
            return View(model);
        }

        [Authorize(Policy = "Contributor-Create")]
        [HttpGet("{category}/add-show/{id}", Name = "add_show")]
        public async Task<IActionResult> AddTVShow(Guid id, string category)
        {
            var model = await _unitOfWork.TVShowControl.GetGenre(id);
            var genre = model.Genre;
            ViewBag.UrlGenre = FilePathUrlHelper.UrlString(model.Genre);
            ViewBag.Genre = genre;
            ViewBag.Gid = id;
            return View();
        }

        [Authorize(Policy = "Contributor-Create")]
        [Authorize(Policy = "Permission-Create")]
        [HttpPost("{category}/add-show/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTVShow(Guid id, string category, SectionTVShowSubCategory entity)
        {
            try
            {
                await _unitOfWork.TVShowControl.AddAsyncTVShow(id, entity);
                _unitOfWork.Complete();
                return RedirectToAction(nameof(TVShows), new { Id = id, Category = category });
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Authorize(Policy = "Contributor-Update")]
        [HttpGet("{category}/{section}/edit/{id}", Name = "edit_show")]
        public async Task<IActionResult> EditTVShow(Guid id, string category, string section)
        {
            var model = await _unitOfWork.TVShowControl.GetTVShow(id);
            var getGenre = await _unitOfWork.TVShowControl.GetGenre(model.CategoryId);
            var genre = getGenre.Genre;
            ViewBag.Genre = genre;
            ViewBag.UrlGenre = FilePathUrlHelper.UrlString(genre);
            ViewBag.Gid = model.CategoryId;
            ViewBag.Name = model.TVShowTitle;
            ViewBag.TVShowId = model.TVShowId;
            return View(model);
        }

        [Authorize(Policy = "Contributor-Update")]
        [Authorize(Policy = "Permission-Update")]
        [HttpPost("{category}/{section}/edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTVShow(Guid id, SectionTVShowSubCategory entity, string category, string section)
        {
            try
            {
                var model = await _unitOfWork.TVShowControl.GetTVShow(id);
                await _unitOfWork.TVShowControl.UpdateTVShow(id, entity);
                return RedirectToAction(nameof(TVShows), new { id = entity.CategoryId, Category = category });
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Authorize(Policy = "Contributor-Remove")]
        [HttpGet("{category}/{section}/delete/{id}", Name = "delete_show")]
        public async Task<IActionResult> DeleteTVShow(Guid id, string category, string section)
        {
            var model = await _unitOfWork.TVShowControl.GetTVShow(id);
            var genreDetail = await _unitOfWork.TVShowControl.GetGenre(model.CategoryId);
            ViewBag.Gid = model.CategoryId;
            ViewBag.Name = model.TVShowTitle;
            ViewBag.TVShowId = model.TVShowId;
            ViewBag.Genre = genreDetail.Genre;
            ViewBag.UrlGenre = FilePathUrlHelper.UrlString(genreDetail.Genre);
            return View(model);
        }

        [Authorize(Policy = "Contributor-Remove")]
        [Authorize(Policy = "Permission-Remove")]
        [HttpPost("{category}/{section}/delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteTVShow(Guid id, SectionTVShowSubCategory entity, string category, string section)
        {
            try
            {
                await _unitOfWork.TVShowControl.RemoveTVShow(id, entity);
                _unitOfWork.Complete();
                return RedirectToAction(nameof(TVShows), new { Id = entity.CategoryId, Category = category });
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{category}/{section}/{id}")]
        public async Task<IActionResult> TVShowDetails(Guid id, string category, string section)
        {
            var model = await _unitOfWork.TVShowControl.GetTVShow(id);
            var getGenre = await _unitOfWork.TVShowControl.GetGenre(model.CategoryId);
            var genre = getGenre.Genre;
            ViewBag.Genre = genre;
            ViewBag.UrlGenre = FilePathUrlHelper.UrlString(genre);
            ViewBag.Gid = model.CategoryId;
            ViewBag.Name = model.TVShowTitle;
            ViewBag.TVShowId = model.TVShowId;
            return View(model);
        }

        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################
        // ######################################################### Sub Category TV Show Seasons --> 16/04/20
        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################

        [HttpGet("{category}/{section}/seasons/{id}/{show}")]
        public async Task<IActionResult> TVShowSeasons(Guid id, Guid show, string category, string section)
        {
            var showSelect = await _unitOfWork.TVShowControl.GetTVShow(show);
            var genreSelect = await _unitOfWork.TVShowControl.GetGenre(id);

            ViewBag.Gid = id;
            ViewBag.Show = show;
            ViewBag.Name = showSelect.TVShowTitle;
            ViewBag.Genre = genreSelect.Genre;
            ViewBag.UrlCategory = FilePathUrlHelper.UrlString(genreSelect.Genre);
            ViewBag.UrlSection = FilePathUrlHelper.UrlString(showSelect.TVShowTitle);

            var model = await _unitOfWork.TVShowControl.GetTVShowSeasons(id, show);
            return View(model);
        }

        [Authorize(Policy = "Contributor-Create")]
        [HttpGet("{category}/{section}/add-season/{id}/{show}")]
        public async Task<IActionResult> AddTVShowSeason(Guid id, Guid show, string category, string section)
        {
            // Get Genre Details
            var genre = await _unitOfWork.TVShowControl.GetGenre(id);
            var genreName = genre.Genre;

            // Get Show Details
            var showValue = await _unitOfWork.TVShowControl.GetTVShow(show);
            var showTitle = showValue.TVShowTitle;

            // Get Values from Genre & TV Show and Display in View
            ViewBag.GenreUrl = FilePathUrlHelper.UrlString(genreName);
            ViewBag.ShowUrl = FilePathUrlHelper.UrlString(showTitle);
            ViewBag.Genre = genreName;
            ViewBag.Gid = id;
            ViewBag.TVShow = showTitle;
            ViewBag.TVShowId = show;

            SectionTVShowSubCategorySeason model = new SectionTVShowSubCategorySeason()
            {
                CategoryId = id,
                TVShowId = show
            };

            return View(model);
        }

        [Authorize(Policy = "Contributor-Create")]
        [Authorize(Policy = "Permission-Create")]
        [HttpPost("{category}/{section}/add-season/{id}/{show}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTVShowSeason(Guid id, Guid show, SectionTVShowSubCategorySeason entity, string category, string section)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("TV Show Season",
                    $"The request couldn't be processed (Error 1).");
                    // Log error

                    return BadRequest(ModelState);
                }
                await _unitOfWork.TVShowControl.AddTVShowSeason(id, entity);
                return RedirectToAction(nameof(TVShowSeasons), new { Id = id, Show = entity.TVShowId, Category = category, Section = section });
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Authorize(Policy = "Contributor-Update")]
        [HttpGet("{category}/{section}/s{subsection}/edit/{id}/{show}/{season}")]
        public async Task<IActionResult> EditTVShowSeason(Guid id, Guid show, Guid season, string category, string section, string subsection)
        {
            var model = await _unitOfWork.TVShowControl.GetSeason(season);
            if (model.CategoryId == id && model.TVShowId == show && model.SeasonId == season)
            {
                var genre = await _unitOfWork.TVShowControl.GetGenre(id);
                var genreName = genre.Genre;
                ViewBag.Genre = genreName;
                ViewBag.GenreUrl = FilePathUrlHelper.UrlString(genreName);

                // Get Show Details
                var showValue = await _unitOfWork.TVShowControl.GetTVShow(show);
                var showTitle = showValue.TVShowTitle;
                ViewBag.Show = showTitle;
                ViewBag.ShowUrl = FilePathUrlHelper.UrlString(showTitle);
                ViewBag.SeasonId = season;
                ViewBag.SeasonNumber = model.TVShowSeasonNumber;

                ViewBag.Gid = model.CategoryId;
                ViewBag.TVShowId = model.TVShowId;
                ViewBag.Episodes = model.SubCategorySeasonItemCount;
                return View(model);
            }
            return RedirectToAction(nameof(TVShowSeasons), new { Id = id, Show = show });
        }

        [Authorize(Policy = "Contributor-Update")]
        [Authorize(Policy = "Permission-Update")]
        [HttpPost("{category}/{section}/s{subsection}/edit/{id}/{show}/{season}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTVShowSeason(Guid id, Guid show, Guid season, string category, string section, string subsection, SectionTVShowSubCategorySeason entity)
        {
            try
            {
                await _unitOfWork.TVShowControl.UpdateTVShowSeason(entity);
                _unitOfWork.Complete();
                return RedirectToAction(nameof(TVShowSeasons), new { Id = id, Show = entity.TVShowId, Category = category, Section = section, SubSection = subsection });
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Authorize(Policy = "Contributor-Remove")]
        [HttpGet("{category}/{section}/s{subsection}/delete/{id}/{show}/{season}")]
        public async Task<IActionResult> DeleteTVShowSeason(Guid id, Guid show, Guid season, string category, string section, string subsection)
        {
            var model = await _unitOfWork.TVShowControl.GetSeason(season);
            var episodes = await _unitOfWork.TVShowControl.GetSeasonEpisodes(id, show, season);
            if (model.CategoryId == id && model.TVShowId == show && model.SeasonId == season)
            {

                SectionTVShowSubCategorySeason retrieveModel = new SectionTVShowSubCategorySeason()
                {
                    SeasonId = model.SeasonId,
                    TVShowSeasonNumber = model.TVShowSeasonNumber,
                    ItemPath = model.ItemPath,
                    LastModified = model.LastModified,
                    DateCreated = model.DateCreated,
                    CategoryId = model.CategoryId,
                    TVShowId = model.TVShowId,
                    SubCategorySeasonItemCount = episodes.Episodes.Count
                };

                var genre = await _unitOfWork.TVShowControl.GetGenre(id);
                var genreName = genre.Genre;
                ViewBag.Genre = genreName;
                ViewBag.GenreUrl = FilePathUrlHelper.UrlString(genreName);

                // Get Show Details
                var showValue = await _unitOfWork.TVShowControl.GetTVShow(show);
                var showTitle = showValue.TVShowTitle;
                ViewBag.Show = showTitle;
                ViewBag.ShowUrl = FilePathUrlHelper.UrlString(showTitle);
                ViewBag.SeasonId = season;
                ViewBag.SeasonNumber = model.TVShowSeasonNumber;

                ViewBag.Gid = model.CategoryId;
                ViewBag.TVShowId = model.TVShowId;
                ViewBag.Episodes = model.SubCategorySeasonItemList;
                return View(retrieveModel);
            }
            return RedirectToAction(nameof(TVShowSeasons), new { Id = id, Show = show });
        }

        [Authorize(Policy = "Contributor-Remove")]
        [Authorize(Policy = "Permission-Remove")]
        [HttpPost("{category}/{section}/s{subsection}/delete/{id}/{show}/{season}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteTVShowSeason(Guid id, Guid show, Guid season, string category, string section, string subsection, SectionTVShowSubCategorySeason entity)
        {
            try
            {
                await _unitOfWork.TVShowControl.RemoveTVShowSeason(entity);
                _unitOfWork.Complete();
                return RedirectToAction(nameof(TVShowSeasons), new { Id = id, Show = entity.TVShowId, Category = category, Section = section, Subsection = subsection });
            }
            catch (Exception)
            {

                throw;
            }
        }

        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################
        // ######################################################## TV Show Sub Episdoe Listing --> 17/04/20
        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################

        [Authorize(Policy = "Contributor-Create")]
        [Authorize(Policy = "Contributor-Remove")]
        [Authorize(Policy = "Permission-Create")]
        [HttpGet("{category}/{section}/season/{subsection}/episodes/{id}", Name = "list_episodes")]
        public async Task<IActionResult> Episode(Guid id, Guid show, Guid season, string category, string section, string subsection)
        {

            var seasonSelect = await _unitOfWork.TVShowControl.GetSeason(season);
            var showSelect = await _unitOfWork.TVShowControl.GetTVShow(show);
            var genreSelect = await _unitOfWork.TVShowControl.GetGenre(id);

            ViewBag.Gid = id;
            ViewBag.Sid = show;
            ViewBag.Sig = season;
            ViewBag.GenreName = genreSelect.Genre;
            ViewBag.ShowName = showSelect.TVShowTitle;
            ViewBag.SeasonName = seasonSelect.TVShowSeasonNumber;
            ViewBag.UrlGenre = FilePathUrlHelper.UrlString(genreSelect.Genre);
            ViewBag.UrlSection = FilePathUrlHelper.UrlString(showSelect.TVShowTitle);
            ViewBag.UrlSubsection = seasonSelect.TVShowSeasonNumber.ToString();

            var model = await _unitOfWork.TVShowControl.GetSeasonEpisodes(id, show, season);
            model.CategoryId = id;
            model.TVShowId = show;
            model.SeasonId = season;
            return View(model);
        }

        [Authorize(Policy = "Contributor-Create")]
        [Authorize(Policy = "Contributor-Remove")]
        [Authorize(Policy = "Permission-Create")]
        [HttpGet("{category}/{section}/season/{subsection}/{subsectionitem}")]
        public async Task<IActionResult> Video(Guid id, Guid show, Guid season, Guid data, string category, string section, string subsection, string subsectionitem)
        {
            var status = false;
            ViewBag.Gid = id;
            ViewBag.Sid = show;
            ViewBag.Sig = season;
            ViewBag.Vid = data;

            var seasonSelect = await _unitOfWork.TVShowControl.GetSeason(season);
            var showSelect = await _unitOfWork.TVShowControl.GetTVShow(show);
            var genreSelect = await _unitOfWork.TVShowControl.GetGenre(id);
            var episodeSelect = await _unitOfWork.TVShowControl.GetEpisode(data);

            ViewBag.Video = FilePathUrlHelper.GetFileName(episodeSelect.ItemTitle);
            ViewBag.SeasonName = seasonSelect.TVShowSeasonNumber;
            ViewBag.ShowName = showSelect.TVShowTitle;
            ViewBag.GenreName = genreSelect.Genre;

            ViewBag.UrlGenre = FilePathUrlHelper.UrlString(genreSelect.Genre);
            ViewBag.UrlSection = FilePathUrlHelper.UrlString(showSelect.TVShowTitle);
            ViewBag.UrlSubsection = seasonSelect.TVShowSeasonNumber.ToString();
            ViewBag.UrlSubsectionItem = FilePathUrlHelper.GetFileName(FilePathUrlHelper.UrlString(episodeSelect.ItemTitle));

            List<SelectListItem> episodes = new List<SelectListItem>();
            var model = await _unitOfWork.TVShowControl.GetSeasonEpisodes(id, show, season);
            foreach (var item in model.Episodes)
            {
                if (item.CategoryId == id && item.TVShowId == show && item.SeasonId == season && item.ItemId == data)
                {
                    status = true;
                    episodes.Add(new SelectListItem() { Text = item.ItemTitle, Value = item.ItemPath, });
                }
            }
            if (status == true)
            {
                var result = await _unitOfWork.TVShowControl.GetEpisode(data);
                //ViewBag.Title = GetFileName(result.ItemPath);
                ViewBag.Title = result.ItemTitle;
                ViewBag.Episodes = episodes;
                ViewBag.Path = FilePathUrlHelper.DataFilePathFilter(result.ItemPath, 3);
                return View(result);
            }
            return RedirectToAction(nameof(Episode), new { Id = id, Show = show, Season = season });
        }

        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################
        // ######################################################## TV Show Sub Episdoe Listing --> 17/04/20
        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################
        // #####################################################################################################

        #region StreamUploadToDatabase
        [Authorize(Policy = "Contributor-Create")]
        [Authorize(Policy = "Permission-Create")]
        [HttpPost("upload/database-file")]
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
            List<ClamSectionTVShowSubCategorySeasonItem> episodeList = new List<ClamSectionTVShowSubCategorySeasonItem>();

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
            var formData = new StreamFormData();
            var formValueProvider = new FormValueProvider(
                BindingSource.Form,
                new FormCollection(formAccumulator.GetResults()),
                CultureInfo.CurrentCulture);
            var bindingSuccessful = await TryUpdateModelAsync(formData, prefix: "",
                valueProvider: formValueProvider);

            //trustedFilePathStorage = String.Format("{0}\\{1}\\{2}\\{3}\\{4}",
            //    //_targetFilePath,
            //    _targetFolderPath,
            //    formData.CategoryId,
            //    formData.TVShowId,
            //    formData.SeasonId,
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

            //Directory.CreateDirectory(trustedFilePathStorage);

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
            foreach (var item in fileStoredData)
            {
                trustedFilePathStorage = String.Format("{0}\\{1}\\{2}\\{3}\\{4}",
                //_targetFilePath,
                _targetFolderPath,
                formData.CategoryId,
                formData.TVShowId,
                formData.SeasonId,
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
                //storedPaths.Add(Path.Combine(trustedFilePathStorage, item.Key));
                //storedPathDictionaryKeys.Add(item.Key);
                episodeList.Add(new ClamSectionTVShowSubCategorySeasonItem()
                {
                    ItemPath = Path.Combine(trustedFilePathStorage, item.Key),
                    ItemTitle = item.Key,
                    Size = item.Value.Length,
                    DateCreated = DateTime.Now,
                    CategoryId = formData.CategoryId,
                    TVShowId = formData.TVShowId,
                    SeasonId = formData.SeasonId
                });
            }

            //var file = new ClamSectionTVShowSubCategorySeasonItem()
            //{
            //    ItemPath = Path.Combine(trustedFilePathStorage, trustedFileNameForDisplay),
            //    ItemTitle = untrustedFileNameForStorage,
            //    Size = streamedFilePhysicalContent.Length,
            //    DateCreated = DateTime.Now,
            //    CategoryId = formData.CategoryId,
            //    TVShowId = formData.TVShowId,
            //    SeasonId = formData.SeasonId
            //};
            //_context.Add(file);

            await _context.AddRangeAsync(episodeList);
            await _context.SaveChangesAsync();

            var url = String.Format("{0}/{1}/season/{2}/episodes/{3}",
                formData.UrlCategory,
                formData.UrlSection,
                formData.UrlSubSection,
                formData.CategoryId
                );

            return RedirectToAction("Episode", "TVShow", new { id = formData.CategoryId, show = formData.TVShowId, season = formData.SeasonId, 
            category = formData.UrlCategory, section = formData.UrlSection, subsection = formData.UrlSubSection});
        }
        #endregion

        [Authorize(Policy = "Contributor-Create")]
        [Authorize(Policy = "Permission-Create")]
        [HttpGet("request-file")]
        public async Task<IActionResult> DownloadFile(Guid id)
        {
            //var requestFile = _context.ClamSectionTVShowSubCategorySeasonItems.SingleOrDefault(m => m.ItemId == id);
            var requestFile = await _unitOfWork.TVShowControl.GetEpisode(id);
            if (requestFile == null)
            {
                return null;
            }
            var downloadFile = _fileProvider.GetFileInfo(requestFile.ItemTitle);
            return PhysicalFile(requestFile.ItemPath, MediaTypeNames.Application.Octet, WebUtility.HtmlEncode(requestFile.ItemTitle));
        }

        [Authorize(Policy = "Contributor-Remove")]
        [Authorize(Policy = "Permission-Remove")]
        [HttpGet("remove-file")]
        public async Task<IActionResult> DeleteFile(Guid id, string category, string section, string subsection)
        {

            if (string.IsNullOrEmpty(id.ToString()))
            {
                ModelState.AddModelError("File",
                    $"The request couldn't be processed (Error 1).");
                // Log error

                return BadRequest(ModelState);
            }
            var proc = _context.ClamSectionTVShowSubCategorySeasonItems.SingleOrDefault(m => m.ItemId == id);
            var gid = proc.CategoryId;
            var sid = proc.TVShowId;
            var sig = proc.SeasonId;
            await _unitOfWork.TVShowControl.RemoveEpisode(id);
            _unitOfWork.Complete();
            return RedirectToAction("Episode", "TVShow", new { id = gid, show = sid, season = sig, Category = category, Section = section, Subsection = subsection });
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