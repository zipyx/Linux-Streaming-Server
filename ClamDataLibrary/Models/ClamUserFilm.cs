using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClamDataLibrary.Models
{
    public class ClamUserFilm
    {

        public ClamUserFilm()
        {
            ClamUserFilmJoinCategories = new HashSet<ClamUserFilmJoinCategory>();
        }

        [Key]
        [Required]
        [Display(Name = "Film ID")]
        public Guid FilmId { get; set; }

        [Required]
        [MaxLength(300)]
        [DataType(DataType.Text)]
        [Display(Name = "Video (Path)")]
        public string ItemPath { get; set; }

        [Required]
        [MaxLength(300)]
        [DataType(DataType.Text)]
        [Display(Name = "Cover (Path)")]
        public string ImagePath { get; set; }

        [Required]
        [MaxLength(300)]
        [DataType(DataType.Text)]
        [Display(Name = "Wallpaper (Path)")]
        public string WallpaperPath { get; set; }

        [MaxLength(200)]
        [DataType(DataType.Text)]
        [Display(Name = "Preview (Embed Video)")]
        public string UrlEmbeddedVideo { get; set; }

        [Display(Name = "Size (bytes)")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public long Size { get; set; }

        [Required]
        [MaxLength(60)]
        [Display(Name = "Film Title")]
        public string FilmTitle { get; set; }

        [MaxLength(20)]
        [DataType(DataType.Text)]
        [Display(Name = "Year")]
        public string Year { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "Viewing Status")]
        public bool Status { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Last Modified")]
        public DateTime LastModified { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        [Display(Name = "User ID")]
        public Guid UserId { get; set; }
        public virtual ClamUserAccountRegister User { get; set; }

        public ICollection<ClamUserFilmJoinCategory> ClamUserFilmJoinCategories { get; set; }
    }
}
