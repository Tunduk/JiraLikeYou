using System.Linq;
using JiraLikeYou.BLL.Models;

namespace JiraLikeYou.BLL.Mappers
{
    public class OccasionTypeMapper
    {
        private readonly TriggerMapper _triggerMapper;

        public OccasionType ToBll(DAL.Entities.OccasionType dal)
        {
            return dal == null
                ? null
                : new OccasionType
                {
                    Id = dal.Id,
                    Code = dal.Code,
                    Name = dal.Name,
                    Triggers = dal.Triggers.Select(x => _triggerMapper.ToBll(x)).AsEnumerable()
                };
        }
    }
}
