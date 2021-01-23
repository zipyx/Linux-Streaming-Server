using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClamDataLibrary.Models
{
    public class ClamUserMusic
    {

        [Key]
        [Required]
        public Guid SongId { get; set; }

        [Required]
        [MaxLength(300)]
        [DataType(DataType.Text)]
        [Display(Name = "Song (Path)")]
        public string ItemPath { get; set; }

        [Required]
        [MaxLength(30)]
        [DataType(DataType.Text)]
        [Display(Name = "Song Title")]
        public string SongTitle { get; set; }

        [Required]
        [MaxLength(30)]
        [DataType(DataType.Text)]
        [Display(Name = "Song Artist")]
        public string SongArtist { get; set; }

        [Display(Name = "Size (bytes)")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public long Size { get; set; }

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

        [Display(Name = "User ID")]
        public Guid UserId { get; set; }
        public virtual ClamUserAccountRegister User { get; set; }

        public ICollection<ClamUserMusicJoinCategory> ClamUserMusicJoinCategories { get; set; }

    }
}
