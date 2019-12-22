using System;
using System.ComponentModel.DataAnnotations;

namespace JiraLikeYou.DAL.Entities
{
    public class HistoryFields
    {
        [Key]
        public int Id { get; set; }
        public int HistoryId { get; set; }

        public int FieldId { get; set; }

        public string Value { get; set; }
    }
}
