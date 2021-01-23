using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clam.Models;

namespace Clam.Interface.Accounts
{
    public interface IUserAccountRepository : IAccountRepository<UserAccountRegister>
    {
        UserAccountRegister GetUserWithRoles(Guid id);
    }
}
