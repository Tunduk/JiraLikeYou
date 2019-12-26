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
        private readonly IOccasionHandler _occasionHandler;

        public TicketCreator(ITicketRepository ticketRepository, TicketMapper ticketMapper, IOccasionHandler occasionHandler)
        {
            _ticketRepository = ticketRepository;
            _ticketMapper = ticketMapper;
            _occasionHandler = occasionHandler;
        }

        public void Create(JiraWebhookResponse response)
        {
            var newTicket = new Ticket
            {
                Key = response.Key,
                Name = response.Name,
                Status = response.Status,
                Priority = response.Priority,
                UserEmail = response.User.Email
            };

            var createdTicket = _ticketRepository.Create(_ticketMapper.ToDal(newTicket));

            _occasionHandler.HandleNewTicket(_ticketMapper.ToBll(createdTicket));
        }
    }
}
