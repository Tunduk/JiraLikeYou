﻿using System.Collections.Generic;

namespace JiraLikeYou.BLL.Models
{
    public class JiraWebhookResponse
    {
        public string Key { get; set; }

        public string Name { get; set; }

        public int StatusId { get; set; }

        public int PriorityId { get; set; }

        public UserJira User { get; set; }

        public IEnumerable<string> ChangeFields { get; set; }
    }

    public class UserJira
    {
        public string Email { get; set; }

        public string Name { get; set; }

        public AvatarLinkJira AvatarLinks { get; set; }
    }

    public class AvatarLinkJira
    {
        public string Size48 { get; set; }

        public string Size32 { get; set; }

        public string Size24 { get; set; }

        public string Size16 { get; set; }
    }
}
