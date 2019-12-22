using System.ComponentModel.DataAnnotations;
using JiraLikeYou.DAL.Enums;

namespace JiraLikeYou.DAL.Entities
{
    public class SettingParsingFields
    {
        [Key]
        public int Id { get; set; }
        public int Code { get; set; }

        public string Name { get; set; }

        public SupportedType Type { get; set; }
    }
}
