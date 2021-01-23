using AutoMapper;
using Clam.Interface.Accounts;
using Clam.Models;
using ClamDataLibrary.DataAccess;
using ClamDataLibrary.Models;
using Microsoft.AspNetCore.Identity;
using System;

namespace Clam.Repository.Accounts
{
    public class UserAccountRepository : AccountRepository<ClamUserAccountContext>, IUserAccountRepository
    {
        public UserAccountRepository(ClamUserAccountContext context, IMapper mapper, UserManager<ClamUserAccountRegister> userManager, SignInManager<ClamUserAccountRegister> signInManager, RoleManager<ClamRoles> roleManager) : base(context, mapper, userManager, signInManager, roleManager) { }


        public UserAccountRegister GetUserWithRoles(Guid id)
        {
            return null;
        }
    }
}
