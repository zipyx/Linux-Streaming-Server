using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Clam.Interface.Academia;
using Clam.Areas.Academia.Models;
using Clam.Utilities;
using ClamDataLibrary.DataAccess;
using ClamDataLibrary.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Clam.Repository.Academia
{
    public class AcademiaRepository : IAcademiaRepository
    {
        private readonly UserManager<ClamUserAccountRegister> _userManager;
        private readonly ClamUserAccountContext _context;
        private readonly IMapper _mapper;
        private readonly string _targetFolderPath;

        public AcademiaRepository(ClamUserAccountContext context, UserManager<ClamUserAccountRegister> userManager,
            IMapper mapper, IConfiguration config)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
            _targetFolderPath = config.GetValue<string>("AbsoluteFilePath-Acad");
        }

        public async Task AddAsyncCategory(SectionAcademicRegister model)
        {
            ClamSectionAcademicCategory result = new ClamSectionAcademicCategory
            {
                //AcademicId = model.AcademicId,
                AcademicDisciplineDescription = model.AcademicDisciplineDescription,
                AcademicDisciplineTitle = model.AcademicDisciplineTitle
            };
            // TODO: Add insert logic here
            await _context.ClamSectionAcademicCategories.AddAsync(result);
            Task.WaitAll(_context.SaveChangesAsync());
        }

        public void AddCategory(SectionAcademicRegister model)
        {
            ClamSectionAcademicCategory result = new ClamSectionAcademicCategory
            {
                //AcademicId = model.AcademicId,
                AcademicDisciplineDescription = model.AcademicDisciplineDescription,
                AcademicDisciplineTitle = model.AcademicDisciplineTitle
            };
            // TODO: Add insert logic here
            _context.ClamSectionAcademicCategories.Add(result);
            Task.WaitAll(_context.SaveChangesAsync());
        }

        public async Task AddAsyncSection(Guid id, SectionRegister entity)
        {
            ClamSectionAcademicSubCategory model = new ClamSectionAcademicSubCategory
            {
                SubCategoryTitle = entity.SubCategoryTitle,
                SubCategoryDescription = entity.SubCategoryDescription,
                AcademicId = id
            };
            await _context.ClamSectionAcademicSubCategories.AddAsync(model);
            Task.WaitAll(_context.SaveChangesAsync());
        }

        public void AddSection(Guid id, SectionRegister entity)
        {
            ClamSectionAcademicSubCategory model = new ClamSectionAcademicSubCategory
            {
                SubCategoryTitle = entity.SubCategoryTitle,
                SubCategoryDescription = entity.SubCategoryDescription,
                AcademicId = id
            };
            _context.ClamSectionAcademicSubCategories.Add(model);
            Task.WaitAll(_context.SaveChangesAsync());
        }

        public async Task<IEnumerable<SectionAcademicRegister>> GetAllCategories()
        {
            var result = await _context.ClamSectionAcademicCategories.ToListAsync();
            var subCount = await _context.ClamSectionAcademicSubCategories.ToListAsync();
            var subItemCount = await _context.ClamSectionAcademicSubCategoryItems.ToListAsync();
            List<SectionAcademicRegister> model = new List<SectionAcademicRegister>();
            foreach (var item in result)
            {
                var test = item.AcademicId;
                model.Add(new SectionAcademicRegister()
                {
                    AcademicId = item.AcademicId,
                    AcademicDisciplineTitle = item.AcademicDisciplineTitle,
                    AcademicDisciplineDescription = item.AcademicDisciplineDescription,
                    LastModified = item.LastModified,
                    DateAdded = item.DateAdded,
                    UrlCategory = FilePathUrlHelper.UrlString(item.AcademicDisciplineTitle),
                    SubCategoryCount = subCount.Select(x => x.AcademicId).Where(x => x.Equals(test)).Count(),
                    SubCategoryItemCount = subItemCount.Select(x => x.AcademicId).Where(x => x.Equals(test)).Count()
                });
            }
            return model;
        }

        public async Task<SectionAcademicRegister> GetCategory(Guid id)
        {
            var model = await _context.ClamSectionAcademicCategories.FindAsync(id);
            Task.FromResult(model).Wait();
            return _mapper.Map<SectionAcademicRegister>(model);
        }

        public async Task<StreamFileUploadDatabase> GetSectionEpisodes(Guid id, Guid sub, string category, string section)
        {
            var model = await _context.ClamSectionAcademicSubCategoryItems.AsNoTracking().ToListAsync();
            List<SectionItem> result = new List<SectionItem>();
            foreach (var item in model)
            {
                if (item.SubCategoryId == sub && item.AcademicId == id)
                {
                    result.Add(new SectionItem()
                    {
                        ItemId = item.ItemId,
                        ItemTitle = FilePathUrlHelper.GetFileName(item.ItemTitle),
                        ItemPath = item.ItemPath,
                        ItemDescription = item.ItemDescription,
                        LastModified = item.LastModified,
                        DateAdded = item.DateAdded,
                        Size = item.Size,
                        UrlCategory = category,
                        UrlSection = section,
                        UrlSectionItem = FilePathUrlHelper.UrlString(FilePathUrlHelper.GetFileName(item.ItemTitle))
                    });
                }
            }
            StreamFileUploadDatabase episodes = new StreamFileUploadDatabase() { SectionItems = result };
            episodes.AcademicId = id;
            episodes.SubCategoryId = sub;
            return episodes;
        }

        public async Task<IEnumerable<SectionRegister>> GetSections(Guid id, string category)
        {
            var model = _context.ClamSectionAcademicSubCategories.Any(x => x.AcademicId.Equals(id));
            var name = await _context.ClamSectionAcademicCategories.FindAsync(id);
            List<SectionRegister> list = new List<SectionRegister>();
            if (model == true)
            {
                var capture = _context.ClamSectionAcademicCategories.Select(x => x.ClamSectionAcademicSubCategories.Where(a => a.AcademicId.Equals(id)).ToList());
                var separateVideos = await _context.ClamSectionAcademicSubCategoryItems.ToListAsync();

                foreach (var item in capture)
                {
                    foreach (var content in item)
                    {
                        var subId = content.SubCategoryId;
                        list.Add(new SectionRegister()
                        {
                            SubCategoryId = content.SubCategoryId,
                            SubCategoryTitle = content.SubCategoryTitle,
                            SubCategoryDescription = content.SubCategoryDescription,
                            LastModified = content.LastModified,
                            DateAdded = content.DateAdded,
                            AcademicId = content.AcademicId,
                            UrlCategory = FilePathUrlHelper.UrlString(category),
                            UrlSection = FilePathUrlHelper.UrlString(content.SubCategoryTitle),
                            VideoCount = separateVideos.Select(x => x.SubCategoryId).Where(x => x.Equals(subId)).Count()
                        });
                    }
                }
                return list;
            }
            return list;
        }

        public async Task<SectionItem> GetVideo(Guid id)
        {
            var model = await _context.ClamSectionAcademicSubCategoryItems.FindAsync(id);
            return _mapper.Map<SectionItem>(model);
        }

        public async Task RemoveCategory(Guid id)
        {
            var model = await _context.ClamSectionAcademicCategories.FindAsync(id);
            var physicalCategoryDirectoryPath = Path.Combine(_targetFolderPath, id.ToString());
            if (Directory.Exists(physicalCategoryDirectoryPath))
            {
                Directory.Delete(physicalCategoryDirectoryPath, true);
            }
            _context.ClamSectionAcademicCategories.Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveSection(Guid id, SectionRegister entity)
        {
            var model = await _context.ClamSectionAcademicSubCategories.FindAsync(entity.SubCategoryId);
            var keyDirPhysicalPath = Path.Combine(model.AcademicId.ToString(), entity.SubCategoryId.ToString());
            var subDirPhysicalPath = Path.Combine(_targetFolderPath, keyDirPhysicalPath);
            if (Directory.Exists(subDirPhysicalPath))
            {
                Directory.Delete(subDirPhysicalPath, true);
            }
            _context.ClamSectionAcademicSubCategories.Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCategory(Guid id, SectionAcademicRegister formData)
        {
            var model = await _context.ClamSectionAcademicCategories.FindAsync(id);
            _context.Entry(model).Entity.AcademicDisciplineDescription = formData.AcademicDisciplineDescription;
            _context.Entry(model).Entity.AcademicDisciplineTitle = formData.AcademicDisciplineTitle;
            _context.Entry(model).Entity.LastModified = DateTime.Now;
            _context.Entry(model).State = EntityState.Modified;
            _context.Update(model);
            Task.WaitAll(_context.SaveChangesAsync());
        }

        public async Task UpdateSection(Guid id, SectionRegister entity)
        {
            var captureModel = await _context.ClamSectionAcademicSubCategories.FindAsync(entity.SubCategoryId);
            _context.Entry(captureModel).Entity.SubCategoryTitle = entity.SubCategoryTitle;
            _context.Entry(captureModel).Entity.SubCategoryDescription = entity.SubCategoryDescription;
            _context.Entry(captureModel).Entity.LastModified = DateTime.Now;
            _context.Entry(captureModel).State = EntityState.Modified;
            _context.Update(captureModel);
            await _context.SaveChangesAsync();
        }

        public async Task<SectionRegister> GetSelectedSection(Guid id)
        {
            var model = await _context.ClamSectionAcademicSubCategories.FindAsync(id);
            return _mapper.Map<SectionRegister>(model);
        }

        public async Task<IEnumerable<AllSectionItems>> GetAllEpisodes()
        {
            var model = await _context.ClamSectionAcademicSubCategoryItems.AsNoTracking().ToListAsync();
            List<AllSectionItems> result = new List<AllSectionItems>();
            foreach (var item in model)
            {
                result.Add(_mapper.Map<AllSectionItems>(item));
            }
            return result;
        }

        public async Task RemoveVideo(Guid id)
        {
            var requestFile = await _context.ClamSectionAcademicSubCategoryItems.FindAsync(id);
            int index = requestFile.ItemPath.LastIndexOf(@"\");
            File.Delete(requestFile.ItemPath);
            Directory.Delete(requestFile.ItemPath.Substring(0, index));
            _context.ClamSectionAcademicSubCategoryItems.Remove(requestFile);
            await _context.SaveChangesAsync();
        }
    }
}
