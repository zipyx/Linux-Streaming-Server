using AutoMapper;
using Clam.Areas.Projects.Models;
using Clam.Interface.Projects;
using Clam.Utilities;
using ClamDataLibrary.DataAccess;
using ClamDataLibrary.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;
using Clam.Utilities.Security;

namespace Clam.Repository.Projects
{
    public class ProjectsRepository : Repository<ClamUserProjects>, IProjectsRepository
    {
        private readonly UserManager<ClamUserAccountRegister> _userManager;
        private new readonly ClamUserAccountContext _context;
        private readonly IMapper _mapper;

        // Form File Size Limits and Restricted Extentions
        private readonly string[] _permittedExtentions = { ".jpg", ".png", ".jpeg", ".gif" };
        private readonly string _targetFolderPath;
        private readonly long _fileSizeLimit;

        public ProjectsRepository(ClamUserAccountContext context, UserManager<ClamUserAccountRegister> userManager,
            IMapper mapper, IConfiguration config) : base(context)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;

            _targetFolderPath = config.GetValue<string>("AbsoluteFilePath-Project");
            _fileSizeLimit = config.GetValue<long>("ImageSizeLimit");
        }

        public async Task AddAsyncInterests(ProjectImageData model, ModelStateDictionary modelState, string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var trustedFileNameForDisplay = string.Empty;
            var streamedFileImageContent = new byte[0];
            var untrustedFileNameForStorage = string.Empty;
            var trustedFilePathStorage = string.Empty;
            var trustedFileNameForFileStorage = string.Empty;

            var test = string.Empty;

            streamedFileImageContent =
                await FileHelpers.ProcessFormFile<ProjectFormData>(
                    model.File, modelState, _permittedExtentions,
                    _fileSizeLimit);

            if (!modelState.IsValid)
            {
                test = "ModelState is Invalid";
            }

            untrustedFileNameForStorage = model.File.FileName;
            // Don't trust the file name sent by the client. To display
            // the file name, HTML-encode the value.
            trustedFileNameForDisplay = WebUtility.HtmlEncode(
                    model.File.FileName);

            // Bind form data to the model
            var keyPathFolder = FilePathUrlHelper.GenerateKeyPath(user.Id);
            var generateKeyFolder = GenerateSecurity.Encode(user.Id);

            // Path Location & Directory Check
            trustedFilePathStorage = String.Format("{0}\\{1}\\{2}\\{3}",
                _targetFolderPath,
                keyPathFolder,
                generateKeyFolder,
                Path.GetRandomFileName());

            Directory.CreateDirectory(trustedFilePathStorage);

            using (var fileStream = new FileStream(Path.Combine(trustedFilePathStorage, untrustedFileNameForStorage),
                    FileMode.Create, FileAccess.Write))
            {
                await model.File.CopyToAsync(fileStream);
                fileStream.Close();
            }

            ClamProjectInterestsImageDisplay result = new ClamProjectInterestsImageDisplay()
            {
                Title = Path.GetFileNameWithoutExtension(model.File.FileName),
                ImageLocation = Path.Combine(trustedFilePathStorage, untrustedFileNameForStorage),
                Status = bool.Parse(model.Status),
                UserId = user.Id,
                LastModified = DateTime.Now,
                DateCreated = DateTime.Now
            };

            await _context.AddAsync(result);
            await _context.SaveChangesAsync();
        }

