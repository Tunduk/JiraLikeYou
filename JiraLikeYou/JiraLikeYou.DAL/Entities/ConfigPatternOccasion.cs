using System.ComponentModel.DataAnnotations;

namespace JiraLikeYou.DAL.Entities
{
    public class ConfigPatternOccasion
    {
        [Key]
        public long Id { get; set; }

        public long ConfigOccasionTypeId { get; set; }

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public string SoundLink { get; set; }

        public ConfigOccasionType ConfigOccasionType { get; set; }
    }
}
