using Clam.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clam.Areas.Storage.Models
{
    public class AreaUserPersonalCategoryItems
    {
        [Key]
        [Required]
        public Guid ItemId { get; set; }

        [Required]
        [MaxLength(30)]
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

        [Display(Name = "File Type")]
        public string FileType { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Last Modified")]
        public DateTime LastModified { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Added")]
        public DateTime DateCreated { get; set; }

        [Required]
        [Display(Name = "User ID")]
        public Guid UserId { get; set; }
        public virtual UserAccountRegister User { get; set; }
    }

    public class StreamStorageFile
    {
        public StreamStorageFile()
        {
            AreaUserPersonalCategoryItems = new List<AreaUserPersonalCategoryItems>();
        }

        [Required]
        [DataType(DataType.Upload)]
        [Display(Name = "My Files")]
        public List<IFormFile> File { get; set; }

        public List<AreaUserPersonalCategoryItems> AreaUserPersonalCategoryItems { get; set; }
    }
}
