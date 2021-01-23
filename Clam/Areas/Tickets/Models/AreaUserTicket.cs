using Clam.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clam.Areas.Tickets.Models
{
    public class AreaUserTicket
    {

        [Display(Name = "Ticket ID")]
        public Guid SystemTicketId { get; set; }

        [Required]
        [MaxLength(30)]
        [DataType(DataType.Text)]
        [Display(Name = "Subject")]
        public string TicketTitle { get; set; }

        [Required]
        [MaxLength(300)]
        [DataType(DataType.Text)]
        [Display(Name = "Message")]
        public string TicketMessage { get; set; }

        [MaxLength(300)]
        [DataType(DataType.Text)]
        [Display(Name = "Report")]
        public string TicketResponse { get; set; }

        [MaxLength(30)]
        [Display(Name = "Status")]
        public string TicketStatus { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Updated On")]
        public DateTime LastModified { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Assigned")]
        public string DesignatedMember { get; set; }

        [Required]
        [Display(Name = "User ID")]
        public Guid UserId { get; set; }

    }

    public class TicketHome
    {
        public TicketHome()
        {
            AreaUserTickets = new List<AreaUserTicket>();
        }

        public AreaUserTicket TicketModel { get; set; }

        public IEnumerable<AreaUserTicket> AreaUserTickets { get; set; }
    }
}
