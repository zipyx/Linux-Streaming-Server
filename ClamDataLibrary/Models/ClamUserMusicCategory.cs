using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClamDataLibrary.Models
{
    public class ClamUserMusicCategory
    {

        [Key]
        [Required]
        [Display(Name = "Category ID")]
        public Guid CategoryId { get; set; }

        [Required]
        [MaxLength(30)]
        [DataType(DataType.Text)]
        [Display(Name = "Genre")]
        public string CategoryName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Last Modified")]
        public DateTime LastModified { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Added")]
        public DateTime DateCreated { get; set; }

        public ICollection<ClamUserMusicJoinCategory> ClamUserMusicJoinCategories { get; set; }


    }
}
