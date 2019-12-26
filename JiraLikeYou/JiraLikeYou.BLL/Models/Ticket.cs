using System;

namespace JiraLikeYou.BLL.Models
{
    public class Ticket
    {
        public long Id { get; set; }

        public string Key { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }

        public string Priority { get; set; }

        public string UserEmail { get; set; }

        public DateTime CreateDate { get; set; }

        public Ticket()
        {

        }
    }
}
