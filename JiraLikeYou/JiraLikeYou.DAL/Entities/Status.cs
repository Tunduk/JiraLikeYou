using System.ComponentModel.DataAnnotations;

namespace JiraLikeYou.DAL.Entities
{
    public class Status
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}