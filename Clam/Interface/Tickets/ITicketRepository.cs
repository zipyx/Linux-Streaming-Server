using Clam.Areas.Tickets.Models;
using ClamDataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clam.Interface.Tickets
{
    public interface ITicketRepository : IRepository<ClamUserSystemTicket>
    {
        // Get All Tickets
        Task<IEnumerable<AreaUserTicket>> GetAllUserTickets(string userName);

        // Add Ticket
        Task AddTicket(AreaUserTicket model, string userName);
        Task AddAsyncTicket(AreaUserTicket model, string userName);

        // Update Ticket
        Task UpdateTicket(AreaUserTicket model, string userName);

        // Remove Ticket
        Task RemoveTicket(Guid id);

        // Get Ticket
        AreaUserTicket GetTicket(Guid id);
        Task<AreaUserTicket> GetAsyncTicket(Guid id);
    }
}
