using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JiraLikeYou.DAL.Entities
{
    public class OccasionType
    {
        [Key]
        public long Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public ICollection<Trigger> Triggers { get; set; }

        public ICollection<PatternForOccasionType> PatternsForOccasion { get; set; }
    }
}
