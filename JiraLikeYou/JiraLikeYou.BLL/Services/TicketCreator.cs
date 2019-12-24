using JiraLikeYou.BLL.Mappers;
using JiraLikeYou.BLL.Models;
using JiraLikeYou.DAL.Repositories;

namespace JiraLikeYou.BLL.Services
{
    public interface ITicketCreator
    {
        void Create(JiraWebhookResponse response);
    }
    public class TicketCreator : ITicketCreator
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly TicketMapper _ticketMapper;

        public TicketCreator(ITicketRepository ticketRepository, TicketMapper ticketMapper)
        {
            _ticketRepository = ticketRepository;
            _ticketMapper = ticketMapper;
        }

        public void Create(JiraWebhookResponse response)
        {
            if (_ticketRepository.Get(response.Key, response.Status) == null)
            {
                _ticketRepository.Create(_ticketMapper.ToDal(new Ticket
                {
                    Key = response.Key,
                    Name = response.Name,
                    Status = response.Status,
                    Priority = response.Priority,
                    UserEmail = response.User.Email
                }));

                //тык
            }
        }
    }
}