        public async Task AddAsyncProject(ProjectFormData model, ModelStateDictionary modelState, string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var trustedFileNameForDisplay = string.Empty;
            var streamedFileImageContent = new byte[0];
            var untrustedFileNameForStorage = string.Empty;
            var trustedFilePathStorage = string.Empty;
            var trustedFileNameForFileStorage = string.Empty;

            var test = string.Empty;

            streamedFileImageContent =
                await FileHelpers.ProcessFormFile<ProjectFormData>(
                    model.File, modelState, _permittedExtentions,
                    _fileSizeLimit);

            if (!modelState.IsValid)
            {
                test = "ModelState is Invalid";
            }

            untrustedFileNameForStorage = model.File.FileName;
            // Don't trust the file name sent by the client. To display
            // the file name, HTML-encode the value.
            trustedFileNameForDisplay = WebUtility.HtmlEncode(
                    model.File.FileName);

            // Bind form data to the model
            var keyPathFolder = FilePathUrlHelper.GenerateKeyPath(user.Id);
            var generateKeyFolder = GenerateSecurity.Encode(user.Id);

            // Path Location & Directory Check
            trustedFilePathStorage = String.Format("{0}\\{1}\\{2}\\{3}",
                _targetFolderPath,
                keyPathFolder,
                generateKeyFolder,
                Path.GetRandomFileName());

            Directory.CreateDirectory(trustedFilePathStorage);

            using (var fileStream = new FileStream(Path.Combine(trustedFilePathStorage, untrustedFileNameForStorage),
                    FileMode.Create, FileAccess.Write))
            {
                await model.File.CopyToAsync(fileStream);
                fileStream.Close();
            }

            ClamUserProjects result = new ClamUserProjects()
            {
                Author = user.FirstName,
                Title = model.Title,
                Description = model.Description,
                ImageGifLocation = Path.Combine(trustedFilePathStorage, untrustedFileNameForStorage),
                Language = model.Language,
                GithubLink = model.GithubLink,
                Status = bool.Parse(model.Status),
                UserId = user.Id,
                LastModified = DateTime.Now,
                DateCreated = DateTime.Now
            };
            await _context.AddAsync(result);
            await _context.SaveChangesAsync();
        }

        public async Task AddInterests(ProjectImageData model, ModelStateDictionary modelState, string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var trustedFileNameForDisplay = string.Empty;
            var streamedFileImageContent = new byte[0];
            var untrustedFileNameForStorage = string.Empty;
            var trustedFilePathStorage = string.Empty;
            var trustedFileNameForFileStorage = string.Empty;

            var test = string.Empty;

            streamedFileImageContent =
                await FileHelpers.ProcessFormFile<ProjectFormData>(
                    model.File, modelState, _permittedExtentions,
                    _fileSizeLimit);

            if (!modelState.IsValid)
            {
                test = "ModelState is Invalid";
            }

            untrustedFileNameForStorage = model.File.FileName;
            // Don't trust the file name sent by the client. To display
            // the file name, HTML-encode the value.
            trustedFileNameForDisplay = WebUtility.HtmlEncode(
                    model.File.FileName);

            // Bind form data to the model
            var keyPathFolder = FilePathUrlHelper.GenerateKeyPath(user.Id);
            var generateKeyFolder = GenerateSecurity.Encode(user.Id);

            // Path Location & Directory Check
            trustedFilePathStorage = String.Format("{0}\\{1}\\{2}\\{3}",
                _targetFolderPath,
                keyPathFolder,
                generateKeyFolder,
                Path.GetRandomFileName());

            Directory.CreateDirectory(trustedFilePathStorage);

            using (var fileStream = new FileStream(Path.Combine(trustedFilePathStorage, untrustedFileNameForStorage),
                    FileMode.Create, FileAccess.Write))
            {
                await model.File.CopyToAsync(fileStream);
                fileStream.Close();
            }

            ClamProjectInterestsImageDisplay result = new ClamProjectInterestsImageDisplay()
            {
                Title = Path.GetFileNameWithoutExtension(model.File.FileName),
                ImageLocation = Path.Combine(trustedFilePathStorage, untrustedFileNameForStorage),
                Status = bool.Parse(model.Status),
                UserId = user.Id,
                LastModified = DateTime.Now,
                DateCreated = DateTime.Now
            };

            await _context.AddAsync(result);
            await _context.SaveChangesAsync();
        }

