using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clam.Models
{
    public class SectionTVShowCategory
    {

        public SectionTVShowCategory()
        {
            SubCategoryList = new List<SectionTVShowSubCategory>();
            SubCategorySeasonList = new List<SectionTVShowSubCategorySeason>();
            SubCategorySeasonItemList = new List<SectionTVShowSubCategorySeasonItem>();
        }

        [Display(Name = "Genre Code")]
        public Guid CategoryId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Genre")]
        [DataType(DataType.Text)]
        public string Genre { get; set; }


        [MaxLength(250)]
        [DataType(DataType.Text)]
        [Display(Name = "File(Path)")]
        public string ItemPath { get; set; }

        [Required]
        [Display(Name = "File Upload")]
        public IFormFile FormFile { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Last Modified")]
        public DateTime LastModified { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Added")]
        public DateTime DateCreated { get; set; }

        public ICollection<SectionTVShowSubCategory> SubCategoryList { get; set; }

        public ICollection<SectionTVShowSubCategorySeason> SubCategorySeasonList { get; set; }

        public ICollection<SectionTVShowSubCategorySeasonItem> SubCategorySeasonItemList { get; set; }

        [Display(Name = "Available TV Shows")]
        public int SubCategoryCount { get; set; }

        [Display(Name = "Available Seasons")]
        public int SubCategorySeasonCount { get; set; }

        [Display(Name = "Available Episodes")]
        public int SubCategorySeasonItemCount { get; set; }

        public string UrlCategory { get; set; }
    }

    public class SectionTVShowSubCategory
    {

        public SectionTVShowSubCategory()
        {
            SubCategorySeasonList = new List<SectionTVShowSubCategorySeason>();
            SubCategorySeasonItemList = new List<SectionTVShowSubCategorySeasonItem>();
        }

        [Display(Name = "TV Show Code")]
        public Guid TVShowId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "TV Show")]
        [DataType(DataType.Text)]
        public string TVShowTitle { get; set; }

        [Required]
        [Display(Name = "File Upload")]
        public IFormFile FormFile { get; set; }

        [MaxLength(250)]
        [DataType(DataType.Text)]
        [Display(Name = "File(Path)")]
        public string ItemPath { get; set; }

        [Display(Name = "Total Seasons", ShortName = "Seasons")]
        public int TVShowSeasonNumberTotal { get; set; }

        [Display(Name = "Last Modified")]
        [DataType(DataType.Date)]
        public DateTime LastModified { get; set; }

        [Display(Name = "Date Added")]
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }

        public ICollection<SectionTVShowSubCategorySeason> SubCategorySeasonList { get; set; }

        public ICollection<SectionTVShowSubCategorySeasonItem> SubCategorySeasonItemList { get; set; }

        [Display(Name = "Available Seasons")]
        public int SubCategorySeasonCount { get; set; }

        [Display(Name = "Available Episodes")]
        public int SubCategorySeasonItemCount { get; set; }

        [Display(Name = "Genre Code")]
        public Guid CategoryId { get; set; }

        public string UrlCategory { get; set; }

        public string UrlSection { get; set; }

    }

    public class SectionTVShowSubCategorySeason
    {

        public SectionTVShowSubCategorySeason()
        {
            SubCategorySeasonItemList = new List<SectionTVShowSubCategorySeasonItem>();
        }

        [Display(Name = "Season Code")]
        public Guid SeasonId { get; set; }

        [Required]
        [Display(Name = "Season Number", ShortName = "Seasons")]
        public int TVShowSeasonNumber { get; set; }

        [MaxLength(250)]
        [DataType(DataType.Text)]
        [Display(Name = "File(Path)")]
        public string ItemPath { get; set; }

        [Display(Name = "Last Modified")]
        [DataType(DataType.Date)]
        public DateTime LastModified { get; set; }

        [Display(Name = "Date Added")]
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }

        public ICollection<SectionTVShowSubCategorySeasonItem> SubCategorySeasonItemList { get; set; }

        [Display(Name = "Available Episodes")]
        public int SubCategorySeasonItemCount { get; set; }

        [Display(Name = "Genre Code")]
        public Guid CategoryId { get; set; }

        [Display(Name = "TV Show Code")]
        public Guid TVShowId { get; set; }

        public string UrlCategory { get; set; }

        public string UrlSection { get; set; }

        public string UrlSubSection { get; set; }
    }

    public class SectionTVShowSubCategorySeasonItem
    {

        [Display(Name = "Episode Code")]
        public Guid ItemId { get; set; }


        [MaxLength(250)]
        [DataType(DataType.Text)]
        [Display(Name = "File(Path)")]
        public string ItemPath { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Title")]
        [DataType(DataType.Text)]
        public string ItemTitle { get; set; }

        [Display(Name = "Size (bytes)")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public long Size { get; set; }

        [Display(Name = "Last Modified")]
        [DataType(DataType.Date)]
        public DateTime LastModified { get; set; }

        [Display(Name = "Date Added")]
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }

        [Required]
        [Display(Name = "Season Number", ShortName = "Seasons")]
        public int TVShowSeasonNumber { get; set; }

        [Display(Name = "Season Code")]
        public Guid SeasonId { get; set; }

        [Display(Name = "Genre Code")]
        public Guid CategoryId { get; set; }

        [Display(Name = "TV Show Code")]
        public Guid TVShowId { get; set; }

        public string UrlCategory { get; set; }

        public string UrlSection { get; set; }

        public string UrlSubSection { get; set; }

        public string UrlSubSectionItem { get; set; }
    }

    public class StreamTVShowFileUploadDatabase
    {
        public StreamTVShowFileUploadDatabase()
        {
            Episodes = new List<SectionTVShowSubCategorySeasonItem>();
            Seasons = new List<SectionTVShowSubCategorySeason>();
        }

        [Required]
        [Display(Name = "File Upload")]
        public IFormFile FormFile { get; set; }

        [MaxLength(2)]
        [Display(Name = "Season Number", ShortName = "Seasons")]
        public int TVShowSeasonNumber { get; set; }

        [Display(Name = "List of Episodes")]
        public List<SectionTVShowSubCategorySeasonItem> Episodes { get; set; }

        [Display(Name = "Seasons")]
        public List<SectionTVShowSubCategorySeason> Seasons { get; set; }

        [Display(Name = "Season Code")]
        public Guid SeasonId { get; set; }

        [Display(Name = "Category Code")]
        public Guid CategoryId { get; set; }

        [Display(Name = "TV Show Code")]
        public Guid TVShowId { get; set; }

        public string UrlCategory { get; set; }

        public string UrlSection { get; set; }

        public string UrlSubSection { get; set; }
    }

    public class StreamFormData
    {
        [MaxLength(150)]
        [DataType(DataType.Text)]
        public string FilePath { get; set; }

        public Guid SeasonId { get; set; }

        public Guid CategoryId { get; set; }

        public Guid TVShowId { get; set; }

        public string UrlCategory { get; set; }

        public string UrlSection { get; set; }

        public string UrlSubSection { get; set; }
    }
}
