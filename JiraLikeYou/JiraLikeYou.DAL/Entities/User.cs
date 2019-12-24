using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JiraLikeYou.DAL.Entities
{
    public class User
    {
        [Key]
        public string Email { get; set; }

        public string Name { get; set; }

        public string AvatarLink { get; set; }

        public ICollection<Occasion> Occasions { get; set; }
    }
}
