using JiraLikeYou.BLL.Mappers;
using JiraLikeYou.BLL.Models;
using JiraLikeYou.BLL.Services;
using JiraLikeYou.DAL.Entities;
using JiraLikeYou.DAL.Repositories;
using User = JiraLikeYou.BLL.Models.User;

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
            //TODO: хорошо бы ослеживать события, а не просто проверять, был ли такой тикет с таким статусом. Вдруг название поменялось или исполнитель
            _userUpdater.UpdateOrCreate(response.User);
            _ticketCreator.Create(response);
        }
    }
}
