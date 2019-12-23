using System;
using System.ComponentModel.DataAnnotations;

namespace JiraLikeYou.DAL.Entities
{
    public class TicketHistory
    {
        [Key]
        public long Id { get; set; }

        public string Key { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }

        public string Priority { get; set; }

        public string UserEmail { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
