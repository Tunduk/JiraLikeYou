using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JiraLikeYou.DAL.Entities
{
    public class ConfigOccasionType
    {
        [Key]
        public long Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public ICollection<ConfigTrigger> ConfigTriggers { get; set; }

        public ICollection<ConfigPatternOccasion> ConfigPatternOccasion { get; set; }
    }
}
