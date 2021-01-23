using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clam.Models;
using Clam.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.CodeAnalysis;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Authorization;

namespace Clam.Controllers
{
    [Authorize(Policy = "Account-Access")]
    [Route("manage/accounts")]
    public class AccountController : Controller
    {

        private readonly UnitOfWork _unitOfWork;

        public AccountController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Account
        [HttpGet]
        public IActionResult Index()
        {
            return View(_unitOfWork.UserAccount.GetAllUserAccounts());
        }

        // GET: Account/Details/5
        [HttpGet("details/{id}")]
        public async Task<IActionResult> Details(Guid id)
        {
            ViewBag.UserId = id;
            var result = await _unitOfWork.UserAccount.GetAccount(id);
            return View(result);
        }

        // GET: Account/Create
        [HttpGet("create")]
        public IActionResult Create()
        {
            var result = _unitOfWork.UserAccount.GetAllRoles();
            List<SelectListItem> list = new List<SelectListItem>();
            List<SelectListItem> genderSelection = new List<SelectListItem>();
            foreach (var role in result)
            {
                list.Add(new SelectListItem() { Text = role.Name, Value = role.Name });
            }
            foreach (var gender in Enum.GetValues(typeof(Gender)))
            {
                genderSelection.Add(new SelectListItem() { Text = gender.ToString(), Value = gender.ToString() });
            }
            ViewBag.GenderSelection = genderSelection;
            ViewBag.Roles = list;
            return View();
        }

        // POST: Account/Create
        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserAccountRegister model)
        {
            try
            {
                await _unitOfWork.UserAccount.AddAccount(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Account/Edit/5
        [HttpGet("edit/{id}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            ViewBag.UserId = id;
            var result = await _unitOfWork.UserAccount.EditAccount(id);
            return View(result);
        }

        // POST: Account/Edit/5
        [HttpPost("edit/{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, UserAccountRegister collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add update logic here
                    _unitOfWork.UserAccount.SaveAccount(id, collection);
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Account/Delete/5
        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var model = await _unitOfWork.UserAccount.GetAccount(id);
            return View(model);
        }

        // POST: Account/Delete/5
        [HttpPost("delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id, UserAccountInformation collection)
        {
            try
            {
                await _unitOfWork.UserAccount.RemoveAccount(id);
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }

        // ########################################################################################
        // ########################################################################################
        // ########################################################################################
        // ############################################################################## Roles
        [HttpGet("roles/{id}")]
        public IActionResult ManageUserRoles(AccountUserRoles model, Guid id)
        {
            ViewBag.UserId = id;
            var result = _unitOfWork.UserAccount.GetManageUserRole(model, id);
            List<AccountUserRoles> modelview = new List<AccountUserRoles>();
            result.Wait();
            if (result.IsCompleted == true)
            {
                foreach (var item in result.Result)
                {
                    modelview.Add(new AccountUserRoles() { UserId = item.UserId, RoleId = item.RoleId, RoleName = item.RoleName, IsSelected = item.IsSelected });
                }
                return View(modelview);
            } else
            {
                var x = Task.Run(() => result);
                x.Wait();
                if (x.IsCompleted == true)
                {
                    return View(x);
                }
            }

            return View(modelview);
        }

        [HttpPost("roles/{id}")]
        public IActionResult ManageUserRoles(List<AccountUserRoles> model, Guid id)
        {
            Task.WaitAll(_unitOfWork.UserAccount.PostManageUserRole(model, id));
            return RedirectToAction(nameof(Edit), new {Id = id });
        }

        // #########################################################################################
        // #########################################################################################
        // #########################################################################################
        // ############################################################################### Claims
        [HttpGet("claims/{id}")]
        public IActionResult ManageUserClaims(Guid id)
        {
            ViewBag.UserId = id;
            var result = _unitOfWork.UserAccount.GetManageUserClaim(id);
            result.Wait();
            List<ClaimAccountRegister> model = new List<ClaimAccountRegister>();
            foreach (var item in result.Result.UserClaims)
            {
                model.Add(new ClaimAccountRegister() { ClaimType = item.ClaimType, ClaimValue = item.ClaimValue, IsSelected = item.IsSelected });
            }
            return View(model);
        }

        [HttpPost("claims/{id}")]
        public IActionResult ManageUserClaims(List<ClaimAccountRegister> model, Guid id)
        {
            Task.WaitAll(_unitOfWork.UserAccount.PostManageUserClaim(model, id));
            return RedirectToAction(nameof(Edit), new { Id = id });
        }

        public enum Gender
        {
            Male,
            Female,
            Other
        }
    }
}
