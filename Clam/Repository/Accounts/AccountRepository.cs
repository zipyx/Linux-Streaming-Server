using AutoMapper;
using Clam.Interface.Accounts;
using Clam.Models;
using ClamDataLibrary.DataAccess;
using ClamDataLibrary.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Clam.Repository.Accounts
{
    public class AccountRepository<TEntity> : IAccountRepository<UserAccountRegister>
    {
        private readonly UserManager<ClamUserAccountRegister> _userManager;
        private readonly SignInManager<ClamUserAccountRegister> _signInManager;
        private readonly RoleManager<ClamRoles> _roleManager;
        protected readonly ClamUserAccountContext Context;
        protected readonly IMapper _mapper;

        public AccountRepository(ClamUserAccountContext context, IMapper mapper, UserManager<ClamUserAccountRegister> userManager,
            SignInManager<ClamUserAccountRegister> signInManager, RoleManager<ClamRoles> roleManager)
        {
            Context = context;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task AddAccount(UserAccountRegister entity)
        {
            //ClamUserAccountRegister user = new ClamUserAccountRegister();
            //var model = _mapper.Map<ClamDataLibrary.Models.ClamUserAccountRegister>(entity);
            //Context.Set<ClamDataLibrary.Models.ClamUserAccountRegister>().AddAsync(model);
            //Context.SaveChanges();

            var user = new ClamUserAccountRegister
            {
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                UserName = entity.UserName,
                Email = entity.Email,
                PhoneNumber = entity.PhoneNumber,
                Gender = entity.Gender,
                Birthday = entity.Birthday
            };

            await _userManager.CreateAsync(user, entity.Password);
            await _userManager.AddToRoleAsync(user, entity.RoleName);
            await _signInManager.SignInAsync(user, isPersistent: false);

        }


        public IEnumerable<UserAccountRegister> Find(Expression<Func<UserAccountRegister, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<UserAccountInformation> GetAccount(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return null;
            }

            var userRoles = await _userManager.GetRolesAsync(user);
            var userClaims = await _userManager.GetClaimsAsync(user);
            var model = new UserAccountInformation()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Gender = user.Gender,
                Birthday = user.Birthday,
                Claims = userClaims.Select(c => c.Value).ToList(),
                Roles = userRoles.ToList()
            };
            //var user = await _userManager.FindByIdAsync(id.ToString());
            //if (user == null)
            //{
            //    return null;
            //}

            //var userRoles = await _userManager.GetRolesAsync(user);
            //var model = new UserAccountInformation()
            //{
            //    FirstName = user.FirstName,
            //    LastName = user.LastName,
            //    UserName = user.UserName,
            //    Email = user.Email,
            //    PhoneNumber = user.PhoneNumber,
            //    Gender = user.Gender,
            //    Birthday = user.Birthday,
            //    Roles = userRoles
            //};

            return model;
        }

        public IEnumerable<UserAccountRegister> GetAllUserAccounts()
        {

            List<UserAccountRegister> list = new List<UserAccountRegister>();
            foreach (var user in _userManager.Users)
            {
                list.Add(new UserAccountRegister()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Gender = user.Gender,
                    Birthday = user.Birthday,
                    UserName = user.UserName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber
                });
            }
            return list;
        }

        public async Task RemoveAccount(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            await _userManager.DeleteAsync(user);
        }


        public async Task RemoveAccountRange(IEnumerable<UserAccountRegister> entities)
        {
            foreach (var user in entities)
            {
                await _userManager.DeleteAsync(_mapper.Map<ClamUserAccountRegister>(user));
            }
        }

        public void SaveAccount(Guid id, UserAccountRegister entity)
        {
            var model = _mapper.Map<ClamDataLibrary.Models.ClamUserAccountRegister>(entity);
            Context.Set<ClamDataLibrary.Models.ClamUserAccountRegister>().Update(model);
            Context.SaveChanges();
        }


        public UserAccountRegister SingleOrDefault(Expression<Func<UserAccountRegister, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public List<RoleAccountRegister> GetAllRoles()
        {
            List<RoleAccountRegister> list = new List<RoleAccountRegister>();
            foreach (var role in _roleManager.Roles)
            {
                list.Add(new RoleAccountRegister() { Name = role.Name });
            }
            return list;
        }

        public async Task<UserAccountInformation> EditAccount(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return null;
            }

            var userRoles = await _userManager.GetRolesAsync(user);
            var userClaims = await _userManager.GetClaimsAsync(user);
            var model = new UserAccountInformation()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Gender = user.Gender,
                Birthday = user.Birthday,
                Claims = userClaims.Select(c => c.Value).ToList(),
                Roles = userRoles
            };

            return model;
        }

        public async Task<List<AccountUserRoles>> GetManageUserRole(AccountUserRoles models, Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return null;
            }

            var model = new List<AccountUserRoles>();
            foreach (var role in _roleManager.Roles.ToList())
            {
                var userRoles = new AccountUserRoles
                {
                    UserId = user.Id,
                    RoleId = role.Id,
                    RoleName = role.Name,
                };
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    userRoles.IsSelected = true;
                }
                else
                {
                    userRoles.IsSelected = false;
                }
                model.Add(userRoles);
            }
            return model;
        }

        public async Task PostManageUserRole(List<AccountUserRoles> model, Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            var roles = await _userManager.GetRolesAsync(user);
            var complete = await _userManager.RemoveFromRolesAsync(user, roles);
            await _userManager.AddToRolesAsync(user, model.Where(x => x.IsSelected).Select(y => y.RoleName));

        }

        //--------------------------------------------------------------- CLAIMS 

        public async Task<AccountUserClaims> GetManageUserClaim(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            var currentUserClaims = await _userManager.GetClaimsAsync(user);
            var model = new AccountUserClaims { UserId = id.ToString() };

            foreach (Claim claim in ClaimsStore.AllClaims.ToList())
            {

                ClaimAccountRegister userClaims = new ClaimAccountRegister { ClaimType = claim.Type, ClaimValue = claim.Value };
                if (currentUserClaims.Any(c => c.Type == claim.Type))
                {
                    userClaims.IsSelected = true;
                }
                else
                {
                    userClaims.IsSelected = false;
                }
                model.UserClaims.Add(userClaims);
            }
            return model;
        }

        public async Task PostManageUserClaim(List<ClaimAccountRegister> model, Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            var userClaims = await _userManager.GetClaimsAsync(user);
            var complete = await _userManager.RemoveClaimsAsync(user, userClaims);
            await _userManager.AddClaimsAsync(user, model.Where(x => x.IsSelected).Select(y => new Claim(y.ClaimType, y.ClaimValue)));

        }
    }
}
