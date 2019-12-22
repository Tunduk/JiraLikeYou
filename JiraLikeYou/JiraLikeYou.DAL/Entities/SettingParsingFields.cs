using JiraLikeYou.DAL.Enums;

namespace JiraLikeYou.DAL.Entities
{
    public class SettingParsingFields
    {
        public int Code { get; set; }

        public string Name { get; set; }

        public SupportedType Type { get; set; }
    }
}
