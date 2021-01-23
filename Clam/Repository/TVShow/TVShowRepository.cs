using Clam.Interface.TVShow;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ClamDataLibrary.DataAccess;
using ClamDataLibrary.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Clam.Areas.TVShows.Models;
using Clam.Utilities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Clam.Areas.Academia.Models;

namespace Clam.Repository.TVShow
{
    public class TVShowRepository : Controller, ITVShowRepository
    {

        private readonly UserManager<ClamUserAccountRegister> _userManager;
        private readonly ClamUserAccountContext _context;
        private readonly IMapper _mapper;

        private readonly string _targetFolderPath;
        private readonly string _targetImagePath;
        private readonly long _fileSizeLimit;
        private readonly string[] _permittedExtentions = { ".png", ".jpeg", ".jpg" };

        public TVShowRepository(ClamUserAccountContext context, UserManager<ClamUserAccountRegister> userManager,
            IMapper mapper, IConfiguration config)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;

            _targetFolderPath = config.GetValue<string>("AbsoluteFilePath-Show");
            _targetImagePath = config.GetValue<string>("AbsoluteFilePath-Image");
            _fileSizeLimit = config.GetValue<long>("ImageSizeLimit");
        }

        public async Task AddAsyncGenre(SectionTVShowCategory model)
        {
            var trustedFileNameForDisplay = string.Empty;
            var trustedFilePathForStorage = string.Empty;
            var streamedFilePhysicalContent = new byte[0];

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Genre",
                $"The request couldn't be processed (Error 1).");
                // Log error

            }

            streamedFilePhysicalContent =
           await FileHelpers.ProcessFormFile<StreamFileUploadDatabase>(
               model.FormFile, ModelState, _permittedExtentions,
               _fileSizeLimit);

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Genre",
                $"The request couldn't be processed (Error 1).");
                // Log error

            }

            trustedFilePathForStorage = String.Format("{0}\\{1}\\{2}",
                _targetImagePath,
                Guid.NewGuid().ToString(),
                Path.GetRandomFileName());
            trustedFileNameForDisplay = String.Format("{0}_{1}",
                Guid.NewGuid(),
                WebUtility.HtmlEncode(model.FormFile.FileName));

            Directory.CreateDirectory(trustedFilePathForStorage);
            using (var targetStream = System.IO.File.Create(
                        Path.Combine(trustedFilePathForStorage, trustedFileNameForDisplay)))
            {
                await targetStream.WriteAsync(streamedFilePhysicalContent);

                //_logger.LogInformation(
                //    "Uploaded file '{TrustedFileNameForDisplay}' saved to " +
                //    "'{TargetFilePath}' as {TrustedFileNameForFileStorage}",
                //    trustedFileNameForDisplay, trustedFilePathForStorage,
                //    trustedFileNameForDisplay);
            }

            // TODO: Add insert logic here
            ClamSectionTVShowCategory result = new ClamSectionTVShowCategory
            {
                Genre = model.Genre,
                ItemPath = Path.Combine(trustedFilePathForStorage, trustedFileNameForDisplay)
            };
            await _context.ClamSectionTVShowCategories.AddAsync(result);
            Task.WaitAll(_context.SaveChangesAsync());
        }

        public async Task AddAsyncTVShow(Guid id, SectionTVShowSubCategory model)
        {
            var trustedFileNameForDisplay = string.Empty;
            var trustedFilePathForStorage = string.Empty;
            var streamedFilePhysicalContent = new byte[0];

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Genre",
                $"The request couldn't be processed (Error 1).");
                // Log error

            }

            streamedFilePhysicalContent =
           await FileHelpers.ProcessFormFile<StreamFileUploadDatabase>(
               model.FormFile, ModelState, _permittedExtentions,
               _fileSizeLimit);

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Genre",
                $"The request couldn't be processed (Error 1).");
                // Log error

            }

            trustedFilePathForStorage = String.Format("{0}\\{1}\\{2}",
                _targetImagePath,
                Guid.NewGuid().ToString(),
                Path.GetRandomFileName());
            trustedFileNameForDisplay = String.Format("{0}_{1}",
                Guid.NewGuid(),
                WebUtility.HtmlEncode(model.FormFile.FileName));

            Directory.CreateDirectory(trustedFilePathForStorage);
            using (var targetStream = System.IO.File.Create(
                        Path.Combine(trustedFilePathForStorage, trustedFileNameForDisplay)))
            {
                await targetStream.WriteAsync(streamedFilePhysicalContent);

                //_logger.LogInformation(
                //    "Uploaded file '{TrustedFileNameForDisplay}' saved to " +
                //    "'{TargetFilePath}' as {TrustedFileNameForFileStorage}",
                //    trustedFileNameForDisplay, trustedFilePathForStorage,
                //    trustedFileNameForDisplay);
            }

            var filterSeasons = _context.ClamSectionTVShowSubCategorySeasons.ToList();
            ClamSectionTVShowSubCategory test = new ClamSectionTVShowSubCategory
            {
                CategoryId = id,
                TVShowTitle = model.TVShowTitle,
                ItemPath = Path.Combine(trustedFilePathForStorage, trustedFileNameForDisplay),
                TVShowSeasonNumberTotal = filterSeasons.Select(x => x.TVShowId).Where(x => x.Equals(id)).Count()
            };
            await _context.ClamSectionTVShowSubCategories.AddAsync(test);
            Task.WaitAll(_context.SaveChangesAsync());
        }

        public async Task AddGenre(SectionTVShowCategory model)
        {
            var trustedFileNameForDisplay = string.Empty;
            var trustedFilePathForStorage = string.Empty;
            var streamedFilePhysicalContent = new byte[0];

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Genre",
                $"The request couldn't be processed (Error 1).");
                // Log error

            }

            streamedFilePhysicalContent =
           await FileHelpers.ProcessFormFile<StreamFileUploadDatabase>(
               model.FormFile, ModelState, _permittedExtentions,
               _fileSizeLimit);

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Genre",
                $"The request couldn't be processed (Error 1).");
                // Log error

            }

            trustedFilePathForStorage = String.Format("{0}\\{1}\\{2}",
                _targetImagePath,
                Guid.NewGuid().ToString(),
                Path.GetRandomFileName());
            trustedFileNameForDisplay = String.Format("{0}_{1}",
                Guid.NewGuid(),
                WebUtility.HtmlEncode(model.FormFile.FileName));

            Directory.CreateDirectory(trustedFilePathForStorage);
            using (var targetStream = System.IO.File.Create(
                        Path.Combine(trustedFilePathForStorage, trustedFileNameForDisplay)))
            {
                await targetStream.WriteAsync(streamedFilePhysicalContent);

                //_logger.LogInformation(
                //    "Uploaded file '{TrustedFileNameForDisplay}' saved to " +
                //    "'{TargetFilePath}' as {TrustedFileNameForFileStorage}",
                //    trustedFileNameForDisplay, trustedFilePathForStorage,
                //    trustedFileNameForDisplay);
            }

            // TODO: Add insert logic here
            ClamSectionTVShowCategory result = new ClamSectionTVShowCategory
            {
                Genre = model.Genre,
                ItemPath = Path.Combine(trustedFilePathForStorage, trustedFileNameForDisplay)
            };
            await _context.ClamSectionTVShowCategories.AddAsync(result);
            Task.WaitAll(_context.SaveChangesAsync());
        }

        public async Task AddTVShow(Guid id, SectionTVShowSubCategory model)
        {
            var trustedFileNameForDisplay = string.Empty;
            var trustedFilePathForStorage = string.Empty;
            var streamedFilePhysicalContent = new byte[0];

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Genre",
                $"The request couldn't be processed (Error 1).");
                // Log error

            }

            streamedFilePhysicalContent =
           await FileHelpers.ProcessFormFile<StreamFileUploadDatabase>(
               model.FormFile, ModelState, _permittedExtentions,
               _fileSizeLimit);

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Genre",
                $"The request couldn't be processed (Error 1).");
                // Log error

            }

            trustedFilePathForStorage = String.Format("{0}\\{1}\\{2}",
                _targetImagePath,
                Guid.NewGuid().ToString(),
                Path.GetRandomFileName());
            trustedFileNameForDisplay = String.Format("{0}_{1}",
                Guid.NewGuid(),
                WebUtility.HtmlEncode(model.FormFile.FileName));

            Directory.CreateDirectory(trustedFilePathForStorage);
            using (var targetStream = System.IO.File.Create(
                        Path.Combine(trustedFilePathForStorage, trustedFileNameForDisplay)))
            {
                await targetStream.WriteAsync(streamedFilePhysicalContent);

                //_logger.LogInformation(
                //    "Uploaded file '{TrustedFileNameForDisplay}' saved to " +
                //    "'{TargetFilePath}' as {TrustedFileNameForFileStorage}",
                //    trustedFileNameForDisplay, trustedFilePathForStorage,
                //    trustedFileNameForDisplay);
            }

            var filterSeasons = _context.ClamSectionTVShowSubCategorySeasons.ToList();
            ClamSectionTVShowSubCategory test = new ClamSectionTVShowSubCategory
            {
                CategoryId = id,
                TVShowTitle = model.TVShowTitle,
                ItemPath = Path.Combine(trustedFilePathForStorage, trustedFileNameForDisplay),
                TVShowSeasonNumberTotal = filterSeasons.Select(x => x.TVShowId).Where(x => x.Equals(id)).Count()
            };
            await _context.ClamSectionTVShowSubCategories.AddAsync(test);
            Task.WaitAll(_context.SaveChangesAsync());
        }

        public async Task AddTVShowSeason(Guid id, SectionTVShowSubCategorySeason model)
        {
            var showImagePath = _context.ClamSectionTVShowSubCategories.Find(model.TVShowId);
            ClamSectionTVShowSubCategorySeason result = new ClamSectionTVShowSubCategorySeason
            {
                CategoryId = id,
                TVShowId = model.TVShowId,
                ItemPath = showImagePath.ItemPath,
                TVShowSeasonNumber = model.TVShowSeasonNumber
            };
            await _context.Set<ClamSectionTVShowSubCategorySeason>().AddAsync(result);
            Task.WaitAll(_context.SaveChangesAsync());
        }

        public async Task<IEnumerable<SectionTVShowCategory>> GetAllGenres()
        {
            var genres = await _context.ClamSectionTVShowCategories.ToListAsync();
            var shows = await _context.ClamSectionTVShowSubCategories.ToListAsync();
            var seasons = await _context.ClamSectionTVShowSubCategorySeasons.ToListAsync();
            var episodes = await _context.ClamSectionTVShowSubCategorySeasonItems.ToListAsync();

            List<SectionTVShowCategory> model = new List<SectionTVShowCategory>();
            foreach (var item in genres)
            {
                var idGrab = item.CategoryId;
                model.Add(new SectionTVShowCategory()
                {
                    CategoryId = item.CategoryId,
                    Genre = item.Genre,
                    ItemPath = FilePathUrlHelper.DataFilePathFilter(item.ItemPath, 3),
                    //ItemPath = FilePathUrlHelper.DirectoryFilter(item.ItemPath, _data, _rootDir),
                    LastModified = item.LastModified,
                    DateCreated = item.DateCreated,
                    UrlCategory = FilePathUrlHelper.UrlString(item.Genre),
                    SubCategoryCount = shows.Select(x => x.CategoryId).Where(x => x.Equals(idGrab)).Count(),
                    SubCategorySeasonCount = seasons.Select(x => x.CategoryId).Where(x => x.Equals(idGrab)).Count(),
                    SubCategorySeasonItemCount = episodes.Select(x => x.CategoryId).Where(x => x.Equals(idGrab)).Count()
                });
            }
            return model;
        }

        public async Task<SectionTVShowSubCategorySeasonItem> GetEpisode(Guid id)
        {
            var model = await _context.ClamSectionTVShowSubCategorySeasonItems.FindAsync(id);
            return _mapper.Map<SectionTVShowSubCategorySeasonItem>(model);
        }

        public async Task<SectionTVShowCategory> GetGenre(Guid id)
        {
            var shows = await _context.ClamSectionTVShowSubCategories.ToListAsync();
            var seasons = await _context.ClamSectionTVShowSubCategorySeasons.ToListAsync();
            var episodes = await _context.ClamSectionTVShowSubCategorySeasonItems.ToListAsync();

            var model = await _context.ClamSectionTVShowCategories.FindAsync(id);

            SectionTVShowCategory retrieveModel = new SectionTVShowCategory()
            {
                CategoryId = model.CategoryId,
                Genre = model.Genre,
                ItemPath = model.ItemPath,
                LastModified = model.LastModified,
                DateCreated = model.DateCreated,
                SubCategoryCount = shows.Select(x => x.CategoryId).Where(x => x.Equals(id)).Count(),
                SubCategorySeasonCount = seasons.Select(x => x.CategoryId).Where(x => x.Equals(id)).Count(),
                SubCategorySeasonItemCount = episodes.Select(x => x.CategoryId).Where(x => x.Equals(id)).Count()
            };
            return retrieveModel;
        }

        public async Task<IEnumerable<SectionTVShowSubCategory>> GetGenreTVShows(Guid id)
        {
            var model = _context.Set<ClamSectionTVShowSubCategory>().Any(x => x.CategoryId.Equals(id));
            List<SectionTVShowSubCategory> list = new List<SectionTVShowSubCategory>();
            if (model == true)
            {
                var genre = await _context.ClamSectionTVShowCategories.FindAsync(id);
                var capture = _context.Set<ClamSectionTVShowCategory>().Select(x => x.ClamSectionTVShowSubCategories
                .Where(a => a.CategoryId.Equals(id)).ToList());
                var filterSeasons = _context.ClamSectionTVShowSubCategorySeasons.ToList();
                var filterSeasonEpisodes = _context.ClamSectionTVShowSubCategorySeasonItems.ToList();

                foreach (var item in capture)
                {
                    foreach (var content in item)
                    {
                        var TVShowId = content.TVShowId;
                        list.Add(new SectionTVShowSubCategory()
                        {
                            TVShowId = content.TVShowId,
                            TVShowTitle = content.TVShowTitle,
                            TVShowSeasonNumberTotal = content.TVShowSeasonNumberTotal,
                            ItemPath = FilePathUrlHelper.DataFilePathFilter(content.ItemPath, 3),
                            LastModified = content.LastModified,
                            DateCreated = content.DateCreated,
                            CategoryId = content.CategoryId,
                            UrlCategory = FilePathUrlHelper.UrlString(genre.Genre),
                            UrlSection = FilePathUrlHelper.UrlString(content.TVShowTitle),
                            SubCategorySeasonCount = filterSeasons.Select(x => x.TVShowId).Where(x => x.Equals(TVShowId)).Count(),
                            SubCategorySeasonItemCount = filterSeasonEpisodes.Select(x => x.TVShowId).Where(x => x.Equals(TVShowId)).Count()

                        });
                    }
                }
                return list;
            }
            return list;
        }

        public async Task<SectionTVShowSubCategorySeason> GetSeason(Guid id)
        {
            var model = await _context.ClamSectionTVShowSubCategorySeasons.FindAsync(id);
            return _mapper.Map<SectionTVShowSubCategorySeason>(model);
        }

        public async Task<StreamTVShowFileUploadDatabase> GetSeasonEpisodes(Guid id, Guid show, Guid season)
        {
            var seasonSelect = await _context.ClamSectionTVShowSubCategorySeasons.FindAsync(season);
            var showSelect = await _context.ClamSectionTVShowSubCategories.FindAsync(show);
            var genreSelect = await _context.ClamSectionTVShowCategories.FindAsync(id);

            var model = await _context.ClamSectionTVShowSubCategorySeasonItems.AsNoTracking().ToListAsync();
            List<SectionTVShowSubCategorySeasonItem> result = new List<SectionTVShowSubCategorySeasonItem>();
            foreach (var item in model)
            {
                if (item.CategoryId == id && item.TVShowId == show && item.SeasonId == season)
                {
                    result.Add(new SectionTVShowSubCategorySeasonItem()
                    {
                        ItemId = item.ItemId,
                        ItemPath = item.ItemPath,
                        ItemTitle = FilePathUrlHelper.GetFileName(item.ItemTitle),
                        Size = item.Size,
                        LastModified = item.LastModified,
                        DateCreated = item.DateCreated,
                        CategoryId = item.CategoryId,
                        TVShowId = item.TVShowId,
                        SeasonId = item.SeasonId,
                        UrlCategory = FilePathUrlHelper.UrlString(genreSelect.Genre),
                        UrlSection = FilePathUrlHelper.UrlString(showSelect.TVShowTitle),
                        UrlSubSection = seasonSelect.TVShowSeasonNumber.ToString(),
                        UrlSubSectionItem = FilePathUrlHelper.UrlString(FilePathUrlHelper.GetFileName(item.ItemTitle))
                    });
                }
            }
            StreamTVShowFileUploadDatabase episodes = new StreamTVShowFileUploadDatabase() { Episodes = result };
            return episodes;
        }

        public async Task<SectionTVShowSubCategory> GetTVShow(Guid id)
        {
            var filterSeasons = await _context.ClamSectionTVShowSubCategorySeasons.ToListAsync();
            var filterSeasonEpisodes = await _context.ClamSectionTVShowSubCategorySeasonItems.ToListAsync();
            var model = await _context.ClamSectionTVShowSubCategories.FindAsync(id);

            SectionTVShowSubCategory retrieveModel = new SectionTVShowSubCategory()
            {
                TVShowId = model.TVShowId,
                TVShowTitle = model.TVShowTitle,
                TVShowSeasonNumberTotal = model.TVShowSeasonNumberTotal,
                ItemPath = model.ItemPath,
                LastModified = model.LastModified,
                DateCreated = model.DateCreated,
                CategoryId = model.CategoryId,
                SubCategorySeasonCount = filterSeasons.Select(x => x.TVShowId).Where(x => x.Equals(id)).Count(),
                SubCategorySeasonItemCount = filterSeasonEpisodes.Select(x => x.TVShowId).Where(x => x.Equals(id)).Count()
            };
            return retrieveModel;
        }

        public async Task<IEnumerable<SectionTVShowSubCategorySeason>> GetTVShowSeasons(Guid id, Guid show)
        {
            var model = await _context.ClamSectionTVShowSubCategorySeasons.AsNoTracking().ToListAsync();
            var episodes = await _context.ClamSectionTVShowSubCategorySeasonItems.AsNoTracking().ToListAsync();
            var listTitleNames = await _context.ClamSectionTVShowSubCategories.AsNoTracking().ToListAsync();

            var showSelect = await _context.ClamSectionTVShowSubCategories.FindAsync(show);
            var genreSelect = await _context.ClamSectionTVShowCategories.FindAsync(id);

            List<SectionTVShowSubCategorySeason> result = new List<SectionTVShowSubCategorySeason>();
            foreach (var item in model)
            {
                if (item.TVShowId == show && item.CategoryId == id)
                {
                    var idGrab = item.SeasonId;
                    result.Add(new SectionTVShowSubCategorySeason()
                    {
                        SeasonId = item.SeasonId,
                        TVShowSeasonNumber = item.TVShowSeasonNumber,
                        ItemPath = FilePathUrlHelper.DataFilePathFilter(item.ItemPath, 3),
                        LastModified = item.LastModified,
                        DateCreated = item.DateCreated,
                        CategoryId = item.CategoryId,
                        TVShowId = item.TVShowId,
                        UrlCategory = FilePathUrlHelper.UrlString(genreSelect.Genre),
                        UrlSection = FilePathUrlHelper.UrlString(showSelect.TVShowTitle),
                        UrlSubSection = item.TVShowSeasonNumber.ToString(),
                        SubCategorySeasonItemCount = episodes.Select(x => x.SeasonId).Where(x => x.Equals(idGrab)).Count()
                    });
                }
            }
            return result;
        }

        public async Task RemoveEpisode(Guid id)
        {
            var requestFile = await GetEpisode(id);
            int index = requestFile.ItemPath.LastIndexOf(@"\");
            System.IO.File.Delete(requestFile.ItemPath);
            Directory.Delete(requestFile.ItemPath.Substring(0, index));
            var model = _context.ClamSectionTVShowSubCategorySeasonItems.Find(id);
            _context.ClamSectionTVShowSubCategorySeasonItems.Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveGenre(Guid id, SectionTVShowCategory model)
        {
            var fullDirectoryPath = string.Empty;
            fullDirectoryPath = string.Format("{0}\\{1}",
                _targetFolderPath,
                model.CategoryId.ToString());
            var result = await _context.ClamSectionTVShowCategories.FindAsync(id);

            var collectEpisodes = _context.ClamSectionTVShowSubCategorySeasonItems.AsNoTracking();
            var collectSeasons = _context.ClamSectionTVShowSubCategorySeasons.AsNoTracking();
            var collectShows = _context.ClamSectionTVShowSubCategories.AsNoTracking();
            List<ClamSectionTVShowSubCategory> shows = new List<ClamSectionTVShowSubCategory>();
            List<ClamSectionTVShowSubCategorySeason> seasons = new List<ClamSectionTVShowSubCategorySeason>();
            List<ClamSectionTVShowSubCategorySeasonItem> seasonItems = new List<ClamSectionTVShowSubCategorySeasonItem>();
            if (collectEpisodes.Select(x => x.CategoryId).Where(x => x.Equals(id)).Count() > 0)
            {
                foreach (var item in collectEpisodes)
                {
                    if (item.CategoryId == model.CategoryId)
                    {
                        seasonItems.Add(new ClamSectionTVShowSubCategorySeasonItem()
                        {
                            ItemId = item.ItemId,
                            CategoryId = model.CategoryId,
                            TVShowId = item.TVShowId,
                            SeasonId = item.SeasonId
                        });

                        if (!seasons.Any(x => x.SeasonId == item.SeasonId))
                        {
                            seasons.Add(new ClamSectionTVShowSubCategorySeason()
                            {
                                TVShowId = item.TVShowId,
                                CategoryId = model.CategoryId,
                                SeasonId = item.SeasonId,
                            });
                        }
                    }
                }
            }
            if (collectSeasons.Select(x => x.CategoryId).Where(x => x.Equals(id)).Count() > 0)
            {
                foreach (var item in collectSeasons)
                {
                    if (item.CategoryId == model.CategoryId)
                    {
                        if (!seasons.Any(x => x.SeasonId == item.SeasonId))
                        {
                            seasons.Add(new ClamSectionTVShowSubCategorySeason()
                            {
                                TVShowId = item.TVShowId,
                                CategoryId = model.CategoryId,
                                SeasonId = item.SeasonId,
                            });
                        }
                    }
                }
            }
            if (collectShows.Select(x => x.CategoryId).Where(x => x.Equals(id)).Count() > 0)
            {
                foreach (var item in collectShows)
                {
                    if (item.CategoryId == model.CategoryId)
                    {
                        if (!shows.Any(x => x.TVShowId == item.TVShowId))
                        {
                            shows.Add(new ClamSectionTVShowSubCategory()
                            {
                                TVShowId = item.TVShowId,
                                CategoryId = model.CategoryId,
                                ItemPath = item.ItemPath
                            });
                        }
                    }
                }
            }

            var tvShowCompletePath = string.Empty;
            if (!String.IsNullOrEmpty(model.ItemPath))
            {
                tvShowCompletePath = model.ItemPath.Substring(0, FilePathUrlHelper.DataFilePathFilterIndex(
                    model.ItemPath, 4));
            }

            if (shows.Count != 0)
            {
                foreach (var subDirectory in shows)
                {
                    var subPath = subDirectory.ItemPath.Substring(0, FilePathUrlHelper.DataFilePathFilterIndex(
                        subDirectory.ItemPath, 4));
                    if (Directory.Exists(subPath))
                    {
                        Directory.Delete(subPath, true);
                    }
                }
            }

            if (Directory.Exists(tvShowCompletePath))
            {
                Directory.Delete(tvShowCompletePath, true);
            }

            _context.ClamSectionTVShowSubCategorySeasonItems.RemoveRange(seasonItems);
            _context.ClamSectionTVShowSubCategorySeasons.RemoveRange(seasons);
            _context.ClamSectionTVShowSubCategories.RemoveRange(shows);
            if (Directory.Exists(fullDirectoryPath))
            {
                Directory.Delete(fullDirectoryPath, true);
            }
            _context.ClamSectionTVShowCategories.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveMultipleEpisodes(SectionTVShowSubCategory model)
        {
            var collectEpisodes = _context.ClamSectionTVShowSubCategorySeasonItems.AsNoTracking().ToList();
            //List<ClamSectionTVShowSubCategorySeason> seasons = new List<ClamSectionTVShowSubCategorySeason>();
            List<ClamSectionTVShowSubCategorySeasonItem> seasonItems = new List<ClamSectionTVShowSubCategorySeasonItem>();
            foreach (var item in collectEpisodes)
            {
                if (item.TVShowId == model.TVShowId && item.CategoryId == model.CategoryId)
                {
                    seasonItems.Add(new ClamSectionTVShowSubCategorySeasonItem()
                    {
                        ItemId = item.ItemId,
                        CategoryId = model.CategoryId,
                        TVShowId = model.TVShowId,
                        SeasonId = item.SeasonId
                    });
                }
            }
            if (seasonItems.Count != 0)
            {
                _context.ClamSectionTVShowSubCategorySeasonItems.RemoveRange(seasonItems);
                await _context.SaveChangesAsync();
            }

        }

        public async Task RemoveMultipleSeasons(SectionTVShowSubCategory model)
        {
            var collectSeasons = _context.ClamSectionTVShowSubCategorySeasons.AsNoTracking().ToList();
            List<ClamSectionTVShowSubCategorySeason> seasons = new List<ClamSectionTVShowSubCategorySeason>();
            foreach (var season in collectSeasons)
            {
                if (season.CategoryId == model.CategoryId && season.TVShowId == model.TVShowId)
                {
                    seasons.Add(new ClamSectionTVShowSubCategorySeason()
                    {
                        TVShowId = season.TVShowId,
                        CategoryId = season.CategoryId,
                        SeasonId = season.SeasonId
                    });
                }
            }
            if (seasons.Count != 0)
            {
                _context.ClamSectionTVShowSubCategorySeasons.RemoveRange(seasons);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveTVShow(Guid id, SectionTVShowSubCategory model)
        {
            var fullDirectoryPath = string.Empty;
            fullDirectoryPath = string.Format("{0}\\{1}\\{2}",
                _targetFolderPath,
                model.CategoryId.ToString(),
                model.TVShowId.ToString());
            // TODO: Add delete logic here
            var result = await _context.ClamSectionTVShowSubCategories.AsNoTracking()
                .FirstOrDefaultAsync(x => x.TVShowId == id);

            var tvShowCompletePath = string.Empty;
            if (!String.IsNullOrEmpty(model.ItemPath))
            {
                tvShowCompletePath = model.ItemPath.Substring(0, FilePathUrlHelper.DataFilePathFilterIndex(
                    model.ItemPath, 4));
            }
            if (Directory.Exists(tvShowCompletePath))
            {
                Directory.Delete(tvShowCompletePath, true);
            }
            if (Directory.Exists(fullDirectoryPath))
            {
                Directory.Delete(fullDirectoryPath, true);
            }
            await RemoveMultipleEpisodes(model);
            await RemoveMultipleSeasons(model);
            _context.ClamSectionTVShowSubCategories.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveTVShowSeason(SectionTVShowSubCategorySeason model)
        {
            var fullDirectoryPath = string.Empty;
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("TV Show Season",
                $"The request couldn't be processed (Error 1).");
                // Log error
            }

            // TODO: Add delete logic here
            fullDirectoryPath = string.Format("{0}\\{1}\\{2}\\{3}",
                _targetFolderPath,
                model.CategoryId.ToString(),
                model.TVShowId.ToString(),
                model.SeasonId.ToString());

            // Completed Implementation
            var result = await _context.ClamSectionTVShowSubCategorySeasons.FindAsync(model.SeasonId);
            var collectEpisodes = _context.ClamSectionTVShowSubCategorySeasonItems.AsNoTracking();
            List<ClamSectionTVShowSubCategorySeasonItem> seasonItems = new List<ClamSectionTVShowSubCategorySeasonItem>();
            foreach (var item in collectEpisodes)
            {
                if (item.SeasonId == model.SeasonId && item.TVShowId == model.TVShowId && item.CategoryId == model.CategoryId)
                {
                    seasonItems.Add(new ClamSectionTVShowSubCategorySeasonItem()
                    {
                        ItemId = item.ItemId,
                        CategoryId = model.CategoryId,
                        TVShowId = model.TVShowId,
                        SeasonId = model.SeasonId
                    });
                }
            }
            _context.Set<ClamSectionTVShowSubCategorySeasonItem>().RemoveRange(seasonItems);
            if (Directory.Exists(fullDirectoryPath))
            {
                Directory.Delete(fullDirectoryPath, true);
            }
            _context.ClamSectionTVShowSubCategorySeasons.Remove(result);
            Task.WaitAll(_context.SaveChangesAsync());
        }

        public async Task UpdateGenre(Guid id, SectionTVShowCategory model)
        {
            var trustedFileNameForDisplay = string.Empty;
            var trustedFilePathForStorage = string.Empty;
            var streamedFilePhysicalContent = new byte[0];

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Genre",
                $"The request couldn't be processed (Error 1).");
                // Log error

            }

            streamedFilePhysicalContent =
           await FileHelpers.ProcessFormFile<StreamFileUploadDatabase>(
               model.FormFile, ModelState, _permittedExtentions,
               _fileSizeLimit);

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Genre",
                $"The request couldn't be processed (Error 1).");
                // Log error


            }

            var result = _context.Set<ClamSectionTVShowCategory>().Find(id);
            if (Directory.Exists(FilePathUrlHelper.GetFileDirectoryPath(result.ItemPath)))
            {
                System.IO.File.Delete(result.ItemPath);
            }

            trustedFilePathForStorage = String.Format("{0}\\{1}\\{2}",
                _targetImagePath,
                Guid.NewGuid().ToString(),
                Path.GetRandomFileName());
            trustedFileNameForDisplay = String.Format("{0}_{1}",
                Guid.NewGuid(),
                WebUtility.HtmlEncode(model.FormFile.FileName));

            Directory.CreateDirectory(trustedFilePathForStorage);
            using (var targetStream = System.IO.File.Create(
                        Path.Combine(trustedFilePathForStorage, trustedFileNameForDisplay)))
            {
                await targetStream.WriteAsync(streamedFilePhysicalContent);

                //_logger.LogInformation(
                //    "Uploaded file '{TrustedFileNameForDisplay}' saved to " +
                //    "'{TargetFilePath}' as {TrustedFileNameForFileStorage}",
                //    trustedFileNameForDisplay, trustedFilePathForStorage,
                //    trustedFileNameForDisplay);
            }

            // TODO: Add update logic here
            var entity = await _context.ClamSectionTVShowCategories.FindAsync(id);
            _context.Entry(entity).Entity.Genre = model.Genre;
            _context.Entry(entity).Entity.ItemPath = Path.Combine(trustedFilePathForStorage, trustedFileNameForDisplay);
            _context.Entry(entity).Entity.LastModified = DateTime.Now;
            _context.Entry(entity).State = EntityState.Modified;
            _context.Update(entity);

            Task.WaitAll(_context.SaveChangesAsync());
        }

        public async Task UpdateTVShow(Guid id, SectionTVShowSubCategory model)
        {
            var trustedFileNameForDisplay = string.Empty;
            var trustedFilePathForStorage = string.Empty;
            var streamedFilePhysicalContent = new byte[0];

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Genre",
                $"The request couldn't be processed (Error 1).");
                // Log error

            }

            if (model.FormFile != null)
            {
                streamedFilePhysicalContent =
               await FileHelpers.ProcessFormFile<StreamFileUploadDatabase>(
                   model.FormFile, ModelState, _permittedExtentions,
                   _fileSizeLimit);
            }

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Genre",
                $"The request couldn't be processed (Error 1).");
                // Log error

            }

            var result = await _context.ClamSectionTVShowSubCategories.FindAsync(id);
            if (Directory.Exists(FilePathUrlHelper.GetFileDirectoryPath(result.ItemPath)))
            {
                System.IO.File.Delete(result.ItemPath);
            }

            trustedFilePathForStorage = String.Format("{0}\\{1}\\{2}",
                _targetImagePath,
                Guid.NewGuid().ToString(),
                Path.GetRandomFileName());
            trustedFileNameForDisplay = String.Format("{0}_{1}",
                Guid.NewGuid(),
                WebUtility.HtmlEncode(model.FormFile.FileName));

            Directory.CreateDirectory(trustedFilePathForStorage);
            using (var targetStream = System.IO.File.Create(
                        Path.Combine(trustedFilePathForStorage, trustedFileNameForDisplay)))
            {
                await targetStream.WriteAsync(streamedFilePhysicalContent);
            }


            var entity = _context.Set<ClamSectionTVShowSubCategory>().Find(id);
            _context.Entry(entity).Entity.TVShowTitle = model.TVShowTitle;
            _context.Entry(entity).Entity.TVShowSeasonNumberTotal = model.TVShowSeasonNumberTotal;
            _context.Entry(entity).Entity.ItemPath = Path.Combine(trustedFilePathForStorage, trustedFileNameForDisplay);
            _context.Entry(entity).Entity.LastModified = DateTime.Now;
            _context.Entry(entity).State = EntityState.Modified;
            _context.Update(entity);
            Task.WaitAll(_context.SaveChangesAsync());
        }

        public async Task UpdateTVShowSeason(SectionTVShowSubCategorySeason model)
        {
            var captureModel = await _context.ClamSectionTVShowSubCategorySeasons.FindAsync(model.SeasonId);
            _context.Entry(captureModel).Entity.TVShowSeasonNumber = model.TVShowSeasonNumber;
            _context.Entry(captureModel).Entity.LastModified = DateTime.Now;
            _context.Entry(captureModel).State = EntityState.Modified;
            _context.Update(captureModel);
            Task.WaitAll(_context.SaveChangesAsync());
        }
    }
}
