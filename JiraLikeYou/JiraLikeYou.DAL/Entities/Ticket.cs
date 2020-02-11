using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JiraLikeYou.DAL.Entities
{
    public class Ticket
    {
        [Key]
        public long Id { get; set; }

        public string Key { get; set; }

        public string Name { get; set; }

        public int StatusId { get; set; }

        public int PriorityId { get; set; }

        public string UserEmail { get; set; }

        public DateTime CreateDate { get; set; }

        public ICollection<Occasion> Occasions { get; set; }

        public Priority Priority { get;set;}

        public Status Status { get;set;}
    }
}
