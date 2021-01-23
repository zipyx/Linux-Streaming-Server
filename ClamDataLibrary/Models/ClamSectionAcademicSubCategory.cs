using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClamDataLibrary.Models
{
    public class ClamSectionAcademicSubCategory
    {
        public ClamSectionAcademicSubCategory()
        {
            ClamSectionAcademicSubCategoryItems = new HashSet<ClamSectionAcademicSubCategoryItem>();
        }


        [Key]
        public Guid SubCategoryId { get; set; }

        [Required]
        [MaxLength(50)]
        [DataType(DataType.Text)]
        public string SubCategoryTitle { get; set; }

        [Required]
        [MaxLength(100)]
        [DataType(DataType.Text)]
        public string SubCategoryDescription { get; set; }

        [DataType(DataType.Date)]
        public DateTime LastModified { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }

        public ICollection<ClamSectionAcademicSubCategoryItem> ClamSectionAcademicSubCategoryItems { get; set; } 

        public Guid AcademicId { get; set; }
        public ClamSectionAcademicCategory ClamSectionAcademicCategory { get; set; }
    }
}
