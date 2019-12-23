using System;
using System.ComponentModel.DataAnnotations;

namespace JiraLikeYou.DAL.Entities
{
    public class EventHistory
    {
        [Key]
        public long Id { get; set; }

        public long ConfigTriggerId { get; set; }

        public string UserEmail { get; set; }

        public string TicketKey { get; set; }

        public string TicketName { get; set; }

        public string Status { get; set; }

        public string Priority { get; set; }

        public int DaysInStatus { get; set; }

        public int CountTickets { get; set; }

        public DateTime CreateDate { get; set; }

        public ConfigTrigger ConfigTrigger { get; set; }

        public User User { get; set; }
    }
}
