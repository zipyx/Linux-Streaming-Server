using AutoMapper;
using Clam.Areas.Tickets.Models;
using Clam.Interface.Tickets;
using ClamDataLibrary.DataAccess;
using ClamDataLibrary.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clam.Repository.Tickets
{
    public class TicketRepository : Repository<ClamUserSystemTicket>, ITicketRepository
    {
        private readonly UserManager<ClamUserAccountRegister> _userManager;
        private new readonly ClamUserAccountContext _context;
        private readonly IMapper _mapper;

        public TicketRepository(ClamUserAccountContext context, UserManager<ClamUserAccountRegister> userManager,
            IMapper mapper) : base(context)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task AddAsyncTicket(AreaUserTicket model, string userName)
        {
            //var result = _mapper.Map<ClamUserSystemTicket>(model);
            var user = await _userManager.FindByNameAsync(userName);
            var ticketResponse = "Please be patient, will look into the matter as soon as possible.";
            var standardStatus = "Pending Review";
            var standardDesignation = "Unassigned Member";
            ClamUserSystemTicket result = new ClamUserSystemTicket()
            {
                TicketTitle = model.TicketTitle,
                TicketMessage = model.TicketMessage,
                TicketStatus = standardStatus,
                TicketResponse = ticketResponse,
                UserId = user.Id,
                DesignatedMember = standardDesignation,
                LastModified = DateTime.Now,
                DateCreated = DateTime.Now
            };
            await _context.ClamUserSystemTickets.AddAsync(result);
            await _context.SaveChangesAsync();
        }

        public async Task AddTicket(AreaUserTicket model, string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var ticketResponse = "Please be patient, will look into the matter as soon as possible.";
            var standardStatus = "Pending Review";
            var standardDesignation = "Unassigned Member";
            ClamUserSystemTicket result = new ClamUserSystemTicket()
            {
                TicketTitle = model.TicketTitle,
                TicketMessage = model.TicketMessage,
                TicketStatus = standardStatus,
                TicketResponse = ticketResponse,
                UserId = user.Id,
                DesignatedMember = standardDesignation,
                LastModified = DateTime.Now,
                DateCreated = DateTime.Now
            };
            _context.Add(result);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<AreaUserTicket>> GetAllUserTickets(string userName)
        {
            var userProfile = await _userManager.FindByNameAsync(userName);
            var allTickets = await _context.ClamUserSystemTickets.AsNoTracking().ToListAsync();

            // Ticket Model List
            List<AreaUserTicket> ticketModelList = new List<AreaUserTicket>();
            List<string> roleCheck = new List<string>() { "Admin", "Engineer", "Developer" };

            // Checker
            bool checker = false;

            // Ticket Convert
            foreach (var role in roleCheck)
            {
                if (await _userManager.IsInRoleAsync(userProfile, role))
                {
                    checker = true;
                    break;
                }
            }
            if (checker == true)
            {
                foreach (var ticket in allTickets)
                {
                    ticketModelList.Add(_mapper.Map<AreaUserTicket>(ticket));
                }
                return ticketModelList;
            }
            else
            {
                foreach (var ticket in allTickets)
                {
                    if (ticket.UserId == userProfile.Id)
                    {
                        ticketModelList.Add(_mapper.Map<AreaUserTicket>(ticket));
                    }
                }
                return ticketModelList;
            }
        }

        public async Task<AreaUserTicket> GetAsyncTicket(Guid id)
        {
            var model = await _context.ClamUserSystemTickets.FindAsync(id);
            return _mapper.Map<AreaUserTicket>(model);
        }

        public AreaUserTicket GetTicket(Guid id)
        {
            var model = _context.ClamUserSystemTickets.Find(id);
            return _mapper.Map<AreaUserTicket>(model);
        }

        public async Task RemoveTicket(Guid id)
        {
            var model = await _context.ClamUserSystemTickets.FindAsync(id);
            _context.Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTicket(AreaUserTicket formData, string userName)
        {
            var model = _context.ClamUserSystemTickets.Find(formData.SystemTicketId);
            _context.Entry(model).Entity.TicketResponse = formData.TicketResponse;
            _context.Entry(model).Entity.TicketStatus = formData.TicketStatus;
            _context.Entry(model).Entity.DesignatedMember = userName;
            _context.Entry(model).Entity.LastModified = DateTime.Now;
            _context.Entry(model).State = EntityState.Modified;
            _context.Update(model);
            await _context.SaveChangesAsync();
        }
    }
}
