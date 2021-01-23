using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClamDataLibrary.Models
{
    public class ClamUserLogin : IdentityUserLogin<Guid>
    {
        public virtual ClamUserAccountRegister User { get; set; }
    }
}
