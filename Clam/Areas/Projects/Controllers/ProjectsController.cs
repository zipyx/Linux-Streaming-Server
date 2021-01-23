using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Clam.Areas.Projects.Models;
using Clam.Areas.Tickets.Models;
using Clam.Repository;
using ClamDataLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;

namespace Clam.Areas.Projects.Controllers
{
    [Authorize(Policy = "Project-Owner")]
    [Area("Projects")]
    [Route("projects")]
    public class ProjectsController : Controller
    {
        private readonly UserManager<ClamUserAccountRegister> _userManager;
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;

        // Form File Size Limits and Restricted Extentions
        private readonly string[] _permittedExtentions = { ".jpg", ".png", ".jpeg", ".gif" };
        private readonly string _targetFolderPath;
        private readonly long _fileSizeLimit;

        public ProjectsController(UserManager<ClamUserAccountRegister> userManager, IMapper mapper, UnitOfWork unitOfWork,
            IConfiguration config)
        {
            _userManager = userManager;
            _mapper = mapper;
            _unitOfWork = unitOfWork;

            _targetFolderPath = config.GetValue<string>("AbsoluteFilePath-Project");
            _fileSizeLimit = config.GetValue<long>("ImageSizeLimit");
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userName = User.Identity.Name;
            var model = await _unitOfWork.ProjectControl.GetAllProjects(userName);
            var interests = await _unitOfWork.ProjectControl.GetAllInterests(userName);

            // Model Listing
            List<SelectListItem> selectViewChoice = new List<SelectListItem>();
            var selector = new Dictionary<string, bool>()
            {
                { "Public", true },
                { "Private", false }
            };
            foreach (var value in selector)
            {
                selectViewChoice.Add(new SelectListItem() { Text = value.Key, Value = value.Value.ToString() });
            }

            // Model Listing
            ViewBag.SelectionStatus = selectViewChoice;
            ProjectHome projectPanel = new ProjectHome();
            projectPanel.AreaUserProjects = model;
            projectPanel.AreaUserProjectsImageInterests = interests;
            return View(projectPanel);
        }

        [HttpGet("details/{id}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var model = await _unitOfWork.ProjectControl.GetAsyncProject(id);
            return View(model);
        }

        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProjectHome model)
        {
            try
            {
                // Perform an initial check to catch FileUpload class
                // attribute violations.
                if (!(ModelState.IsValid) || !(User.Identity.IsAuthenticated))
                {
                    return View();
                }
                await _unitOfWork.ProjectControl.AddProject(model.ProjectFormData, ModelState, User.Identity.Name);
                _unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                //return View();
                return Created(nameof(ProjectsController), null);
            }
        }

        [HttpPost("upload-image-interests")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddInterests(ProjectHome model)
        {
            try
            {
                // Perform an initial check to catch FileUpload class
                // attribute violations.
                if (!(ModelState.IsValid) || !(User.Identity.IsAuthenticated))
                {
                    return View();
                }
                await _unitOfWork.ProjectControl.AddAsyncInterests(model.ProjectImageData, ModelState, User.Identity.Name);
                _unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                //return View();
                return Created(nameof(ProjectsController), null);
            }
        }

        [HttpPost("Update")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(IFormCollection model)
        {
            try
            {
                // Perform an initial check to catch FileUpload class
                // attribute violations.
                if (!(ModelState.IsValid) || !(User.Identity.IsAuthenticated))
                {
                    return View();
                }

                if (model.Files.Count > 0)
                {
                    ProjectFormData result = new ProjectFormData()
                    {
                        Title = model["item.Title"],
                        Author = model["item.Author"],
                        Description = model["item.Description"],
                        Language = model["item.Language"],
                        GithubLink = model["item.GithubLink"],
                        Status = model["item.Status"].ToString(),
                        File = model.Files[0]
                    };

                    await _unitOfWork.ProjectControl.UpdateProject(result, ModelState, Guid.Parse(model["item.ProjectId"]), User.Identity.Name);
                    _unitOfWork.Complete();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ProjectFormData result = new ProjectFormData()
                    {
                        Title = model["item.Title"],
                        Author = model["item.Author"],
                        Description = model["item.Description"],
                        Language = model["item.Language"],
                        GithubLink = model["item.GithubLink"],
                        Status = model["item.Status"].ToString()
                    };

                    await _unitOfWork.ProjectControl.UpdateProject(result, ModelState, Guid.Parse(model["item.ProjectId"]), User.Identity.Name);
                    _unitOfWork.Complete();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View();
            }
        }

        [HttpPost("remove")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Remove(Guid id)
        {
            // Add user roles permissions/policy to secure remove function even more. User.isInRoles(), policy = ""... etc.
            if (User.Identity.IsAuthenticated)
            {
                await _unitOfWork.ProjectControl.RemoveProject(id, true);
                _unitOfWork.Complete();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost("remove-interests")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveInterests(Guid id)
        {
            // Add user roles permissions/policy to secure remove function even more. User.isInRoles(), policy = ""... etc.
            if (User.Identity.IsAuthenticated)
            {
                await _unitOfWork.ProjectControl.RemoveInterest(id, true);
                _unitOfWork.Complete();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}