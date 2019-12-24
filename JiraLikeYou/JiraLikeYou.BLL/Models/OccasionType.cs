using System.Collections.Generic;

namespace JiraLikeYou.BLL.Models
{
    public class OccasionType
    {
        public long Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public IEnumerable<Trigger> Triggers { get; set; }
    }
}
