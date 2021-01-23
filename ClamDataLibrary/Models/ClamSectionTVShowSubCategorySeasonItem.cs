using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClamDataLibrary.Models
{
    public class ClamSectionTVShowSubCategorySeasonItem
    {
        [Key]
        public Guid ItemId { get; set; }

        [Required]
        [MaxLength(300)]
        [DataType(DataType.Text)]
        [Display(Name = "File(Path)")]
        public string ItemPath { get; set; }

        [Required]
        [MaxLength(80)]
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

        public Guid SeasonId { get; set; }
        public ClamSectionTVShowSubCategorySeason ClamSectionTVShowSubCategorySeason { get; set; }

        public Guid TVShowId { get; set; }
        public ClamSectionTVShowSubCategory ClamSectionTVShowSubCategory { get; set; }

        public Guid CategoryId { get; set; }
        public ClamSectionTVShowCategory ClamSectionTVShowCategory { get; set; }
    }
}
