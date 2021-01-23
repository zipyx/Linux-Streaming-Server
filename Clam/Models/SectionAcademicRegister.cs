using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Clam.Models
{
    public class SectionAcademicRegister
    {
        [Display(Name = "Category Code")]
        public Guid AcademicId { get; set; }

        [Required]
        [MaxLength(50)]
        [DataType(DataType.Text)]
        [Display(Name = "Academic Category")]
        public string AcademicDisciplineTitle { get; set; }

        [Required]
        [MaxLength(100)]
        [DataType(DataType.Text)]
        [Display(Name = "Summary")]
        public string AcademicDisciplineDescription { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Last Modified")]
        public DateTime LastModified { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Created")]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Sections")]
        public int SubCategoryCount { get; set; }

        [Display(Name = "Total Videos")]
        public int SubCategoryItemCount { get; set; }

        public string UrlCategory { get; set; }

        public string UrlSection { get; set; }

    }

    public class SectionAcademicSubCategoryRegister
    {
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

        public string UrlCategory { get; set; }

        public string UrlSection { get; set; }
    }

    public class SectionAcademicSubCategoryItemRegister
    {
        public Guid ItemId { get; set; }

        [Required]
        [MaxLength(50)]
        [DataType(DataType.Text)]
        public string ItemTitle { get; set; }

        [Required]
        [MaxLength(100)]
        [DataType(DataType.Text)]
        public string ItemDescription { get; set; }

        [DataType(DataType.Date)]
        public DateTime LastModified { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }

        public string UrlCategory { get; set; }

        public string UrlSection { get; set; }

        public string UrlSectionItem { get; set; }
    }

    public class AllSectionAcademicInformation
    {

        public AllSectionAcademicInformation()
        {
            SubCategories = new List<string>();
            SubCategoryItems = new List<string>();
        }

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

        public ICollection<string> SubCategories { get; set; }

        public ICollection<string> SubCategoryItems { get; set; }
    }
}
