using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JiraLikeYou.DAL.Entities
{
    public class History
    {
        [Key]
        public long Id { get; set; }

        public long TriggerId { get; set; }

        public string TicketCode { get; set; }

        public string AvatarLink { get; set; }

        public string UserName { get; set; }

        public string DefaultText { get; set; }

        public DateTime CreateDate { get; set; }

        public SettingTriggers SettingTriggers { get; set; }

        public ICollection<HistoryFields> HistoryFields { get; set; }
    }
}
