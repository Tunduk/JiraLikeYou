using JiraLikeYou.DAL.Enums;

namespace JiraLikeYou.DAL.Entities
{
    public class Media
    {
        public byte[] Value { get; set; }

        public MediaType MediaType { get; set; }

        public string Url { get; set; }
    }
}
