using JiraLikeYou.BLL.Models;

namespace JiraLikeYou.BLL.Mappers
{
    public class TriggerMapper
    {
        private readonly IPriorityMapper _priorityMapper;
        private readonly IStatusMapper _statusMapper;

        public TriggerMapper(IPriorityMapper priorityMapper, IStatusMapper statusMapper)
        {
            _priorityMapper = priorityMapper;
            _statusMapper = statusMapper;
        }
        public Trigger ToBll(DAL.Entities.Trigger dal)
        {
            return dal == null
                ? null
                : new Trigger
                {
                    Id = dal.Id,
                    OccasionTypeId = dal.OccasionTypeId,
                    Status = _statusMapper.MapFromEntity(dal.Status),
                    Priority = _priorityMapper.MapFromEntity(dal.Priority),
                    DaysInStatus = dal.DaysInStatus,
                    CountTickets = dal.CountTickets
                };
        }
    }
}
