using Clam.Areas.TVShows.Models;
using ClamDataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clam.Interface.TVShow
{
    public interface ITVShowRepository
    {
        // Genres
        Task<IEnumerable<SectionTVShowCategory>> GetAllGenres();
        Task<SectionTVShowCategory> GetGenre(Guid id);
        Task AddGenre(SectionTVShowCategory model);
        Task AddAsyncGenre(SectionTVShowCategory model);
        Task UpdateGenre(Guid id, SectionTVShowCategory model);
        Task RemoveGenre(Guid id, SectionTVShowCategory model);

        // TVShows
        Task<IEnumerable<SectionTVShowSubCategory>> GetGenreTVShows(Guid id);
        Task AddTVShow(Guid id, SectionTVShowSubCategory model);
        Task AddAsyncTVShow(Guid id, SectionTVShowSubCategory model);
        Task<SectionTVShowSubCategory> GetTVShow(Guid id);
        Task UpdateTVShow(Guid id, SectionTVShowSubCategory model);
        Task RemoveTVShow(Guid id, SectionTVShowSubCategory model);

        // Seasons
        Task<IEnumerable<SectionTVShowSubCategorySeason>> GetTVShowSeasons(Guid id, Guid show);
        Task AddTVShowSeason(Guid id, SectionTVShowSubCategorySeason model);
        Task<SectionTVShowSubCategorySeason> GetSeason(Guid id);
        Task UpdateTVShowSeason(SectionTVShowSubCategorySeason model);
        Task RemoveTVShowSeason(SectionTVShowSubCategorySeason model);

        // Episodes & Video
        Task<StreamTVShowFileUploadDatabase> GetSeasonEpisodes(Guid id, Guid show, Guid season);
        Task<SectionTVShowSubCategorySeasonItem> GetEpisode(Guid id);
        Task RemoveEpisode(Guid id);

        // Remove Test Functions
        Task RemoveMultipleEpisodes(SectionTVShowSubCategory filter);
        Task RemoveMultipleSeasons(SectionTVShowSubCategory filter);
    }
}
