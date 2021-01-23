using AutoMapper;
using Clam.Interface;
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
using Clam.Repository.Academia;
using Clam.Repository.Accounts;
using Clam.Repository.EBooks;
using Clam.Repository.Film;
using Clam.Repository.Music;
using Clam.Repository.Projects;
using Clam.Repository.Roles;
using Clam.Repository.Storage;
using Clam.Repository.Tickets;
using Clam.Repository.TVShow;
using ClamDataLibrary.DataAccess;
using ClamDataLibrary.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clam.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ClamUserAccountContext _context;
        private readonly SignInManager<ClamUserAccountRegister> _signInManager;
        private readonly UserManager<ClamUserAccountRegister> _userManager;
        private readonly RoleManager<ClamRoles> _roleManager;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public UnitOfWork(ClamUserAccountContext context, IMapper mapper, UserManager<ClamUserAccountRegister> userManager,
            SignInManager<ClamUserAccountRegister> signInManager, RoleManager<ClamRoles> roleManager, 
            IConfiguration config)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _config = config;
            _mapper = mapper;

            // Instantiate Repositories with their respective dependencies
            UserAccount = new UserAccountRepository(_context, _mapper, _userManager, _signInManager, _roleManager);
            RoleAccount = new RoleAccountRepository(_context, _mapper, _userManager, _signInManager, _roleManager);
            EBooksControl = new EBooksRepository(_context, _userManager, _mapper);
            MusicControl = new MusicRepository(_context, _userManager, _mapper);
            FilmControl = new FilmRepository(_context, _userManager, _mapper, _config);
            StorageControl = new StorageRepository(_context, _userManager, _config, _mapper);
            AcademiaControl = new AcademiaRepository(_context, _userManager, _mapper, _config);
            TVShowControl = new TVShowRepository(_context, _userManager, _mapper, _config);
            TicketControl = new TicketRepository(_context, _userManager, _mapper);
            ProjectControl = new ProjectsRepository(_context, _userManager, _mapper, _config);
        }
        
        public IUserAccountRepository UserAccount { get; private set; }
        public IRoleAccountRepository RoleAccount { get; private set; }
        public IEBooksRepository EBooksControl { get; private set; }
        public IMusicRepository MusicControl { get; private set; }
        public IFilmRepository FilmControl { get; private set; }
        public IStorageRepository StorageControl { get; private set; }
        public IAcademiaRepository AcademiaControl { get; private set; }
        public ITVShowRepository TVShowControl { get; private set; }
        public ITicketRepository TicketControl { get; private set; }
        public IProjectsRepository ProjectControl { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public async void Dispose()
        {
            await _context.DisposeAsync();
        }
    }
}
