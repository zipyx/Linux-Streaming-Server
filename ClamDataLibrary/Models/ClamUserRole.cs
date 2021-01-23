using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClamDataLibrary.Models
{
    public class ClamUserRole : IdentityUserRole<Guid>
    {

        public virtual ClamUserAccountRegister User { get; set; }
        public virtual ClamRoles Role { get; set; }

    }
}
