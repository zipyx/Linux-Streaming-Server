using Clam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clam.Interface.Roles
{
    public interface IRoleAccountRepository : IRoleRepository<RoleAccountRegister>
    {
        RoleAccountRegister GetRolesWithUser(Guid id);
    }
}
