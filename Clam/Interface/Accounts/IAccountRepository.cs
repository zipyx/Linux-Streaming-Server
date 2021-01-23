using Clam.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Clam.Interface.Accounts
{
    public interface IAccountRepository<UserAccountRegister> where UserAccountRegister : class
    {

        // ##################################################### Index Accounts :: Index Action
        IEnumerable<UserAccountRegister> GetAllUserAccounts();


        // ##################################################### Index Roles :: Index Action
        List<RoleAccountRegister> GetAllRoles();


        // ##################################################### Add Account :: Create Action
        Task AddAccount(UserAccountRegister entity);

        // ##################################################### Edit Account :: Edit Action
        Task<UserAccountInformation> EditAccount(Guid id);
        Task<UserAccountInformation> GetAccount(Guid id);


        // ##################################################### Remove Account :: Delete Action        
        Task RemoveAccount(Guid id);
        Task RemoveAccountRange(IEnumerable<UserAccountRegister> entities);


        // ##################################################### Manage User Roles :: ManageUserRoles Action
        Task<List<AccountUserRoles>> GetManageUserRole(AccountUserRoles model, Guid id);
        Task PostManageUserRole(List<AccountUserRoles> model, Guid id);


        // ##################################################### Manage User Claims :: ManageUserClaims Action
        Task<AccountUserClaims> GetManageUserClaim(Guid id);
        Task PostManageUserClaim(List<ClaimAccountRegister> model, Guid id);


        // ----------------------------------------------------> Newly Added Contracts : 24/03/20
        void SaveAccount(Guid id, UserAccountRegister entity);
    }
}
