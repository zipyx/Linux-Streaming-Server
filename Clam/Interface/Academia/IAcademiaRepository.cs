using Clam.Areas.Academia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clam.Interface.Academia
{
    public interface IAcademiaRepository
    {
        // Category
        Task<IEnumerable<SectionAcademicRegister>> GetAllCategories();
        Task<SectionAcademicRegister> GetCategory(Guid id);
        void AddCategory(SectionAcademicRegister model);
        Task AddAsyncCategory(SectionAcademicRegister model);
        Task UpdateCategory(Guid id, SectionAcademicRegister formData);
        Task RemoveCategory(Guid id);

        // Section
        Task<IEnumerable<SectionRegister>> GetSections(Guid id, string category);
        Task<SectionRegister> GetSelectedSection(Guid id);
        void AddSection(Guid id, SectionRegister model);
        Task AddAsyncSection(Guid id, SectionRegister model);
        Task UpdateSection(Guid id, SectionRegister model);
        Task RemoveSection(Guid id, SectionRegister model);

        // Episodes & Video
        Task<StreamFileUploadDatabase> GetSectionEpisodes(Guid id, Guid sub, string category, string section);
        Task<SectionItem> GetVideo(Guid id);
        Task<IEnumerable<AllSectionItems>> GetAllEpisodes();
        Task RemoveVideo(Guid id);

    }
}
