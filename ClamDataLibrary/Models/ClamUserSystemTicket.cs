using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClamDataLibrary.Models
{
    public class ClamUserSystemTicket
    {
        [Key]
        [Required]
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

        [Required]
        [MaxLength(30)]
        [Display(Name = "Status")]
        public string TicketStatus { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Updated On")]
        public DateTime LastModified { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Added")]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Assigned")]
        public string DesignatedMember { get; set; }

        [Required]
        [Display(Name = "User ID")]
        public Guid UserId { get; set; }
        public virtual ClamUserAccountRegister User { get; set; }

    }
}
