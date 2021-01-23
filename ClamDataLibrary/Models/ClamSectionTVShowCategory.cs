using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClamDataLibrary.Models
{
    public class ClamSectionTVShowCategory
    {

        public ClamSectionTVShowCategory()
        {
            ClamSectionTVShowSubCategories = new HashSet<ClamSectionTVShowSubCategory>();
            ClamSectionTVShowSubCategorySeasons = new HashSet<ClamSectionTVShowSubCategorySeason>();
            ClamSectionTVShowSubCategorySeasonItems = new HashSet<ClamSectionTVShowSubCategorySeasonItem>();
        }

        [Key]
        public Guid CategoryId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Genre")]
        [DataType(DataType.Text)]
        public string Genre { get; set; }

        [Required]
        [MaxLength(300)]
        [DataType(DataType.Text)]
        [Display(Name = "File(Path)")]
        public string ItemPath { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Last Modified")]
        public DateTime LastModified { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Added")]
        public DateTime DateCreated { get; set; }

        public ICollection<ClamSectionTVShowSubCategorySeason> ClamSectionTVShowSubCategorySeasons { get; set; }

        public ICollection<ClamSectionTVShowSubCategory> ClamSectionTVShowSubCategories { get; set; }

        public ICollection<ClamSectionTVShowSubCategorySeasonItem> ClamSectionTVShowSubCategorySeasonItems { get; set; }
    }
}
