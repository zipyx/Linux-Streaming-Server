using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Clam.Models;
using AutoMapper;
using ClamDataLibrary.Models;
using System.Security.Claims;
using System.Reflection;
using Clam.Repository;

namespace Clam.Controllers
{
    [Route("manage/roles")]
    public class RoleController : Controller
    {
 
        private readonly UnitOfWork _unitOfWork;

        public RoleController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        

        // GET: Role
        [HttpGet]
        public ActionResult Index()
        {
            var model = _unitOfWork.RoleAccount.GetAllRoles();
            return View(model);
        }

        // GET: Role/Details/5
        [HttpGet("details/{id}")]
        public async Task<ActionResult> Details(Guid id)
        {
            var model = await _unitOfWork.RoleAccount.ViewRole(id);
            return View(model);
        }

        // GET: Role/Create
        [HttpGet("create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Role/Create
        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RoleAccountRegister collection)
        {
            try
            {
                await _unitOfWork.RoleAccount.AddRole(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Role/Edit/5
        [HttpGet("edit/{id}")]
        public async Task<ActionResult> Edit(Guid id)
        {
            ViewBag.RoleId = id;
            var model = await _unitOfWork.RoleAccount.ViewRole(id);
            return View(model);
        }

        // POST: Role/Edit/5
        [HttpPost("edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, RoleAccountRegister collection)
        {
            try
            {
                await _unitOfWork.RoleAccount.EditRole(collection, id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // Add Users to Roles
        [HttpGet("update/{id}")]
        public async Task<ActionResult> EditRoleUsers(Guid id)
        {
            ViewBag.roleId = id.ToString();
            var model = await _unitOfWork.RoleAccount.ViewRoleUsers(id);
            return View(model);
        }

        [HttpPost("update/{id}")]
        public async Task<ActionResult> EditRoleUsers(List<RoleAccountUsers> model, Guid roleId)
        {
            await _unitOfWork.RoleAccount.PostRoleUsers(model, roleId);
            return RedirectToAction("Edit", new { Id = roleId });
        }

        // GET: Role/Delete/5
        [HttpGet("delete/{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var model = await _unitOfWork.RoleAccount.ViewRole(id);
            return View(model);
        }

        // POST: Role/Delete/5
        [HttpPost("delete/{id}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id, RoleAccountRegister model)
        {
            try
            {
                await _unitOfWork.RoleAccount.RemoveRole(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet("update/claims/{id}")]
        public async Task<ActionResult> GetManageRoleClaim(Guid id)
        {
            ViewBag.RoleId = id;
            var model = await _unitOfWork.RoleAccount.ViewRoleClaims(id);
            return View(model.RoleClaims);
        }

        [HttpPost("update/claims/{id}"), ActionName("GetManageRoleClaim")]
        public async Task<ActionResult> GetManageRoleClaim(List<ClaimAccountRegister> model, Guid id)
        {
            await _unitOfWork.RoleAccount.PostRoleClaims(model, id);
            Task.WaitAll();
            return RedirectToAction("Edit", new { Id = id });
        }
    }
}