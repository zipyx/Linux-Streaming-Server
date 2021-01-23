using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clam.Areas.Academia.Models
{
    // Category Section
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

    // Sub Section
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

    // Items
    public class SectionItem
    {
        [Display(Name = "Code")]
        public Guid ItemId { get; set; }

        [MaxLength(150)]
        [Display(Name = "File(Path)")]
        [DataType(DataType.Text)]
        public string ItemPath { get; set; }

        [Required]
        [MaxLength(50)]
        [DataType(DataType.Text)]
        [Display(Name = "File Name")]
        public string ItemTitle { get; set; }

        [Required]
        [MaxLength(100)]
        [DataType(DataType.Text)]
        [Display(Name = "Description")]
        public string ItemDescription { get; set; }

        [Display(Name = "Size (bytes)")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public long Size { get; set; }

        [DataType(DataType.Date)]
        public DateTime LastModified { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }

        public string UrlCategory { get; set; }

        public string UrlSection { get; set; }

        public string UrlSectionItem { get; set; }

    }

    public class StreamFileData
    {
        [BindProperty]
        public StreamFileData FileUpload { get; set; }

        public string Result { get; set; }
    }

    /// <summary>
    /// This is where all the Item episodes are loaded into view and processed in the action(Episode)
    /// </summary>
    public class StreamFileUploadDatabase
    {
        public StreamFileUploadDatabase()
        {
            SectionItems = new List<SectionItem>();
        }

        [Required]
        [Display(Name = "File Upload")]
        public IFormFile FormFile { get; set; }

        //[Display(Name = "Description")]
        //[DataType(DataType.Text)]
        //[StringLength(100, MinimumLength = 0)]
        //public string Note { get; set; }

        // Sub Category Section Foreign Key
        [Display(Name = "Sub-Category Code")]
        public Guid SubCategoryId { get; set; }
        public SectionRegister SectionRegister { get; set; }


        // Category Id Foreign Key Placement
        [Display(Name = "Category Code")]
        public Guid AcademicId { get; set; }
        public SectionAcademicRegister SectionAcademicRegister { get; set; }

        public List<SectionItem> SectionItems { get; set; }

        [Display(Name = "Name / Path")]
        public IDirectoryContents PhysicalFiles { get; set; }

    }

    public class FormData
    {

        [MaxLength(100)]
        [DataType(DataType.Text)]
        [Display(Name = "Description")]
        public string Note { get; set; }

        [MaxLength(150)]
        [DataType(DataType.Text)]
        public string FilePath { get; set; }

        // Sub Category Section Foreign Key
        [Display(Name = "Sub-Category Code")]
        public Guid SubCategoryId { get; set; }
        public SectionRegister SectionRegister { get; set; }


        // Category Id Foreign Key Placement
        [Display(Name = "Category Code")]
        public Guid AcademicId { get; set; }
        public SectionAcademicRegister SectionAcademicRegister { get; set; }
    }

    public class AllSectionItems
    {
        public Guid ItemId { get; set; }

        [MaxLength(250)]
        [Display(Name = "File(Path)")]
        [DataType(DataType.Text)]
        public string ItemPath { get; set; }

        //[Required]
        [MaxLength(60)]
        [DataType(DataType.Text)]
        [Display(Name = "File Name")]
        public string ItemTitle { get; set; }

        //[Required]
        [MaxLength(100)]
        [DataType(DataType.Text)]
        [Display(Name = "Description")]
        public string ItemDescription { get; set; }

        [Display(Name = "Size (bytes)")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public long Size { get; set; }

        [DataType(DataType.Date)]
        public DateTime LastModified { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }

        //Sub Category Section Foreign Key
        public Guid SubCategoryId { get; set; }

        // Category Section Foreign Key
        public Guid AcademicId { get; set; }
    }
}
