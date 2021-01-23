using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clam.Repository;
using Clam.Utilities;
using ClamDataLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Clam.Areas.EBooks.Controllers
{
    [Authorize(Policy = "Level-One")]
    [Area("EBooks")]
    [Route("ebooks")]
    public class HomeController : Controller
    {

        private readonly UserManager<ClamUserAccountRegister> _userManager;
        private readonly RoleManager<ClamRoles> _roleManager;
        private readonly UnitOfWork _unitOfWork;

        public HomeController(UserManager<ClamUserAccountRegister> userManager, RoleManager<ClamRoles> roleManager,
            UnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _unitOfWork = unitOfWork;
        }


        // GET: Home
        [HttpGet]
        public async Task<IActionResult> Index(string search)
        {
            // First initial check -> If user not authenticated, deny access
            if (!User.Identity.IsAuthenticated)
            {
                return View("AccessDenied");
            }
            var model = await _unitOfWork.EBooksControl.GetDisplayHomeContent(search);
            return View(model);
        }

        [HttpGet("read/{id}")]
        public async Task<IActionResult> Read(Guid id)
        {
            var result = await _unitOfWork.EBooksControl.GetAsyncEBook(id);
            var model = await _unitOfWork.EBooksControl.GetDisplayBook(id);
            ViewBag.BookPath = FilePathUrlHelper.DataFilePathFilter(result.ItemPath, 3);
            return View(model);
        }
    }
}