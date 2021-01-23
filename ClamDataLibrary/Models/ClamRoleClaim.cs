using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClamDataLibrary.Models
{
    public class ClamRoleClaim : IdentityRoleClaim<Guid>
    {
        public virtual ClamRoles Role { get; set; }
    }
}
