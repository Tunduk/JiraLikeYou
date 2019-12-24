using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JiraLikeYou.DAL.Entities
{
    public class ConfigTrigger
    {
        [Key]
        public long Id { get; set; }

        public long ConfigOccasionTypeId { get; set; }

        public string Status { get; set; }

        public string Priority { get; set; }

        public int DaysInStatus { get; set; }

        public int CountTickets { get; set; }

        public ConfigOccasionType ConfigOccasionType { get; set; }

        public ICollection<ConfigPatternTrigger> ConfigPatternTrigger { get; set; }
    }
}
