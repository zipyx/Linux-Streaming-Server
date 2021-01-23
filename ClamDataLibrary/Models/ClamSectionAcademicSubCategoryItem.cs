using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClamDataLibrary.Models
{
    public class ClamSectionAcademicSubCategoryItem
    {
        [Key]
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
        public ClamSectionAcademicSubCategory ClamSectionAcademicSubCategory { get; set; }

        // Category Section Foreign Key
        public Guid AcademicId { get; set; }
        public ClamSectionAcademicCategory ClamSectionAcademicCategory { get; set; }



    }
}
