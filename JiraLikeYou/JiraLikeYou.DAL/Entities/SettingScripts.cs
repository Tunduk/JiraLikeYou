using System.ComponentModel.DataAnnotations;

namespace JiraLikeYou.DAL.Entities
{
    public class SettingScripts
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }

        public string Name { get; set; }
    }
}
