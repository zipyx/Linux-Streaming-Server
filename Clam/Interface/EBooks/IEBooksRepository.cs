using Clam.Areas.EBooks.Models;
using ClamDataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clam.Interface.EBooks
{
    public interface IEBooksRepository : IRepository<ClamUserBooks>
    {

        // EBooks
        Task<IEnumerable<AreaUserBooks>> GetAllUserEBooks(string userName);
        AreaUserBooks GetEBook(Guid id);
        Task<AreaUserBooks> GetAsyncEBook(Guid id);
        Task<IEnumerable<BooksGenreSelection>> GetAllEBooksForGenreSelection(Guid id, string userName);
        Task UpdateAllEBooksGenreSelection(Guid id, List<BooksGenreSelection> model);
        Task UpdateEBook(Guid id, StreamFormDataBooks formData);
        Task RemoveEBook(Guid id);
        Task RemoveRangeEBook(List<AreaUserBooks> model);


        // Book Genre
        Task<IEnumerable<AreaUserBooksCategory>> GetAllGenres();
        void AddGenre(AreaUserBooksCategory model);
        Task AddAsyncGenre(AreaUserBooksCategory model);
        Task RemoveGenre(Guid id);
        AreaUserBooksCategory GetGenre(Guid id);
        Task<AreaUserBooksCategory> GetAsyncGenre(Guid id);
        Task<IEnumerable<BooksGenreSelection>> GetAsyncGenreWithEBooks(Guid id);


        // Home View
        Task<BooksHome> GetDisplayHomeContent(string search = null);
        Task<ReadBook> GetDisplayBook(Guid id);
    }
}
