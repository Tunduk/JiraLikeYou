using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JiraLikeYou.DAL.Entities
{
    public class SettingScripts
    {
        [Key]
        public long Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public ICollection<SettingTriggers> Triggers { get; set; }

        public SettingDefaultPatterns DefaultPatterns { get; set; }
    }
}
