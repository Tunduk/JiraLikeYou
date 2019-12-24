namespace JiraLikeYou.BLL.Models
{
    public class Trigger
    {
        public long Id { get; set; }

        public long OccasionTypeId { get; set; }

        public string Status { get; set; }

        public string Priority { get; set; }

        public int DaysInStatus { get; set; }

        public int CountTickets { get; set; }
    }
}
