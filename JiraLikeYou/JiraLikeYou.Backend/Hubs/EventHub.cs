using Microsoft.AspNetCore.SignalR;
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
