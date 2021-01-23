using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Clam.Models;
using Clam.Repository;
using Clam.Areas.Projects.Models;

namespace Clam.Controllers
{
    public class HomeController : Controller
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _unitOfWork.ProjectControl.GetAllProjectsHomeDisplay();
            var interests = await _unitOfWork.ProjectControl.GetAllInterestsHomeDisplay();
            ProjectHome home = new ProjectHome();
            home.AreaUserProjects = model;
            home.AreaUserProjectsImageInterests = interests;
            return View(home);
        }

        [HttpGet("privacy-policy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet("disclaimer")]
        public IActionResult Disclaimer()
        {
            return View();
        }

        [HttpGet("terms-and-conditions")]
        public IActionResult TermsAndConditions()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
