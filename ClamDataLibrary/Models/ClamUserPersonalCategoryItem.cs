using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClamDataLibrary.Models
{
    public class ClamUserPersonalCategoryItem
    {
        [Key]
        [Required]
        public Guid ItemId { get; set; }

        [Required]
        [MaxLength(60)]
        [DataType(DataType.Text)]
        [Display(Name = "File Name")]
        public string FileName { get; set; }

        [Required]
        [MaxLength(300)]
        [DataType(DataType.Text)]
        [Display(Name = "Stored Path")]
        public string ItemPath { get; set; }

        [Display(Name = "Size (bytes)")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public long Size { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Last Modified")]
        public DateTime LastModified { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Added")]
        public DateTime DateCreated { get; set; }

        [Required]
        [Display(Name = "User ID")]
        public Guid UserId { get; set; }
        public virtual ClamUserAccountRegister User { get; set; }
    }
}
