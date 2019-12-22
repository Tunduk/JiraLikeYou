using System.ComponentModel.DataAnnotations;

namespace JiraLikeYou.DAL.Entities
{
    public class SettingDefaultPatterns
    {
        [Key]
        public int Id { get; set; }
        public string ScriptId { get; set; }

        public string Text { get; set; }

        public string MediaId { get; set; }
    }
}
