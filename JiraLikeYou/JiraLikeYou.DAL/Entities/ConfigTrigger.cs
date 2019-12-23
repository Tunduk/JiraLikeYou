using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JiraLikeYou.DAL.Entities
{
    public class ConfigTrigger
    {
        [Key]
        public long Id { get; set; }

        public long ConfigEventTypeId { get; set; }

        public string Status { get; set; }

        public string Priority { get; set; }

        public int DaysInStatus { get; set; }

        public int CountTickets { get; set; }

        public ConfigEventType ConfigEventType { get; set; }

        public ICollection<ConfigPatternTrigger> ConfigPatternsTrigger { get; set; }
    }
}
