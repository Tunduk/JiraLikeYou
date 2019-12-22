using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JiraLikeYou.Backend.Dto.HubModels;

namespace JiraLikeYou.Backend.Hubs
{
    
    public class EventHub:Hub
    {
        public async Task SendEvent(JiraEvent jiraEvent)
        {
            await Clients.All.SendAsync("NewJiraEvent", jiraEvent);
        }
    }
}
