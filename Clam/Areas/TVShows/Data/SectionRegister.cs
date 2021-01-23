using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clam.Models
{
    public class SectionRegister
    {
        public SectionRegister()
        {
            SectionItems = new HashSet<SectionItem>();
        }

        [Display(Name = "Sub-Category Code")]
        public Guid SubCategoryId { get; set; }

        [Required]
        [MaxLength(50)]
        [DataType(DataType.Text)]
        [Display(Name = "Title")]
        public string SubCategoryTitle { get; set; }

        [Required]
        [MaxLength(100)]
        [DataType(DataType.Text)]
        [Display(Name = "Description")]
        public string SubCategoryDescription { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Last Modified")]
        public DateTime LastModified { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Created")]
        public DateTime DateAdded { get; set; }

        // ##################################################### Child to --> SectionAacademicRegister
        [Display(Name = "Category Code")]
        public Guid AcademicId { get; set; }
        public SectionAcademicRegister SectionAcademicRegister { get; set; }

        // ###################################################### List of Items --> Parent to --> SectionItem
        public ICollection<SectionItem> SectionItems { get; set; }

        [Display(Name = "Total Videos")]
        public int VideoCount { get; set; }

        public string UrlCategory { get; set; }

        public string UrlSection { get; set; }
    }
}
