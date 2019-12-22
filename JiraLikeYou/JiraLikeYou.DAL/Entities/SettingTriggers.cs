using JiraLikeYou.DAL.Enums;

namespace JiraLikeYou.DAL.Entities
{
    public class SettingTriggers
    {
        public string ScriptId { get; set; }

        public string ValueName { get; set; }

        public SupportedType ValueType { get; set; }
    }
}
