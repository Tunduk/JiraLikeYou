namespace JiraLikeYou.BLL.Models
{
    public class JiraWebhookResponse
    {
        public string Key { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }

        public string Priority { get; set; }

        public UserJira User { get; set; }
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
