using Clam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clam.Interface.Roles
{
    public interface IRoleRepository<RoleAccountRegister> where RoleAccountRegister : class
    {
        // ################################# Index Roles :: Index Action
        List<RoleAccountRegister> GetAllRoles();

        // ################################# Add Roles :: Create Action
        Task AddRole(RoleAccountRegister entity);
        Task AddRoleRange(List<RoleAccountRegister> entitiy);

        // ################################# Edit Role :: Edit Action // Detail Action
        Task<RoleAccountRegister> ViewRole(Guid id);
        Task EditRole(RoleAccountRegister entity, Guid id);

        // ################################# Remove Role :: Remove Action
        Task RemoveRole(Guid id);
        Task RemoveRoleRange(List<RoleAccountRegister> entity);

        // ################################# Add Users to Role :: EditRoleUsers Action
        Task<List<RoleAccountUsers>> ViewRoleUsers(Guid id);
        Task PostRoleUsers(List<RoleAccountUsers> entity, Guid id);

        // ################################# Add Claims to Role :: ManageRoleClaim Action
        Task<AccountRoleClaims> ViewRoleClaims(Guid id);
        Task PostRoleClaims(List<ClaimAccountRegister> entity, Guid id);
        
    }
}
