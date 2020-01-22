using JiraLikeYou.BLL.Models;
using JiraLikeYou.BLL.Models.Ticket;

namespace JiraLikeYou.BLL.Mappers
{
    public class TicketMapper
    {
        private readonly StatusMapper _statusMapper;
        private readonly PriorityMapper _priorityMapper;

        public TicketMapper(StatusMapper statusMapper, PriorityMapper priorityMapper)
        {
            _statusMapper = statusMapper;
            _priorityMapper = priorityMapper;
        }
        public TicketModel MapFromEntity(DAL.Entities.Ticket dal)
        {
            return dal == null ? null : new TicketModel
            {
                Id = dal.Id,
                Key = dal.Key,
                Name = dal.Name,
                Status = _statusMapper.MapFromEntity(dal.Status),
                Priority = _priorityMapper.MapFromEntity(dal.Priority),
                UserEmail = dal.UserEmail,
                CreateDate = dal.CreateDate
            };
        }
    }
}
