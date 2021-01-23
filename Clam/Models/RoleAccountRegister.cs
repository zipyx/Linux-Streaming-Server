using ClamDataLibrary.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clam.Models
{
    public class RoleAccountRegister
    {
        public RoleAccountRegister()
        {
        }

        public RoleAccountRegister(ClamRoles role)
        {
            Id = role.Id;
            Name = role.Name;
            Users = new List<string>();
            Claims = new List<string>();
        }

        [Display(Name = "Code")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Role Name is Required")]
        public string Name { get; set; }

        public List<string> Users { get; set; } 

        public List<string> Claims { get; set; }

    }

    public class RoleAccountUsers
    {
        public RoleAccountUsers()
        {

        }

        [Display(Name = "Identification Code")]
        public string Id { get; set; }

        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Select")]
        public bool IsSelected { get; set; }
    }

    public class AccountUserRoles
    {
        public AccountUserRoles()
        {

        }
        [Display(Name = "User Identification Code")]
        public Guid UserId { get; set; }

        [Display(Name = "Role Identification Code")]
        public Guid RoleId { get; set; }

        [Display(Name = "Role Name")]
        public string RoleName { get; set; }

        [Display(Name = "Select")]
        public bool IsSelected { get; set; }
    }

    public class AccountRoleClaims
    {
        public AccountRoleClaims()
        {
            RoleClaims = new List<ClaimAccountRegister>();
        }

        [Display(Name = "User Code")]
        public string RoleId { get; set; }

        public List<ClaimAccountRegister> RoleClaims { get; set; }
    }
}
