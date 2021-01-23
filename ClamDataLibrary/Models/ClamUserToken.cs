using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClamDataLibrary.Models
{
    public class ClamUserToken : IdentityUserToken<Guid>
    {
        public virtual ClamUserAccountRegister User { get; set; }
    }
}
