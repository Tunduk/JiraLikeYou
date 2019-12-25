using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using JiraLikeYou.Backend.Dto;

namespace JiraLikeYou.Backend.Hubs
{
    public interface IOccasionHub
    {
        Task Send(OccasionFullCardDto fullCard);
    }

    public class OccasionHub : Hub<IOccasionHub>
    {

        public async Task Send(OccasionFullCardDto fullCard)
        {
            await Clients.All.Send(fullCard);
        }
    }
}
