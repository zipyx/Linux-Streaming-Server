using AutoMapper;
using Clam.Interface.Roles;
using Clam.Models;
using ClamDataLibrary.DataAccess;
using ClamDataLibrary.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clam.Repository.Roles
{
    public class RoleAccountRepository : RoleRepository<ClamUserAccountContext>, IRoleAccountRepository
    {
        public RoleAccountRepository(ClamUserAccountContext context, IMapper mapper, UserManager<ClamUserAccountRegister> userManager, SignInManager<ClamUserAccountRegister> signInManager, RoleManager<ClamRoles> roleManager) : base(context, mapper, userManager, signInManager, roleManager) { }

        public RoleAccountRegister GetRolesWithUser(Guid id) { return null; }
    }
}
