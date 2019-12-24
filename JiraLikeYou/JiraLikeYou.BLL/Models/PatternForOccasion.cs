namespace JiraLikeYou.BLL.Models
{
    public class PatternForOccasion
    {
        public long Id { get; set; }

        public long OccasionTypeId { get; set; }

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public string SoundLink { get; set; }
    }
}
