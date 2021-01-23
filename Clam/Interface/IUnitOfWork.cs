using Clam.Interface.Academia;
using Clam.Interface.Accounts;
using Clam.Interface.EBooks;
using Clam.Interface.Film;
using Clam.Interface.Music;
using Clam.Interface.Projects;
using Clam.Interface.Roles;
using Clam.Interface.Storage;
using Clam.Interface.Tickets;
using Clam.Interface.TVShow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clam.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IUserAccountRepository UserAccount { get; }
        IRoleAccountRepository RoleAccount { get; }
        IEBooksRepository EBooksControl { get; }
        IMusicRepository MusicControl { get; }
        IFilmRepository FilmControl { get; }
        IStorageRepository StorageControl { get; }
        IAcademiaRepository AcademiaControl { get; }
        ITVShowRepository TVShowControl { get; }
        ITicketRepository TicketControl { get; }
        IProjectsRepository ProjectControl { get; }
    }
}
