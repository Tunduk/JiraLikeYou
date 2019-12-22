using System;
using System.Collections.Generic;
using System.Text;

namespace JiraLikeYou.BLL.Models
{
    public class History
    {
        public DateTime CreateDate { get; set; }

        public string AvatarLink { get; set; }

        public string Text { get; set; }
    }
}
