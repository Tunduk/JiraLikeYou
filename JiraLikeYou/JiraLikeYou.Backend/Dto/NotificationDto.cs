using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JiraLikeYou.Backend.Dto
{
    public class NotificationDto
    {
        public string DefaultText { get; set; }

        public string TicketName { get; set; }

        public string ImageLink { get; set; }

        public string SoundLink { get; set; }

        public string RandomText { get; set; }
    }
}
