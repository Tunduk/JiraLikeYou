using System;
using System.ComponentModel.DataAnnotations;

namespace JiraLikeYou.DAL.Entities
{
    public class HistoryFields
    {
        [Key]
        public long Id { get; set; }

        public long HistoryId { get; set; }

        public long FieldId { get; set; }

        public string Value { get; set; }

        public History History { get; set; }

        public SettingParsingFields Fields { get; set; }
    }
}
