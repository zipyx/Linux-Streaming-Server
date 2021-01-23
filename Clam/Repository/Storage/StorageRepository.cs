using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Clam.Areas.Storage.Models;
using Clam.Interface.Storage;
using Clam.Utilities;
using Clam.Utilities.Security;
using ClamDataLibrary.DataAccess;
using ClamDataLibrary.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Clam.Repository.Storage
{
    public class StorageRepository : Repository<ClamUserPersonalCategoryItem>, IStorageRepository
    {
        private readonly UserManager<ClamUserAccountRegister> _userManager;
        private new readonly ClamUserAccountContext _context;
        private readonly IMapper _mapper;

        private readonly string _targetFolderPath;
        private readonly string _targetFilePath;

        public StorageRepository(ClamUserAccountContext context, UserManager<ClamUserAccountRegister> userManager, 
            IConfiguration config, IMapper mapper) : base(context)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
            _targetFilePath = config.GetValue<string>("AbsoluteRootFilePathStore");
            _targetFolderPath = config.GetValue<string>("AbsoluteFilePath-Storage");
        }

        public async Task<IEnumerable<AreaUserPersonalCategoryItems>> GetAllUserFiles(string userName)
        {
            var userProfile = await _userManager.FindByNameAsync(userName);

            List<AreaUserPersonalCategoryItems> displyFilesOfUser = new List<AreaUserPersonalCategoryItems>();
            var userFiles = await _context.ClamUserPersonalCategoryItems.ToListAsync();

            foreach (var file in userFiles)
            {
                if (file.UserId.Equals(userProfile.Id))
                {
                    displyFilesOfUser.Add(new AreaUserPersonalCategoryItems()
                    {
                        ItemId = file.ItemId,
                        FileName = file.FileName,
                        ItemPath = file.ItemPath,
                        Size = file.Size,
                        FileType = Path.GetExtension(file.FileName),
                        DateCreated = file.DateCreated
                    });
                }
            }
            return displyFilesOfUser;
        }

        public async Task<AreaUserPersonalCategoryItems> GetFile(Guid id)
        {
            var model = await _context.ClamUserPersonalCategoryItems.FindAsync(id);
            AreaUserPersonalCategoryItems result = new AreaUserPersonalCategoryItems()
            {
                ItemId = model.ItemId,
                FileName = model.FileName,
                ItemPath = FilePathUrlHelper.DataFilePathFilter(model.ItemPath, 3)
            };
            return result;
        }

        public async Task<StreamStorageFile> GetStorageHome(string userName)
        {
            var userProfile = await _userManager.FindByNameAsync(userName);
            // Load Model
            StreamStorageFile FileHome = new StreamStorageFile();

            // Retrieve data to display
            long totalFileSizeCount = 0;
            List<AreaUserPersonalCategoryItems> displyFilesOfUser = new List<AreaUserPersonalCategoryItems>();
            var userFiles = await _context.ClamUserPersonalCategoryItems.ToListAsync();

            foreach (var file in userFiles)
            {
                if (file.UserId.Equals(userProfile.Id))
                {
                    displyFilesOfUser.Add(new AreaUserPersonalCategoryItems()
                    {
                        ItemId = file.ItemId,
                        FileName = file.FileName,
                        ItemPath = file.ItemPath,
                        Size = file.Size,
                        FileType = Path.GetExtension(file.FileName),
                        DateCreated = file.DateCreated
                    });
                    totalFileSizeCount += file.Size;
                }
            }

            FileHome.AreaUserPersonalCategoryItems = displyFilesOfUser;
            return FileHome;
        }

        public async Task RemoveFile(Guid id)
        {
            var model = await _context.ClamUserPersonalCategoryItems.FindAsync(id);
            var result = FilePathUrlHelper.DataFilePathFilterIndex(model.ItemPath, 4);
            var path = model.ItemPath.Substring(0, result);
            Directory.Delete(path, true);
            _context.ClamUserPersonalCategoryItems.Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task UploadFiles(StreamStorageFile files, string userName)
        {
            // User Profile
            var profile = await _userManager.FindByNameAsync(userName);

            // Accumulate the form data key-value pairs in the request (formAccumulator).
            var trustedFileNameForDisplay = string.Empty;
            var untrustedFileNameForStorage = string.Empty;
            var trustedFilePathStorage = string.Empty;
            var trustedFileNameForFileStorage = string.Empty;

            // Test Files
            List<ClamUserPersonalCategoryItem> userFiles = new List<ClamUserPersonalCategoryItem>();

            foreach (var file in files.File)
            {

                untrustedFileNameForStorage = file.FileName;
                // Don't trust the file name sent by the client. To display
                // the file name, HTML-encode the value.
                trustedFileNameForDisplay = WebUtility.HtmlEncode(
                        file.FileName);

                if (!Directory.Exists(_targetFilePath))
                {
                    string path = String.Format("{0}", _targetFilePath);
                    Directory.CreateDirectory(path);
                }

                // Bind form data to the model
                var keyPathFolder = FilePathUrlHelper.GenerateKeyPath(profile.Id);
                var generateKeyFolder = GenerateSecurity.Encode(profile.Id);

                trustedFilePathStorage = String.Format("{0}\\{1}\\{2}\\{3}",
                _targetFolderPath,
                keyPathFolder,
                generateKeyFolder,
                Path.GetRandomFileName());
                Directory.CreateDirectory(trustedFilePathStorage);

                using (var fileStream = new FileStream(Path.Combine(trustedFilePathStorage, untrustedFileNameForStorage),
                    FileMode.Create, FileAccess.Write))
                {
                    await file.CopyToAsync(fileStream);
                    fileStream.Close();
                }

                userFiles.Add(new ClamUserPersonalCategoryItem()
                {
                    FileName = trustedFileNameForDisplay,
                    ItemPath = Path.Combine(trustedFilePathStorage, untrustedFileNameForStorage),
                    Size = file.Length,
                    UserId = profile.Id,
                    DateCreated = DateTime.Now,
                    LastModified = DateTime.Now
                });
            }
            Task.WaitAll(_context.AddRangeAsync(userFiles));
            Task.WaitAll(_context.SaveChangesAsync());
        }
    }
}
