using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ClamDataLibrary.Models
{
    public class ClamUserProjects
    {

        [Key]
        [Required]
        [Display(Name = "Project ID")]
        public Guid ProjectId { get; set; }

        [Required]
        [MaxLength(60)]
        [DataType(DataType.Text)]
        [Display(Name = "Label")]
        public string Title { get; set; }

        [MaxLength(100)]
        [DataType(DataType.Text)]
        [Display(Name = "Author")]
        public string Author { get; set; }

        [Required]
        [MaxLength(300)]
        [DataType(DataType.Text)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [MaxLength(300)]
        [DataType(DataType.Text)]
        [Display(Name = "Image/Gif")]
        public string ImageGifLocation { get; set; }

        [MaxLength(30)]
        [DataType(DataType.Text)]
        [Display(Name = "Language")]
        public string Language { get; set; }

        [MaxLength(150)]
        [DataType(DataType.Url)]
        [Display(Name = "Github Link")]
        public string GithubLink { get; set; }

        [Required]
        [Display(Name = "Status")]
        public bool Status { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Updated On")]
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
