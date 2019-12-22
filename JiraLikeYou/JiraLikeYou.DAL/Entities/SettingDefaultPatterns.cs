using System.ComponentModel.DataAnnotations;

namespace JiraLikeYou.DAL.Entities
{
    public class SettingDefaultPatterns
    {
        [Key]
        public long Id { get; set; }

        public string ScriptId { get; set; }

        public string Text { get; set; }

        public string ImageId { get; set; }

        public string SoundId { get; set; }

        public SettingScripts Scripts { get; set; }
    }
}
