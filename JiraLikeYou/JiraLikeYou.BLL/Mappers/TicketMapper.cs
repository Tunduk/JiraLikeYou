using JiraLikeYou.BLL.Models;
using JiraLikeYou.BLL.Models.Ticket;
using JiraLikeYou.DAL.Entities;

namespace JiraLikeYou.BLL.Mappers
{
    public interface ITicketMapper
    {
        TicketModel MapFromEntity(Ticket dal);
    }

    public class TicketMapper : ITicketMapper
    {
        private readonly IStatusMapper _statusMapper;
        private readonly IPriorityMapper _priorityMapper;

        public TicketMapper(IStatusMapper statusMapper, IPriorityMapper priorityMapper)
        {
            _statusMapper = statusMapper;
            _priorityMapper = priorityMapper;
        }
        public TicketModel MapFromEntity(Ticket ticketEntity)
        {
            return ticketEntity == null ? null : new TicketModel
            {
                Id = ticketEntity.Id,
                Key = ticketEntity.Key,
                Name = ticketEntity.Name,
                Status = _statusMapper.MapFromEntity(ticketEntity.Status),
                Priority = _priorityMapper.MapFromEntity(ticketEntity.Priority),
                UserEmail = ticketEntity.UserEmail,
                CreateDate = ticketEntity.CreateDate
            };
        }
    }
}
