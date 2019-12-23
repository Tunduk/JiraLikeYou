using System;
using System.ComponentModel.DataAnnotations;

namespace JiraLikeYou.DAL.Entities
{
    public class User
    {
        [Key]
        public string Email { get; set; }

        public string Name { get; set; }

        public string AvatarLink { get; set; }
    }
}
