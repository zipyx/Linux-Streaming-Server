using AutoMapper;
using Clam.Interface.Roles;
using Clam.Models;
using ClamDataLibrary.DataAccess;
using ClamDataLibrary.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Clam.Repository.Roles
{
    public class RoleRepository<TEntity> : IRoleRepository<RoleAccountRegister>
    {
        private readonly UserManager<ClamUserAccountRegister> _userManager;
        private readonly SignInManager<ClamUserAccountRegister> _signInManager;
        private readonly RoleManager<ClamRoles> _roleManager;
        protected readonly ClamUserAccountContext Context;
        protected readonly IMapper _mapper;

        public RoleRepository(ClamUserAccountContext context, IMapper mapper, UserManager<ClamUserAccountRegister> userManager,
            SignInManager<ClamUserAccountRegister> signInManager, RoleManager<ClamRoles> roleManager)
        {
            Context = context;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public List<RoleAccountRegister> GetAllRoles()
        {
            List<RoleAccountRegister> list = new List<RoleAccountRegister>();
            foreach (var role in _roleManager.Roles)
            {
                var castRole = _mapper.Map<ClamRoles>(role);
                list.Add(new RoleAccountRegister(castRole));
            }
            return list;
        }

        public async Task AddRole(RoleAccountRegister entity)
        {
            try
            {
                var role = new ClamRoles { Name = entity.Name };
                await _roleManager.CreateAsync(role); 
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task AddRoleRange(List<RoleAccountRegister> entitiy)
        {
            throw new NotImplementedException();
        }

        public async Task<RoleAccountRegister> ViewRole(Guid id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            var model = new RoleAccountRegister { Id = role.Id, Name = role.Name, Users = new List<string>(), Claims = new List<string>() };
            var getUsers = _userManager.Users.ToList();
            var getClaims = _roleManager.GetClaimsAsync(role);
            foreach (var user in getUsers)
            {
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.FirstName);
                }

            }
            foreach (Claim claim in getClaims.Result)
            {
                model.Claims.Add(claim.Value);
            }
            return model;
        }

        public async Task EditRole(RoleAccountRegister entity, Guid id)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(entity.Id.ToString());
                role.Name = entity.Name;
                await _roleManager.UpdateAsync(role);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task RemoveRole(Guid id)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(id.ToString());
                await _roleManager.DeleteAsync(role);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task RemoveRoleRange(List<RoleAccountRegister> entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RoleAccountUsers>> ViewRoleUsers(Guid id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            if (role == null)
            {
                return null;
            }
            var model = new List<RoleAccountUsers>();
            foreach (var user in _userManager.Users.ToList())
            {
                var userRoles = new RoleAccountUsers
                {
                    Id = user.Id.ToString(),
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.UserName,
                    Email = user.Email
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

        public async Task PostRoleUsers(List<RoleAccountUsers> entity, Guid id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            if (role == null) { }

            for (int i = 0; i < entity.Count; i++)
            {
                var user = _userManager.FindByIdAsync(entity[i].Id);

                IdentityResult result;

                if (entity[i].IsSelected && !(await _userManager.IsInRoleAsync(user.Result, role.Name)))
                {
                    result = await _userManager.AddToRoleAsync(user.Result, role.Name);
                }
                else if (!entity[i].IsSelected && await _userManager.IsInRoleAsync(user.Result, role.Name))
                {
                    result = await _userManager.RemoveFromRoleAsync(user.Result, role.Name);
                }
                else
                {
                    continue;
                }
                if (result.Succeeded)
                {
                    if (i < (entity.Count - 1))
                        continue;
                    else
                        break;
                }
            }
        }

        public async Task<AccountRoleClaims> ViewRoleClaims(Guid id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            var currentRoleClaims = await _roleManager.GetClaimsAsync(role);
            var model = new AccountRoleClaims { RoleId = id.ToString() };

            foreach (Claim claim in ClaimsStore.RoleClaims.ToList())
            {
                ClaimAccountRegister roleClaims = new ClaimAccountRegister { ClaimType = claim.Type, ClaimValue = claim.Value };
                if (currentRoleClaims.Any(c => c.Type == claim.Type))
                {
                    roleClaims.IsSelected = true;
                }
                else
                {
                    roleClaims.IsSelected = false;
                }
                model.RoleClaims.Add(roleClaims);
            }
            return model; // model.Roleclaims
        }

        public async Task PostRoleClaims(List<ClaimAccountRegister> entity, Guid id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            var claims = await _roleManager.GetClaimsAsync(role);

            foreach (var item in claims)
            {
                var result = await _roleManager.RemoveClaimAsync(role, item);
            }

            for (int i = 0; i < entity.Count; i++)
            {
                if (entity[i].IsSelected && (claims.Contains(new Claim(entity[i].ClaimType, entity[i].ClaimValue))))
                {
                    continue;
                }
                else if (entity[i].IsSelected && !(claims.Contains(new Claim(entity[i].ClaimType, entity[i].ClaimValue))))
                {
                    var result = await _roleManager.AddClaimAsync(role, new Claim(entity[i].ClaimType, entity[i].ClaimValue));

                }
                else if (!entity[i].IsSelected && (claims.Contains(new Claim(entity[i].ClaimType, entity[i].ClaimValue))))
                {
                    var result = await _roleManager.RemoveClaimAsync(role, new Claim(entity[i].ClaimType, entity[i].ClaimValue));
                }
                else if (!entity[i].IsSelected && !(claims.Contains(new Claim(entity[i].ClaimType, entity[i].ClaimValue))))
                {
                    var result = await _roleManager.RemoveClaimAsync(role, new Claim(entity[i].ClaimType, entity[i].ClaimValue));
                }
                else { continue; }
            }
        }
    }
}
