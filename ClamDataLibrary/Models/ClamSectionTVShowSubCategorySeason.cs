using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClamDataLibrary.Models
{
    public class ClamSectionTVShowSubCategorySeason
    {
        public ClamSectionTVShowSubCategorySeason()
        {
            ClamSectionTVShowSubCategorySeasonItems = new HashSet<ClamSectionTVShowSubCategorySeasonItem>();
        }

        [Key]
        public Guid SeasonId { get; set; }

        [Required]
        [Display(Name = "Season Number", ShortName = "Seasons")]
        public int TVShowSeasonNumber { get; set; }

        [Required]
        [MaxLength(300)]
        [DataType(DataType.Text)]
        [Display(Name = "File(Path)")]
        public string ItemPath { get; set; }

        [Display(Name = "Last Modified")]
        [DataType(DataType.Date)]
        public DateTime LastModified { get; set; }

        [Display(Name = "Date Added")]
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }

        public ICollection<ClamSectionTVShowSubCategorySeasonItem> ClamSectionTVShowSubCategorySeasonItems { get; set; }

        public Guid TVShowId { get; set; }
        public ClamSectionTVShowSubCategory ClamSectionTVShowSubCategory { get; set; }

        public Guid CategoryId { get; set; }
        public ClamSectionTVShowCategory ClamSectionTVShowCategory { get; set; }
    }
}
