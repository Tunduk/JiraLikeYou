using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JiraLikeYou.DAL.Entities
{
    public class Trigger
    {
        [Key]
        public long Id { get; set; }

        public long OccasionTypeId { get; set; }

        public string Status { get; set; }

        public string Priority { get; set; }

        public int? DaysInStatus { get; set; }

        public int? CountTickets { get; set; }

        public OccasionType OccasionType { get; set; }

        public ICollection<PatternForTrigger> PatternsForTrigger { get; set; }
    }
}
