using JiraLikeYou.BLL.Models;

namespace JiraLikeYou.BLL.Mappers
{
    public class TriggerMapper
    {
        public Trigger ToBll(DAL.Entities.Trigger dal)
        {
            return dal == null
                ? null
                : new Trigger
                {
                    Id = dal.Id,
                    OccasionTypeId = dal.OccasionTypeId,
                    Status = dal.Status,
                    Priority = dal.Priority,
                    DaysInStatus = dal.DaysInStatus,
                    CountTickets = dal.CountTickets
                };
        }
    }
}
