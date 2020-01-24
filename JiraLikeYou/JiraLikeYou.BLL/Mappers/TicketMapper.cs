using JiraLikeYou.BLL.Models;
using JiraLikeYou.BLL.Models.Ticket;

namespace JiraLikeYou.BLL.Mappers
{
    public class TicketMapper
    {
        private readonly IStatusMapper _statusMapper;
        private readonly IPriorityMapper _priorityMapper;

        public TicketMapper(IStatusMapper statusMapper, IPriorityMapper priorityMapper)
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
