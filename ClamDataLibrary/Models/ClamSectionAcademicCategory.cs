using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;

namespace ClamDataLibrary.Models
{
    public class ClamSectionAcademicCategory
    {
        public ClamSectionAcademicCategory()
        {
            ClamSectionAcademicSubCategories = new List<ClamSectionAcademicSubCategory>();
            ClamSectionAcademicSubCategoryItems = new HashSet<ClamSectionAcademicSubCategoryItem>();
        }

        [Key]
        public Guid AcademicId { get; set; }

        [Required]
        [MaxLength(50)]
        [DataType(DataType.Text)]
        public string AcademicDisciplineTitle { get; set; }

        [Required]
        [MaxLength(100)]
        [DataType(DataType.Text)]
        public string AcademicDisciplineDescription { get; set; }

        [DataType(DataType.Date)]
        public DateTime LastModified { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }

        public ICollection<ClamSectionAcademicSubCategory> ClamSectionAcademicSubCategories { get; set; } 

        public ICollection<ClamSectionAcademicSubCategoryItem> ClamSectionAcademicSubCategoryItems { get; set; } 

    }
}
