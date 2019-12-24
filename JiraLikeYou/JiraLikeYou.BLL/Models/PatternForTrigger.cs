using JiraLikeYou.DAL.Entities;

namespace JiraLikeYou.BLL.Models
{
    public class PatternForTrigger
    {
        public long Id { get; set; }

        public long TriggerId { get; set; }

        public string Text { get; set; }

        public string ImageLink { get; set; }

        public Trigger Triggers { get; set; }
    }
}
