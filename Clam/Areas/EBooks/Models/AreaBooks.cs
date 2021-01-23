using Clam.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clam.Areas.EBooks.Models
{
    public class AreaUserBooks
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
        public virtual UserAccountRegister User { get; set; }

        public ICollection<AreaUserBooksJoinCategory> AreaUserBooksJoinCategories { get; set; }
    }

    public class AreaUserBooksCategory
    {
        public AreaUserBooksCategory()
        {
            AreaUserBooks = new List<AreaUserBooks>();
            AreaUserBooksJoinCategories = new HashSet<AreaUserBooksJoinCategory>();
        }

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

        public List<AreaUserBooks> AreaUserBooks { get; set; }

        public ICollection<AreaUserBooksJoinCategory> AreaUserBooksJoinCategories { get; set; }

    }

    public class AreaUserBooksJoinCategory
    {
        public Guid BookId { get; set; }
        public AreaUserBooks AreaUserBooks { get; set; }

        public Guid CategoryId { get; set; }
        public AreaUserBooksCategory AreaUserBooksCategory { get; set; }
    }

    public class StreamBooksDataUpload
    {
  
        [Display(Name = "Book ID")]
        public Guid BookId { get; set; }

        [Required]
        [DataType(DataType.Upload)]
        [Display(Name = "File")]
        public IFormFile ItemPath { get; set; }

        [Required]
        [DataType(DataType.Upload)]
        [Display(Name = "Cover Image")]
        public IFormFile ImagePath { get; set; }

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

        [Display(Name = "User ID")]
        public Guid UserId { get; set; }
        public virtual UserAccountRegister User { get; set; }
    }

    public class BooksGenreSelection
    {
        [Display(Name = "Book ID")]
        public Guid BookId { get; set; }

        [Required]
        [MaxLength(50)]
        [DataType(DataType.Text)]
        [Display(Name = "Book Name")]
        public string BookTitle { get; set; }

        [Display(Name = "Select")]
        public bool IsSelected { get; set; }

        [Display(Name = "User ID")]
        public Guid UserId { get; set; }
        public virtual UserAccountRegister User { get; set; }
    }

    public class StreamFormDataBooks
    {
        [Required]
        [MaxLength(50)]
        [DataType(DataType.Text)]
        [Display(Name = "Book Name")]
        public string BookTitle { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "Viewing Status")]
        public string Status { get; set; }
    }

    public class BooksHome
    {
     
        public BooksHome()
        {
            AreaUserBooks = new List<AreaUserBooks>();
            AreaUserBooksCategories = new List<AreaUserBooksCategory>();
            AreaUserBooksJoinCategories = new List<AreaUserBooksJoinCategory>();
            RecentlyAdded = new List<AreaUserBooks>();
            RecommendedList = new List<AreaUserBooks>();
        }

        public List<AreaUserBooks> AreaUserBooks { get; set; }

        public List<AreaUserBooksCategory> AreaUserBooksCategories { get; set; }

        public List<AreaUserBooksJoinCategory> AreaUserBooksJoinCategories { get; set; }

        public List<AreaUserBooks> RecentlyAdded { get; set; }

        public List<AreaUserBooks> RecommendedList { get; set; }

        [Display(Name = "Searched For")]
        public string SearchRequest { get; set; }

        public int SearchRequestResultsCount { get; set; }
    }

    public class ReadBook
    {

        public ReadBook()
        {
            Recommended = new List<AreaUserBooks>();
            AreaUserBooksJoinCategories = new List<AreaUserBooksJoinCategory>();
        }

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

        public List<AreaUserBooks> Recommended { get; set; }

        public List<AreaUserBooksJoinCategory> AreaUserBooksJoinCategories { get; set; }
    }
}
