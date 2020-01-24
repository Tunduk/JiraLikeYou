using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JiraLikeYou.DAL.Entities
{
    public class Trigger
    {
        [Key]
        public long Id { get; set; }

        public long OccasionTypeId { get; set; }

        public int? StatusId { get; set; }

        public Status Status { get; set; }

        public int? PriorityId { get; set; }

        public Priority Priority { get; set; }

        public int? DaysInStatus { get; set; }

        public int? CountTickets { get; set; }

        public OccasionType OccasionType { get; set; }

        public ICollection<PatternForTrigger> PatternsForTrigger { get; set; }
    }
}
