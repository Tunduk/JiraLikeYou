using System.ComponentModel.DataAnnotations;

namespace JiraLikeYou.DAL.Entities
{
    public class PatternForOccasionType
    {
        [Key]
        public long Id { get; set; }

        public long OccasionTypeId { get; set; }

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public string SoundLink { get; set; }

        public OccasionType OccasionType { get; set; }
    }
}
