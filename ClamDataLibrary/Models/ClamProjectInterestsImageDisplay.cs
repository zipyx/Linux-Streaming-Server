using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClamDataLibrary.Models
{
    public class ClamProjectInterestsImageDisplay
    {
        [Key]
        [Required]
        [Display(Name = "Image ID")]
        public Guid ImageId { get; set; }

        [Required]
        [MaxLength(60)]
        [DataType(DataType.Text)]
        [Display(Name = "Interests")]
        public string Title { get; set; }

        [Required]
        [MaxLength(300)]
        [DataType(DataType.Text)]
        [Display(Name = "Physical Location")]
        public string ImageLocation { get; set; }

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
