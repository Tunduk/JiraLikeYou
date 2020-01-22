using System.Linq;
using JiraLikeYou.BLL.Models;
using JiraLikeYou.BLL.Services;

namespace JiraLikeYou.BLL.Integration
{
    public interface IJiraClient
    {
        void HandleWebhookResponse(JiraWebhookResponse response);
    }
    public class JiraClient : IJiraClient
    {
        private readonly IUserUpdater _userUpdater;
        private readonly ITicketService _ticketService;

        public JiraClient(IUserUpdater userUpdater, ITicketService ticketService)
        {
            _userUpdater = userUpdater;
            _ticketService = ticketService;
        }

        public void HandleWebhookResponse(JiraWebhookResponse response)
        {
            if (!response.ChangeFields.Contains("status"))
            {
                return;
            }
            _userUpdater.UpdateOrCreate(response.User);
            _ticketService.Create(response);
        }
    }
}
