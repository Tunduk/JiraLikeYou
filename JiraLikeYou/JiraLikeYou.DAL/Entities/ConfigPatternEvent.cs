using System.ComponentModel.DataAnnotations;

namespace JiraLikeYou.DAL.Entities
{
    public class ConfigPatternEvent
    {
        public long Id { get; set; }

        public long ConfigEventTypeId { get; set; }

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public string SoundLink { get; set; }
    }
}
