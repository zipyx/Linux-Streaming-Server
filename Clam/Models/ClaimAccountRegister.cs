using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clam.Models
{
    public class ClaimAccountRegister
    {
        [Display(Name = "Claim Type")]
        public string ClaimType { get; set; }

        [Display(Name = "Claim Value")]
        public string ClaimValue { get; set; }

        [Display(Name = "Select")]
        public bool IsSelected { get; set; }
    }

    public class AccountUserClaims
    {
        public AccountUserClaims()
        {
            UserClaims = new List<ClaimAccountRegister>();
        }
        [Display(Name = "User Code")]
        public string UserId { get; set; }

        public List<ClaimAccountRegister> UserClaims { get; set; }
    }
}
