using System.ComponentModel.DataAnnotations;

namespace JiraLikeYou.DAL.Entities
{
    public class ConfigPatternTrigger
    {
        [Key]
        public long Id { get; set; }

        public long ConfigTriggerId { get; set; }

        public string Text { get; set; }

        public string ImageLink { get; set; }

        public ConfigTrigger ConfigTriggers { get; set; }
    }
}
