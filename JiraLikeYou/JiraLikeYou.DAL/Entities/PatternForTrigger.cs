using System.ComponentModel.DataAnnotations;

namespace JiraLikeYou.DAL.Entities
{
    public class PatternForTrigger
    {
        [Key]
        public long Id { get; set; }

        public long TriggerId { get; set; }

        public string Text { get; set; }

        public string ImageLink { get; set; }

        public Trigger Triggers { get; set; }
    }
}
