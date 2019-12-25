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
        private readonly ITicketCreator _ticketCreator;

        public JiraClient(IUserUpdater userUpdater, ITicketCreator ticketCreator)
        {
            _userUpdater = userUpdater;
            _ticketCreator = ticketCreator;
        }

        public void HandleWebhookResponse(JiraWebhookResponse response)
        {
            if (!response.ChangeFields.Contains("status"))
            {
                return;
            }
            _userUpdater.UpdateOrCreate(response.User);
            _ticketCreator.Create(response);
        }
    }
}
