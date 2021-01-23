using Clam.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clam.Areas.Projects.Models
{
    public class AreaUserProjects
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
        public virtual UserAccountRegister User { get; set; }
    }

    public class AreaUserProjectsImageInterests
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
        public virtual UserAccountRegister User { get; set; }
    }

    public class ProjectFormData
    {
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
        [DataType(DataType.Upload)]
        [Display(Name = "Image/Gif")]
        public IFormFile File { get; set; }

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
        public string Status { get; set; }
    }

    public class ProjectImageData
    {

        [Required]
        [Display(Name = "Status")]
        public string Status { get; set; }

        [Required]
        [DataType(DataType.Upload)]
        [Display(Name = "Image")]
        public IFormFile File { get; set; }
    }

    public class ProjectHome
    {
        public ProjectHome()
        {
            AreaUserProjects = new List<AreaUserProjects>();
        }

        //public AreaUserProjects ProjectModel { get; set; }
        [BindProperty]
        public ProjectFormData ProjectFormData { get; set; }

        [BindProperty]
        public ProjectImageData ProjectImageData { get; set; }

        public IEnumerable<AreaUserProjects> AreaUserProjects { get; set; }

        public IEnumerable<AreaUserProjectsImageInterests> AreaUserProjectsImageInterests { get; set; }
    }
}
