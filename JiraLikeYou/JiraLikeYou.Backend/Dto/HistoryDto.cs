using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JiraLikeYou.Backend.Dto
{
    public class HistoryDto
    {
        public DateTime CreateDate { get; set; }

        public string AvatarLink { get; set; }

        public string Text { get; set; }
    }
}
