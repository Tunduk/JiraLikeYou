using JiraLikeYou.BLL.Mappers;
using JiraLikeYou.BLL.Models;
using JiraLikeYou.BLL.Models.Ticket;
using JiraLikeYou.DAL.Entities;
using JiraLikeYou.DAL.Repositories;

namespace JiraLikeYou.BLL.Services
{
    public interface ITicketService
    {
        void Create(JiraWebhookResponse response);
    }
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly TicketMapper _ticketMapper;
        private readonly IOccasionHandler _occasionHandler;
        private readonly IStatusRepository _statusRepository;
        private readonly IPriorityRepository _priorityRepository;

        public TicketService(ITicketRepository ticketRepository,
            TicketMapper ticketMapper,
            IOccasionHandler occasionHandler,
            IPriorityRepository priorityRepository,
            IStatusRepository statusRepository)
        {
            _ticketRepository = ticketRepository;
            _ticketMapper = ticketMapper;
            _occasionHandler = occasionHandler;
            _priorityRepository = priorityRepository;
            _statusRepository = statusRepository;
        }

        public void Create(JiraWebhookResponse response)
        {
            var status = _statusRepository.GetById(response.StatusId);
            if(status == null)
                return;

            var priority = _priorityRepository.GetById(response.PriorityId);
            if(priority == null)
                return;


            var newTicket = new Ticket
            {
                Key = response.Key,
                Name = response.Name,
                StatusId = response.StatusId,
                PriorityId = response.PriorityId,
                UserEmail = response.User.Email,
            };

            var createdTicket = _ticketRepository.Create(newTicket);

            _occasionHandler.HandleNewTicket(_ticketMapper.MapFromEntity(createdTicket));
        }
    }
}
