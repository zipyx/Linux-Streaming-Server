using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClamDataLibrary.Models
{
    public class ClamRoles : IdentityRole<Guid>
    {
        public virtual ICollection<ClamUserRole> UserRoles { get; set; }
        public virtual ICollection<ClamRoleClaim> RoleClaims { get; set; }
    }
}
