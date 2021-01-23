using Clam.Areas.Storage.Models;
using ClamDataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clam.Interface.Storage
{
    public interface IStorageRepository : IRepository<ClamUserPersonalCategoryItem>
    {
        // Storage
        Task<StreamStorageFile> GetStorageHome(string userName);
        Task<IEnumerable<AreaUserPersonalCategoryItems>> GetAllUserFiles(string userName);
        Task<AreaUserPersonalCategoryItems> GetFile(Guid id);
        Task UploadFiles(StreamStorageFile files, string userName);
        Task RemoveFile(Guid id);

    }
}
