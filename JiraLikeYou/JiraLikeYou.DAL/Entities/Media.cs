using System.ComponentModel.DataAnnotations;
using JiraLikeYou.DAL.Enums;

namespace JiraLikeYou.DAL.Entities
{
    public class Media
    {
        [Key]
        public int Id { get; set; }
        public byte[] Value { get; set; }

        public MediaType MediaType { get; set; }

        public string Url { get; set; }
    }
}
