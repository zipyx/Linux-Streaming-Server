using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Clam.Areas.EBooks.Models;
using Clam.Interface.EBooks;
using Clam.Utilities;
using ClamDataLibrary.DataAccess;
using ClamDataLibrary.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Clam.Repository.EBooks
{
    public class EBooksRepository : Repository<ClamUserBooks>, IEBooksRepository
    {
        private readonly UserManager<ClamUserAccountRegister> _userManager;
        private new readonly ClamUserAccountContext _context;
        private readonly IMapper _mapper;


        public EBooksRepository(ClamUserAccountContext context, UserManager<ClamUserAccountRegister> userManager, IMapper mapper) : base(context)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task AddAsyncGenre(AreaUserBooksCategory model)
        {
            var result = _mapper.Map<ClamUserBooksCategory>(model);
            await _context.ClamUserBooksCategories.AddAsync(result);
            await _context.SaveChangesAsync();
        }

        public void AddGenre(AreaUserBooksCategory model)
        {
            var result = _mapper.Map<ClamUserBooksCategory>(model);
            _context.ClamUserBooksCategories.Add(result);
            _context.SaveChangesAsync();
        }

        public async Task<AreaUserBooks> GetAsyncEBook(Guid id)
        {
            var result = await _context.ClamUserBooks.FindAsync(id);
            return _mapper.Map<AreaUserBooks>(result);
        }

        public async Task<AreaUserBooksCategory> GetAsyncGenre(Guid id)
        {
            var model = await _context.ClamUserBooksCategories.FindAsync(id);
            return _mapper.Map<AreaUserBooksCategory>(model);
        }

        public async Task<IEnumerable<BooksGenreSelection>> GetAsyncGenreWithEBooks(Guid id)
        {
            var books = await _context.ClamUserBooks.ToListAsync();
            var category = await _context.ClamUserBooksCategories.FindAsync(id);
            var joinTable = await _context.ClamUserBooksJoinCategories.ToListAsync();

            List<BooksGenreSelection> model = new List<BooksGenreSelection>();
            foreach (var item in books)
            {
                if (joinTable.Any(val => val.CategoryId == category.CategoryId && val.BookId == item.BookId))
                {
                    model.Add(new BooksGenreSelection()
                    {
                        BookId = item.BookId,
                        BookTitle = item.BookTitle,
                        IsSelected = true
                    });
                }
                else
                {
                    model.Add(new BooksGenreSelection()
                    {
                        BookId = item.BookId,
                        BookTitle = item.BookTitle,
                        IsSelected = false
                    });
                }
            }
            return model;
        }

        public AreaUserBooks GetEBook(Guid id)
        {
            var result = _context.ClamUserBooks.Find(id);
            return _mapper.Map<AreaUserBooks>(result);
        }

        public AreaUserBooksCategory GetGenre(Guid id)
        {
            var model = _context.ClamUserBooksCategories.Find(id);
            return _mapper.Map<AreaUserBooksCategory>(model);
        }

        public async Task<IEnumerable<BooksGenreSelection>> GetAllEBooksForGenreSelection(Guid id, string userName)
        {
            var books = await _context.ClamUserBooks.ToListAsync();
            var genre = await _context.ClamUserBooksCategories.FindAsync(id);
            var joinTable = await _context.ClamUserBooksJoinCategories.ToListAsync();

            var userProfile = await _userManager.FindByNameAsync(userName);

            List<BooksGenreSelection> model = new List<BooksGenreSelection>();
            foreach (var item in books)
            {
                if ((joinTable.Any(val => val.CategoryId == genre.CategoryId && val.BookId == item.BookId))
                    && (item.UserId.Equals(userProfile.Id)))
                {
                    model.Add(new BooksGenreSelection()
                    {
                        BookId = item.BookId,
                        BookTitle = item.BookTitle,
                        IsSelected = true
                    });
                }
                else if (!(joinTable.Any(val => val.CategoryId == genre.CategoryId && val.BookId == item.BookId))
                    && (item.UserId.Equals(userProfile.Id)))
                {
                    model.Add(new BooksGenreSelection()
                    {
                        BookId = item.BookId,
                        BookTitle = item.BookTitle,
                        IsSelected = false
                    });
                }
            }
            return model;
        }

        public async Task<IEnumerable<AreaUserBooks>> GetAllUserEBooks(string userName)
        {
            var model = await _context.ClamUserBooks.ToListAsync();
            var getUser = await _userManager.FindByNameAsync(userName);

            List<AreaUserBooks> result = new List<AreaUserBooks>();
            foreach (var item in model)
            {
                if ((item.UserId == getUser.Id) && !(await _userManager.IsInRoleAsync(getUser, "Contributer")))
                {
                    result.Add(new AreaUserBooks()
                    {
                        BookId = item.BookId,
                        BookTitle = item.BookTitle,
                        Size = item.Size,
                        Status = item.Status
                    });
                }
            }
            return result;
        }

        public async Task<ReadBook> GetDisplayBook(Guid id)
        {
            var model = await _context.ClamUserBooks.FindAsync(id);
            var jointCheck = await _context.ClamUserBooksJoinCategories.ToListAsync();
            var displayBook = _mapper.Map<ReadBook>(model);

            // List of Objects [Ignore]
            List<ClamUserBooksCategory> collectedCategories = new List<ClamUserBooksCategory>();
            List<AreaUserBooks> recommended = new List<AreaUserBooks>();
            List<Guid> categoryList = new List<Guid>();

            // Check if there are objects listed in Joint Table
            if (jointCheck == null)
            {
                return null;
            }

            // If they pass initial check, iterate through each table to find Current Film Category
            foreach (var item in jointCheck)
            {
                if (item.BookId.Equals(model.BookId))
                {
                    categoryList.Add(item.CategoryId);
                }
            }

            // Iterate through each category list collected from current video and select same category videos to recommend
            foreach (var category in categoryList)
            {
                foreach (var selection in jointCheck)
                {
                    if (category.Equals(selection.CategoryId) && !selection.BookId.Equals(model.BookId) &&
                        !recommended.Any(x => x.BookId.Equals(selection.BookId)))
                    {
                        recommended.Add(_mapper.Map<AreaUserBooks>(await _context.ClamUserBooks.FindAsync(selection.BookId)));
                    }
                }
            }

            // Adjust Image Path to Display in Recommendations
            // We don't need to modify path for Wallpaper as we are only displaying cover images for recommendations
            foreach (var book in recommended)
            {
                book.ImagePath = FilePathUrlHelper.DataFilePathFilter(book.ImagePath, 3);
            }

            displayBook.Recommended = recommended;
            return displayBook;
        }

        public async Task<BooksHome> GetDisplayHomeContent(string search = null)
        {
            // Retrieve Tracks from Database
            var books = await _context.ClamUserBooks.ToListAsync();
            var categories = await _context.ClamUserBooksCategories.ToListAsync();
            var joinTable = await _context.ClamUserBooksJoinCategories.ToListAsync();

            // Random Number Generator
            var random = new Random();
            List<int> recommendedIndexRegister = new List<int>();

            // Restriction Level Limits on List
            int restriction_Standard = 10;
            int restriction_General = 5;
            int restriction_RecentlyAdded = books.Count;


            // Arrange Model
            BooksHome model = new BooksHome();
            if ((books.Count == 0) || (categories.Count == 0) || (joinTable.Count == 0))
            {
                return model;
            }

            if (!String.IsNullOrEmpty(search))
            {
                foreach (var book in books)
                {
                    if (book.Status == true)
                    {

                        // Convert Title to lower string
                        var filterTitle = book.BookTitle.ToLower();
                        var getGenreId = book.ClamUserBooksJoinCategories;

                        // Search Keyword
                        if ((filterTitle.Contains(search.ToLower()))
                            || (getGenreId.Any(x => x.ClamUserBooksCategory.CategoryName.ToLower().Contains(search.ToLower()))))
                        {
                            model.AreaUserBooks.Add(new AreaUserBooks()
                            {
                                BookId = book.BookId,
                                BookTitle = book.BookTitle,
                                ItemPath = FilePathUrlHelper.DataFilePathFilter(book.ItemPath, 3),
                                ImagePath = FilePathUrlHelper.DataFilePathFilter(book.ImagePath, 3)
                            });
                        }
                    }
                }
                model.SearchRequest = search;
                model.SearchRequestResultsCount = model.AreaUserBooks.Count;
                return model;
            }
            else
            {
                // For-Loop iterates through every single track and adds the track to the collect all track list
                foreach (var book in books)
                {
                    if (book.Status == true)
                    {
                        model.AreaUserBooks.Add(new AreaUserBooks()
                        {
                            BookId = book.BookId,
                            BookTitle = book.BookTitle,
                            ItemPath = FilePathUrlHelper.DataFilePathFilter(book.ItemPath, 3),
                            ImagePath = FilePathUrlHelper.DataFilePathFilter(book.ImagePath, 3)
                        });
                        model.RecentlyAdded.Add(new AreaUserBooks()
                        {
                            BookId = book.BookId,
                            BookTitle = book.BookTitle,
                            ItemPath = FilePathUrlHelper.DataFilePathFilter(book.ItemPath, 3),
                            ImagePath = FilePathUrlHelper.DataFilePathFilter(book.ImagePath, 3)
                        });
                    }
                }

                // For-Loop iterate through each category to retrieve particular songs
                foreach (var selectedCategory in categories)
                {
                    List<AreaUserBooks> categoryBooks = new List<AreaUserBooks>();
                    foreach (var book in books)
                    {
                        if (book.Status == true
                            && joinTable.Any(x => x.BookId == book.BookId && x.CategoryId == selectedCategory.CategoryId
                            && !categoryBooks.Any(x => x.BookId.Equals(book.BookId))))
                        {
                            categoryBooks.Add(new AreaUserBooks()
                            {
                                BookId = book.BookId,
                                BookTitle = book.BookTitle,
                                ItemPath = FilePathUrlHelper.DataFilePathFilter(book.ItemPath, 3),
                                ImagePath = FilePathUrlHelper.DataFilePathFilter(book.ImagePath, 3)
                            });
                        }
                    }
                    // Store each list into main model MusicHome
                    model.AreaUserBooksCategories.Add(new AreaUserBooksCategory()
                    {
                        CategoryId = selectedCategory.CategoryId,
                        CategoryName = selectedCategory.CategoryName,
                        AreaUserBooks = categoryBooks
                    });
                }

                // For-Loop for Recommended Listing
                foreach (var book in books)
                {
                    int randomIndex = random.Next(books.Count);
                    int recommendedIndex = random.Next(books.Count);
                    if (book.Status == true)
                    {
                        if ((restriction_General != 0) && !(recommendedIndexRegister.Contains(recommendedIndex)))
                        {
                            var recommended = books[recommendedIndex];
                            model.RecommendedList.Add(new AreaUserBooks()
                            {
                                BookId = book.BookId,
                                BookTitle = book.BookTitle,
                                ItemPath = FilePathUrlHelper.DataFilePathFilter(book.ItemPath, 3),
                                ImagePath = FilePathUrlHelper.DataFilePathFilter(book.ImagePath, 3)
                            });
                            recommendedIndexRegister.Add(recommendedIndex);
                            restriction_General -= 1;
                        }
                        if (restriction_General == 0)
                        {
                            break;
                        }
                    }
                }

                return model;
            }
        }

        public async Task RemoveEBook(Guid id)
        {
            var model = await _context.ClamUserBooks.FindAsync(id);
            var result = FilePathUrlHelper.DataFilePathFilterIndex(model.ItemPath, 4);
            var path = model.ItemPath.Substring(0, result);
            Directory.Delete(path, true);
            _context.ClamUserBooks.Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveGenre(Guid id)
        {
            var model = await _context.ClamUserBooksCategories.FindAsync(id);
            _context.ClamUserBooksCategories.Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveRangeEBook(List<AreaUserBooks> model)
        {
            foreach (var item in model)
            {
                var result = await _context.ClamUserBooks.FindAsync(item.BookId);
                var pathFilter = FilePathUrlHelper.DataFilePathFilterIndex(result.ItemPath, 4);
                var path = result.ItemPath.Substring(0, pathFilter);
                Directory.Delete(path, true);
                _context.ClamUserBooks.Remove(result);
            }
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAllEBooksGenreSelection(Guid id, List<BooksGenreSelection> model)
        {
            var category = await _context.ClamUserBooksCategories.FindAsync(id);
            var queryTable = await _context.ClamUserBooksJoinCategories.AsNoTracking().ToListAsync();
            List<ClamUserBooksJoinCategory> joinTables = new List<ClamUserBooksJoinCategory>();

            foreach (var item in model)
            {
                if (item.IsSelected == true && (queryTable.Any(val => val.CategoryId == category.CategoryId && val.BookId == item.BookId)))
                {
                    continue;
                }
                if (item.IsSelected == true && !(queryTable.Any(val => val.CategoryId == category.CategoryId && val.BookId == item.BookId)))
                {
                    joinTables.Add(new ClamUserBooksJoinCategory()
                    {
                        CategoryId = category.CategoryId,
                        BookId = item.BookId
                    });
                }
                if (item.IsSelected == false && (queryTable.Any(val => val.CategoryId == category.CategoryId && val.BookId == item.BookId)))
                {
                    _context.Remove(new ClamUserBooksJoinCategory() { BookId = item.BookId, CategoryId = category.CategoryId });
                }
            }
            await _context.AddRangeAsync(joinTables);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEBook(Guid id, StreamFormDataBooks formData)
        {
            var model = await _context.ClamUserBooks.FindAsync(id);
            _context.Entry(model).Entity.BookTitle = formData.BookTitle;
            _context.Entry(model).Entity.Status = bool.Parse(formData.Status);
            _context.Entry(model).Entity.LastModified = DateTime.Now;
            _context.Entry(model).State = EntityState.Modified;
            _context.Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AreaUserBooksCategory>> GetAllGenres()
        {
            var model = await _context.ClamUserBooksCategories.ToListAsync();
            List<AreaUserBooksCategory> result = new List<AreaUserBooksCategory>();
            foreach (var item in model)
            {
                result.Add(new AreaUserBooksCategory()
                {
                    CategoryId = item.CategoryId,
                    CategoryName = item.CategoryName,
                    LastModified = item.LastModified,
                    DateCreated = item.DateCreated
                });
            }
            return result;
        }
    }
}
