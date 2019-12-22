using System;
using System.ComponentModel.DataAnnotations;

namespace JiraLikeYou.DAL.Entities
{
    public class History
    {
        [Key]
        public int Id { get; set; }

        public int TriggerId { get; set; }

        public string TicketCode { get; set; }

        public string DefaultText { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
