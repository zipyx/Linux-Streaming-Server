using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clam.Models
{
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

        [Display(Name = "Description")]
        [DataType(DataType.Text)]
        [StringLength(100, MinimumLength = 0)]
        public string Note { get; set; }

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
