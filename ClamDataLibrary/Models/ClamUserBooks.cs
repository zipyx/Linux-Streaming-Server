using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClamDataLibrary.Models
{
    public class ClamUserBooks
    {

        [Key]
        [Required]
        [Display(Name = "Book ID")]
        public Guid BookId { get; set; }

        [Required]
        [MaxLength(300)]
        [DataType(DataType.Text)]
        [Display(Name = "Stored Path")]
        public string ItemPath { get; set; }

        [Required]
        [MaxLength(300)]
        [DataType(DataType.Text)]
        [Display(Name = "Image Path")]
        public string ImagePath { get; set; }

        [Display(Name = "Size (bytes)")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public long Size { get; set; }

        [Required]
        [MaxLength(50)]
        [DataType(DataType.Text)]
        [Display(Name = "Book Name")]
        public string BookTitle { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "Viewing Status")]
        public bool Status { get; set; }

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

        public ICollection<ClamUserBooksJoinCategory> ClamUserBooksJoinCategories { get; set; }

    }
}
