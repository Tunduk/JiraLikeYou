using System;

namespace JiraLikeYou.DAL.Entities
{
    public class History
    {
        public int TriggerId { get; set; }

        public string TicketCode { get; set; }

        public string DefaultText { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
