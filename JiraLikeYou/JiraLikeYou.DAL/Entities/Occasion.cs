using System;
using System.ComponentModel.DataAnnotations;

namespace JiraLikeYou.DAL.Entities
{
    public class Occasion
    {
        [Key]
        public long Id { get; set; }

        public long TriggerId { get; set; }

        public long? TicketId { get; set; }

        public string UserEmail { get; set; }

        public int? DaysInStatus { get; set; }

        public int? CountTickets { get; set; }

        public DateTime CreateDate { get; set; }

        public User User { get; set; }

        public Ticket Ticket { get; set; }
    }
}
