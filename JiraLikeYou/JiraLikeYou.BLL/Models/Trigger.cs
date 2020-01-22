using JiraLikeYou.BLL.Models.Priority;
using JiraLikeYou.BLL.Models.Status;

namespace JiraLikeYou.BLL.Models
{
    public class Trigger
    {
        public long Id { get; set; }

        public long OccasionTypeId { get; set; }

        public StatusModel Status { get; set; }

        public PriorityModel Priority { get; set; }

        public int? DaysInStatus { get; set; }

        public int? CountTickets { get; set; }
    }
}