        public async Task AddProject(ProjectFormData model, ModelStateDictionary modelState, string userName)
        {

            var user = await _userManager.FindByNameAsync(userName);
            var trustedFileNameForDisplay = string.Empty;
            var streamedFileImageContent = new byte[0];
            var untrustedFileNameForStorage = string.Empty;
            var trustedFilePathStorage = string.Empty;
            var trustedFileNameForFileStorage = string.Empty;

            var test = string.Empty;

            streamedFileImageContent =
                await FileHelpers.ProcessFormFile<ProjectFormData>(
                    model.File, modelState, _permittedExtentions,
                    _fileSizeLimit);

            if (!modelState.IsValid)
            {
                test = "ModelState is Invalid";
            }

            untrustedFileNameForStorage = model.File.FileName;
            // Don't trust the file name sent by the client. To display
            // the file name, HTML-encode the value.
            trustedFileNameForDisplay = WebUtility.HtmlEncode(
                    model.File.FileName);

            // Bind form data to the model
            var keyPathFolder = FilePathUrlHelper.GenerateKeyPath(user.Id);
            var generateKeyFolder = GenerateSecurity.Encode(user.Id);

            // Path Location & Directory Check
            trustedFilePathStorage = String.Format("{0}\\{1}\\{2}\\{3}",
                _targetFolderPath,
                keyPathFolder,
                generateKeyFolder,
                Path.GetRandomFileName());

            Directory.CreateDirectory(trustedFilePathStorage);

            using (var fileStream = new FileStream(Path.Combine(trustedFilePathStorage, untrustedFileNameForStorage),
                    FileMode.Create, FileAccess.Write))
            {
                await model.File.CopyToAsync(fileStream);
                fileStream.Close();
            }

            ClamUserProjects result = new ClamUserProjects()
            {
                Author = user.FirstName,
                Title = model.Title,
                Description = model.Description,
                ImageGifLocation = Path.Combine(trustedFilePathStorage, untrustedFileNameForStorage),
                Language = model.Language,
                GithubLink = model.GithubLink,
                Status = bool.Parse(model.Status),
                UserId = user.Id,
                LastModified = DateTime.Now,
                DateCreated = DateTime.Now
            };
            await _context.AddAsync(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AreaUserProjectsImageInterests>> GetAllInterests(string userName)
        {
            var userProfile = await _userManager.FindByNameAsync(userName);
            var projects = await _context.ClamProjectInterestsImageDisplays.AsNoTracking().ToListAsync();

            // List Model
            List<AreaUserProjectsImageInterests> projectList = new List<AreaUserProjectsImageInterests>();
            foreach (var project in projects)
            {
                if (project.UserId == userProfile.Id)
                {
                    project.ImageLocation = FilePathUrlHelper.DataFilePathFilter(project.ImageLocation, 3);
                    projectList.Add(_mapper.Map<AreaUserProjectsImageInterests>(project));
                }
            }

            // List of Projects
            return projectList;
        }

        public async Task<IEnumerable<AreaUserProjectsImageInterests>> GetAllInterestsHomeDisplay()
        {
            var projects = await _context.ClamProjectInterestsImageDisplays.AsNoTracking().ToListAsync();

            // List Model
            List<AreaUserProjectsImageInterests> projectList = new List<AreaUserProjectsImageInterests>();
            foreach (var project in projects)
            {
                if (project.Status == true)
                {
                    project.ImageLocation = FilePathUrlHelper.DataFilePathFilter(project.ImageLocation, 3);
                    projectList.Add(_mapper.Map<AreaUserProjectsImageInterests>(project));
                }
            }

            // List of Projects
            return projectList;
        }

        public async Task<IEnumerable<AreaUserProjects>> GetAllProjects(string userName)
        {
            var userProfile = await _userManager.FindByNameAsync(userName);
            var projects = await _context.ClamUserProjects.AsNoTracking().ToListAsync();

            // List Model
            List<AreaUserProjects> projectList = new List<AreaUserProjects>();
            foreach (var project in projects)
            {
                if (project.UserId == userProfile.Id)
                {
                    projectList.Add(_mapper.Map<AreaUserProjects>(project));
                }
            }

            // List of Projects
            return projectList;
        }

        public async Task<IEnumerable<AreaUserProjects>> GetAllProjectsHomeDisplay()
        {
            var projects = await _context.ClamUserProjects.AsNoTracking().ToListAsync();

            // List Model
            List<AreaUserProjects> projectList = new List<AreaUserProjects>();
            foreach (var project in projects)
            {
                if (project.Status == true)
                {
                    project.ImageGifLocation = FilePathUrlHelper.DataFilePathFilter(project.ImageGifLocation, 3);
                    projectList.Add(_mapper.Map<AreaUserProjects>(project));
                }
            }

            // List of Projects
            return projectList;
        }

        public async Task<AreaUserProjects> GetAsyncProject(Guid id)
        {
            var model = await _context.ClamUserProjects.FindAsync(id);
            model.ImageGifLocation = FilePathUrlHelper.DataFilePathFilter(model.ImageGifLocation, 3);
            return _mapper.Map<AreaUserProjects>(model);
        }

        public AreaUserProjects GetProject(Guid id)
        {
            var model = _context.ClamUserProjects.Find(id);
            model.ImageGifLocation = FilePathUrlHelper.DataFilePathFilter(model.ImageGifLocation, 3);
            return _mapper.Map<AreaUserProjects>(model);
        }

        public async Task RemoveInterest(Guid id, bool confirm = false)
        {
            var model = await _context.ClamProjectInterestsImageDisplays.FindAsync(id);
            var result = FilePathUrlHelper.DataFilePathFilterIndex(model.ImageLocation, 4);
            var path = model.ImageLocation.Substring(0, result);
            Directory.Delete(path, true);
            if (confirm == true)
            {
                _context.Remove(model);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveProject(Guid id, bool confirm = false)
        {
            var model = await _context.ClamUserProjects.FindAsync(id);
            var result = FilePathUrlHelper.DataFilePathFilterIndex(model.ImageGifLocation, 4);
            var path = model.ImageGifLocation.Substring(0, result);
            Directory.Delete(path, true);
            if (confirm == true)
            {
                _context.Remove(model);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateProject(ProjectFormData model, ModelStateDictionary modelState, Guid id, string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var trustedFileNameForDisplay = string.Empty;
            var streamedFileImageContent = new byte[0];
            var untrustedFileNameForStorage = string.Empty;
            var trustedFilePathStorage = string.Empty;
            var trustedFileNameForFileStorage = string.Empty;
            var checkState = string.Empty;

            // Get Project Id and update all new fields
            var getProject = await _context.ClamUserProjects.FindAsync(id);

            if (model.File != null)
            {
                streamedFileImageContent =
                    await FileHelpers.ProcessFormFile<ProjectFormData>(
                    model.File, modelState, _permittedExtentions,
                    _fileSizeLimit);

                // Filter Check the state of the file
                if (!modelState.IsValid)
                {
                    checkState = "ModelState is Invalid";
                }

                untrustedFileNameForStorage = model.File.FileName;
                // Don't trust the file name sent by the client. To display
                // the file name, HTML-encode the value.
                trustedFileNameForDisplay = WebUtility.HtmlEncode(
                        model.File.FileName);

                // Bind form data to the model
                var keyPathFolder = FilePathUrlHelper.GenerateKeyPath(user.Id);
                var generateKeyFolder = GenerateSecurity.Encode(user.Id);

                // Path Location & Directory Check
                trustedFilePathStorage = String.Format("{0}\\{1}\\{2}\\{3}",
                    _targetFolderPath,
                    keyPathFolder,
                    generateKeyFolder,
                    Path.GetRandomFileName());

                Directory.CreateDirectory(trustedFilePathStorage);

                using (var fileStream = new FileStream(Path.Combine(trustedFilePathStorage, untrustedFileNameForStorage),
                        FileMode.Create, FileAccess.Write))
                {
                    await model.File.CopyToAsync(fileStream);
                    fileStream.Close();
                }
                // Remove Physical Location
                await RemoveProject(id);

                _context.Entry(getProject).Entity.Title = model.Title;
                _context.Entry(getProject).Entity.Author = model.Author;
                _context.Entry(getProject).Entity.Description = model.Description;
                _context.Entry(getProject).Entity.Language = model.Language;
                _context.Entry(getProject).Entity.GithubLink = model.GithubLink;
                _context.Entry(getProject).Entity.Status = bool.Parse(model.Status);
                _context.Entry(getProject).Entity.LastModified = DateTime.Now;
                _context.Entry(getProject).Entity.ImageGifLocation = Path.Combine(trustedFilePathStorage, untrustedFileNameForStorage);
                _context.Update(getProject);
                await _context.SaveChangesAsync();

            }
            else
            {
                _context.Entry(getProject).Entity.Title = model.Title;
                _context.Entry(getProject).Entity.Author = model.Author;
                _context.Entry(getProject).Entity.Description = model.Description;
                _context.Entry(getProject).Entity.Language = model.Language;
                _context.Entry(getProject).Entity.GithubLink = model.GithubLink;
                _context.Entry(getProject).Entity.Status = bool.Parse(model.Status);
                _context.Entry(getProject).Entity.LastModified = DateTime.Now;
                _context.Update(getProject);
                await _context.SaveChangesAsync();
            }

        }
    }
}
