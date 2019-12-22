using System.ComponentModel.DataAnnotations;

namespace JiraLikeYou.DAL.Entities
{
    public class SettingPatterns
    {
        [Key]
        public long Id { get; set; }

        public long TriggerId { get; set; }

        public string Text { get; set; }

        public string ImageId { get; set; }

        public string SoundId { get; set; }

        public SettingTriggers Triggers { get; set; }
    }
}
