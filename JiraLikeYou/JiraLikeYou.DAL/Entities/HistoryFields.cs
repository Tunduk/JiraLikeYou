using System;

namespace JiraLikeYou.DAL.Entities
{
    public class HistoryFields
    {
        public int HistoryId { get; set; }

        public int FieldId { get; set; }

        public string Value { get; set; }
    }
}
