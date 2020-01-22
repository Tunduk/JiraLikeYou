using System;
using JiraLikeYou.BLL.Models.Priority;
using JiraLikeYou.BLL.Models.Status;

namespace JiraLikeYou.BLL.Models.Ticket
{
    public class TicketModel
    {
        public long Id { get; set; }

        public string Key { get; set; }

        public string Name { get; set; }

        public StatusModel Status { get; set; }

        public PriorityModel Priority { get; set; }

        public string UserEmail { get; set; }

        public DateTime CreateDate { get; set; }

        public TicketModel()
        {

        }
    }
}
