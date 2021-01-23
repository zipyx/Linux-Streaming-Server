using Clam.Areas.Projects.Models;
using ClamDataLibrary.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clam.Interface.Projects
{
    public interface IProjectsRepository : IRepository<ClamUserProjects>
    {
        // Get All Projects
        Task<IEnumerable<AreaUserProjects>> GetAllProjects(string userName);
        Task<IEnumerable<AreaUserProjects>> GetAllProjectsHomeDisplay();

        // Add Project
        Task AddProject(ProjectFormData model, ModelStateDictionary modelState, string userName);
        Task AddAsyncProject(ProjectFormData model, ModelStateDictionary modelState, string userName);

        // Update Project
        Task UpdateProject(ProjectFormData model, ModelStateDictionary modelState, Guid id, string userName);

        // Remove Project
        Task RemoveProject(Guid id, bool confirm = false);

        // Get Project
        AreaUserProjects GetProject(Guid id);
        Task<AreaUserProjects> GetAsyncProject(Guid id);

        // Image Interests
        Task<IEnumerable<AreaUserProjectsImageInterests>> GetAllInterests(string userName);
        Task<IEnumerable<AreaUserProjectsImageInterests>> GetAllInterestsHomeDisplay();

        Task AddInterests(ProjectImageData model, ModelStateDictionary modelState, string userName);
        Task AddAsyncInterests(ProjectImageData model, ModelStateDictionary modelState, string userName);

        Task RemoveInterest(Guid id, bool confirm = false);
    }
}
