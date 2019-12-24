using System;
using System.ComponentModel.DataAnnotations;

namespace JiraLikeYou.DAL.Entities
{
    public class Occasion
    {
        [Key]
        public long Id { get; set; }

        public long ConfigTriggerId { get; set; }

        public long? TicketId { get; set; }

        public long? UserLogin { get; set; }

        public int DaysInStatus { get; set; }

        public int CountTickets { get; set; }

        public DateTime CreateDate { get; set; }

        public ConfigTrigger ConfigTrigger { get; set; }

        public User User { get; set; }

        public Ticket Ticket { get; set; }
    }
}
