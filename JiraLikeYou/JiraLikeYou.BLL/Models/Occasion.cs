using System;
using JiraLikeYou.BLL.Models.Ticket;

namespace JiraLikeYou.BLL.Models
{
    public class Occasion
    {
        public long Id { get; set; }

        public long TriggerId { get; set; }

        public int? DaysInStatus { get; set; }

        public int? CountTickets { get; set; }

        public DateTime CreateDate { get; set; }

        public User User { get; set; }

        public TicketModel Ticket { get; set; }
    }
}
