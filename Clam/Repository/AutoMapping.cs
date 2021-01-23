using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clam.Models;
using ClamDataLibrary.Models;
using AutoMapper;

namespace Clam.Repository
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            // Models Here are located in main directory {Prefer to move relevant controllers and models to areas if possible}

            // Accounts & Roles
            CreateMap<ClamDataLibrary.Models.ClamUserAccountRegister, Clam.Models.UserAccountRegister>();
            CreateMap<Clam.Models.UserAccountRegister, ClamDataLibrary.Models.ClamUserAccountRegister>();

            CreateMap<Clam.Models.RoleAccountUsers, ClamDataLibrary.Models.ClamRoles>();
            CreateMap<ClamDataLibrary.Models.ClamRoles, Clam.Models.RoleAccountUsers>();

            CreateMap<ClamDataLibrary.Models.ClamUserAccountRegister, ClamDataLibrary.Models.ClamRoles>();
            CreateMap<ClamDataLibrary.Models.ClamRoles, ClamDataLibrary.Models.ClamUserAccountRegister>();

            CreateMap<Clam.Models.UserAccountRegister, ClamDataLibrary.Models.ClamRoles>();
            CreateMap<ClamDataLibrary.Models.ClamRoles, Clam.Models.UserAccountRegister>();

            CreateMap<Clam.Models.UserAccountInformation, Clam.Models.UserAccountRegister>();
            CreateMap<Clam.Models.UserAccountRegister, Clam.Models.UserAccountInformation>();

            CreateMap<Clam.Models.UserAccountInformation, ClamDataLibrary.Models.ClamUserAccountRegister>();
            CreateMap<ClamDataLibrary.Models.ClamUserAccountRegister, Clam.Models.UserAccountInformation>();

            // TV Shows
            //CreateMap<Clam.Models.SectionTVShowCategory, ClamDataLibrary.Models.ClamSectionTVShowCategory>();
            //CreateMap<ClamDataLibrary.Models.ClamSectionTVShowCategory, Clam.Models.SectionTVShowCategory>();

            //CreateMap<Clam.Models.SectionTVShowSubCategory, ClamDataLibrary.Models.ClamSectionTVShowSubCategory>();
            //CreateMap<ClamDataLibrary.Models.ClamSectionTVShowSubCategory, Clam.Models.SectionTVShowSubCategory>();

            //CreateMap<Clam.Models.SectionTVShowSubCategorySeason, ClamDataLibrary.Models.ClamSectionTVShowSubCategorySeason>();
            //CreateMap<ClamDataLibrary.Models.ClamSectionTVShowSubCategorySeason, Clam.Models.SectionTVShowSubCategorySeason>();

            //CreateMap<Clam.Models.SectionTVShowSubCategorySeasonItem, ClamDataLibrary.Models.ClamSectionTVShowSubCategorySeasonItem>();
            //CreateMap<ClamDataLibrary.Models.ClamSectionTVShowSubCategorySeasonItem, Clam.Models.SectionTVShowSubCategorySeasonItem>();


            // Areas -- Below

            // Academia
            CreateMap<Clam.Areas.Academia.Models.SectionAcademicRegister, ClamDataLibrary.Models.ClamSectionAcademicCategory>();
            CreateMap<ClamDataLibrary.Models.ClamSectionAcademicCategory, Clam.Areas.Academia.Models.SectionAcademicRegister>();

            CreateMap<Clam.Areas.Academia.Models.SectionRegister, ClamDataLibrary.Models.ClamSectionAcademicSubCategory>();
            CreateMap<ClamDataLibrary.Models.ClamSectionAcademicSubCategory, Clam.Areas.Academia.Models.SectionRegister>();

            CreateMap<Clam.Areas.Academia.Models.SectionItem, ClamDataLibrary.Models.ClamSectionAcademicSubCategoryItem>();
            CreateMap<ClamDataLibrary.Models.ClamSectionAcademicSubCategoryItem, Clam.Areas.Academia.Models.SectionItem>();

            CreateMap<Clam.Areas.Academia.Models.AllSectionItems, ClamDataLibrary.Models.ClamSectionAcademicSubCategoryItem>();
            CreateMap<ClamDataLibrary.Models.ClamSectionAcademicSubCategoryItem, Clam.Areas.Academia.Models.AllSectionItems>();

            // Clamflix
            CreateMap<Clam.Areas.Clamflix.Models.AreaFilmflix, ClamDataLibrary.Models.ClamUserFilm>();
            CreateMap<ClamDataLibrary.Models.ClamUserFilm, Clam.Areas.Clamflix.Models.AreaFilmflix>();

            CreateMap<Clam.Areas.Clamflix.Models.AreaFilmflixCategory, ClamDataLibrary.Models.ClamUserFilmCategory>();
            CreateMap<ClamDataLibrary.Models.ClamUserFilmCategory, Clam.Areas.Clamflix.Models.AreaFilmflixCategory>();

            CreateMap<Clam.Areas.Clamflix.Models.StreamEditModelFilmflixDisplay, ClamDataLibrary.Models.ClamUserFilm>();
            CreateMap<ClamDataLibrary.Models.ClamUserFilm, Clam.Areas.Clamflix.Models.StreamEditModelFilmflixDisplay>();

            CreateMap<Clam.Areas.Clamflix.Models.StreamEditModelFilmflixDisplay, Clam.Areas.Clamflix.Models.AreaFilmflix>();
            CreateMap<Clam.Areas.Clamflix.Models.AreaFilmflix, Clam.Areas.Clamflix.Models.StreamEditModelFilmflixDisplay>();

            CreateMap<Clam.Areas.Clamflix.Models.AreaFilmflixJoinCategory, ClamDataLibrary.Models.ClamUserFilmJoinCategory>();
            CreateMap<ClamDataLibrary.Models.ClamUserFilmJoinCategory, Clam.Areas.Clamflix.Models.AreaFilmflixJoinCategory>();

            // Music
            CreateMap<Clam.Areas.Music.Models.AreaUserMusic, ClamDataLibrary.Models.ClamUserMusic>();
            CreateMap<ClamDataLibrary.Models.ClamUserMusic, Clam.Areas.Music.Models.AreaUserMusic>();

            CreateMap<Clam.Areas.Music.Models.AreaUserMusicCategory, ClamDataLibrary.Models.ClamUserMusicCategory>();
            CreateMap<ClamDataLibrary.Models.ClamUserMusicCategory, Clam.Areas.Music.Models.AreaUserMusicCategory>();

            CreateMap<Clam.Areas.Music.Models.AreaUserMusicJoinCategory, ClamDataLibrary.Models.ClamUserMusicJoinCategory>();
            CreateMap<ClamDataLibrary.Models.ClamUserMusicJoinCategory, Clam.Areas.Music.Models.AreaUserMusicJoinCategory>();

            CreateMap<Clam.Areas.Music.Models.StreamFormDataMusic, Clam.Areas.Music.Models.AreaUserMusic>();
            CreateMap<Clam.Areas.Music.Models.AreaUserMusic, Clam.Areas.Music.Models.StreamFormDataMusic>();

            // Ebooks
            CreateMap<Clam.Areas.EBooks.Models.AreaUserBooks, ClamDataLibrary.Models.ClamUserBooks>();
            CreateMap<ClamDataLibrary.Models.ClamUserBooks, Clam.Areas.EBooks.Models.AreaUserBooks>();

            CreateMap<Clam.Areas.EBooks.Models.AreaUserBooksCategory, ClamDataLibrary.Models.ClamUserBooksCategory>();
            CreateMap<ClamDataLibrary.Models.ClamUserBooksCategory, Clam.Areas.EBooks.Models.AreaUserBooksCategory>();

            CreateMap<Clam.Areas.EBooks.Models.AreaUserBooksJoinCategory, ClamDataLibrary.Models.ClamUserBooksJoinCategory>();
            CreateMap<ClamDataLibrary.Models.ClamUserBooksJoinCategory, Clam.Areas.EBooks.Models.AreaUserBooksJoinCategory>();

            CreateMap<Clam.Areas.EBooks.Models.ReadBook, ClamDataLibrary.Models.ClamUserBooks>();
            CreateMap<ClamDataLibrary.Models.ClamUserBooks, Clam.Areas.EBooks.Models.ReadBook>();

            CreateMap<Clam.Areas.EBooks.Models.StreamFormDataBooks, Clam.Areas.EBooks.Models.AreaUserBooks>();
            CreateMap<Clam.Areas.EBooks.Models.AreaUserBooks, Clam.Areas.EBooks.Models.StreamFormDataBooks>();

            // Projects
            CreateMap<Clam.Areas.Projects.Models.AreaUserProjects, ClamDataLibrary.Models.ClamUserProjects>();
            CreateMap<ClamDataLibrary.Models.ClamUserProjects, Clam.Areas.Projects.Models.AreaUserProjects>();

            CreateMap<Clam.Areas.Projects.Models.AreaUserProjectsImageInterests, ClamDataLibrary.Models.ClamProjectInterestsImageDisplay>();
            CreateMap<ClamDataLibrary.Models.ClamProjectInterestsImageDisplay, Clam.Areas.Projects.Models.AreaUserProjectsImageInterests>();

            // Storage
            CreateMap<Clam.Areas.Storage.Models.AreaUserPersonalCategoryItems, ClamDataLibrary.Models.ClamUserPersonalCategoryItem>();
            CreateMap<ClamDataLibrary.Models.ClamUserPersonalCategoryItem, Clam.Areas.Storage.Models.AreaUserPersonalCategoryItems>();

            // Tickets
            CreateMap<Clam.Areas.Tickets.Models.AreaUserTicket, ClamDataLibrary.Models.ClamUserSystemTicket>();
            CreateMap<ClamDataLibrary.Models.ClamUserSystemTicket, Clam.Areas.Tickets.Models.AreaUserTicket>();

            // TV Shows
            CreateMap<Clam.Areas.TVShows.Models.SectionTVShowCategory, ClamDataLibrary.Models.ClamSectionTVShowCategory>();
            CreateMap<ClamDataLibrary.Models.ClamSectionTVShowCategory, Clam.Areas.TVShows.Models.SectionTVShowCategory>();

            CreateMap<Clam.Areas.TVShows.Models.SectionTVShowSubCategory, ClamDataLibrary.Models.ClamSectionTVShowSubCategory>();
            CreateMap<ClamDataLibrary.Models.ClamSectionTVShowSubCategory, Clam.Areas.TVShows.Models.SectionTVShowSubCategory>();

            CreateMap<Clam.Areas.TVShows.Models.SectionTVShowSubCategorySeason, ClamDataLibrary.Models.ClamSectionTVShowSubCategorySeason>();
            CreateMap<ClamDataLibrary.Models.ClamSectionTVShowSubCategorySeason, Clam.Areas.TVShows.Models.SectionTVShowSubCategorySeason>();

            CreateMap<Clam.Areas.TVShows.Models.SectionTVShowSubCategorySeasonItem, ClamDataLibrary.Models.ClamSectionTVShowSubCategorySeasonItem>();
            CreateMap<ClamDataLibrary.Models.ClamSectionTVShowSubCategorySeasonItem, Clam.Areas.TVShows.Models.SectionTVShowSubCategorySeasonItem>();

            // Unsupported Mapping
            CreateMap<Clam.Areas.Music.Models.StreamMusicDataUpload, ClamDataLibrary.Models.ClamUserMusic>();
            CreateMap<ClamDataLibrary.Models.ClamUserMusic, Clam.Areas.Music.Models.StreamMusicDataUpload>();
        }
    }
}
