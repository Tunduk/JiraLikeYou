using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JiraLikeYou.DAL.Enums;

namespace JiraLikeYou.DAL.Entities
{
    public class SettingTriggers
    {
        [Key]
        public long Id { get; set; }

        public string ScriptId { get; set; }

        public string ValueName { get; set; }

        public SupportedType ValueType { get; set; }

        public SettingScripts Scripts { get; set; }
    }
}
