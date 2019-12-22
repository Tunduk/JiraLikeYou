using System.ComponentModel.DataAnnotations;

namespace JiraLikeYou.DAL.Entities
{
    public class SettingPatterns
    {
        [Key]
        public int Id { get; set; }
        public int ScriptId { get; set; }

        public string Text { get; set; }

        public string MediaId { get; set; }
    }
}
