using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ClamDataLibrary.Models
{
    public class ClamUserAccountRegister : IdentityUser<Guid>
    {
        public ClamUserAccountRegister()
        {
            ClamUserMusics = new HashSet<ClamUserMusic>();
            ClamUserBooks = new HashSet<ClamUserBooks>();
            ClamUserFilms = new HashSet<ClamUserFilm>();
            ClamUserPersonalCategoryItems = new HashSet<ClamUserPersonalCategoryItem>();
            ClamUserSystemTickets = new HashSet<ClamUserSystemTicket>();
            ClamUserProjects = new HashSet<ClamUserProjects>();
            ClamProjectInterestsImageDisplays = new HashSet<ClamProjectInterestsImageDisplay>();
        }

        // -------------------> Newly Implemented Identities
        public virtual ICollection<ClamUserClaim> Claims { get; set; }
        public virtual ICollection<ClamUserLogin> Logins { get; set; }
        public virtual ICollection<ClamUserToken> Tokens { get; set; }
        public virtual ICollection<ClamUserRole> UserRoles { get; set; }
        // ------------------------------------------------


        [Required]
        [MaxLength(50)]
        [DataType(DataType.Text)]
        [Column(Order = 1)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        [DataType(DataType.Text)]
        [Column(Order = 2)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(20)]
        [DataType(DataType.Text)]
        [Column(Order = 3)]
        public string Gender { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Column(Order = 4)]
        public DateTime Birthday { get; set; }

        [Required]
        [Column(Order = 5)]
        public bool AcceptTermsAndConditions { get; set; }


        // ----------------- Own Implementation ------------------------
        public ICollection<ClamUserMusic> ClamUserMusics { get; set; } 

        public ICollection<ClamUserBooks> ClamUserBooks { get; set; }

        public ICollection<ClamUserFilm> ClamUserFilms { get; set; } 

        public ICollection<ClamUserPersonalCategoryItem> ClamUserPersonalCategoryItems { get; set; }

        public ICollection<ClamUserSystemTicket> ClamUserSystemTickets { get; set; } 

        public ICollection<ClamUserProjects> ClamUserProjects { get; set; }

        public ICollection<ClamProjectInterestsImageDisplay> ClamProjectInterestsImageDisplays { get; set; }
    }
}
