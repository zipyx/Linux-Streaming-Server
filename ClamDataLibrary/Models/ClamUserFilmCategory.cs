using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClamDataLibrary.Models
{
    public class ClamUserFilmCategory
    {

        public ClamUserFilmCategory()
        {
            ClamUserFilmJoinCategories = new HashSet<ClamUserFilmJoinCategory>();
        }

        [Key]
        [Required]
        public Guid CategoryId { get; set; }

        [Required]
        [MaxLength(30)]
        [DataType(DataType.Text)]
        public string CategoryName { get; set; }

        [DataType(DataType.Date)]
        public DateTime LastModified { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }

        public ICollection<ClamUserFilmJoinCategory> ClamUserFilmJoinCategories { get; set; }
    }
}
