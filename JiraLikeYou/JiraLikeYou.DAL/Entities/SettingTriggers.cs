using System.ComponentModel.DataAnnotations;
using JiraLikeYou.DAL.Enums;

namespace JiraLikeYou.DAL.Entities
{
    public class SettingTriggers
    {
        [Key]
        public int Id { get; set; }
        public string ScriptId { get; set; }

        public string ValueName { get; set; }

        public SupportedType ValueType { get; set; }
    }
}
