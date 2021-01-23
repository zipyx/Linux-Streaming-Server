using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClamDataLibrary.Models
{
    public class ClamSectionTVShowSubCategory
    {

        public ClamSectionTVShowSubCategory()
        {
            ClamSectionTVShowSubCategorySeasonItems = new HashSet<ClamSectionTVShowSubCategorySeasonItem>();
            ClamSectionTVShowSubCategorySeasons = new HashSet<ClamSectionTVShowSubCategorySeason>();
        }

        [Key]
        public Guid TVShowId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "TV Show")]
        [DataType(DataType.Text)]
        public string TVShowTitle { get; set; }

        [Required]
        [MaxLength(300)]
        [DataType(DataType.Text)]
        [Display(Name = "File(Path)")]
        public string ItemPath { get; set; }

        [Required]
        [Display(Name = "Total Seasons", ShortName = "Seasons")]
        public int TVShowSeasonNumberTotal { get; set; }
         
        [Display(Name = "Last Modified")]
        [DataType(DataType.Date)]
        public DateTime LastModified { get; set; }

        [Display(Name = "Date Added")]
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }

        public ICollection<ClamSectionTVShowSubCategorySeasonItem> ClamSectionTVShowSubCategorySeasonItems { get; set; }

        public ICollection<ClamSectionTVShowSubCategorySeason> ClamSectionTVShowSubCategorySeasons { get; set; }

        public Guid CategoryId { get; set; }

        public ClamSectionTVShowCategory ClamSectionTVShowCategory { get; set; }

    }
}
