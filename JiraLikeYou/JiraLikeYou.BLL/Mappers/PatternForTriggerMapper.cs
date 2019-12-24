using JiraLikeYou.BLL.Models;

namespace JiraLikeYou.BLL.Mappers
{
    public class PatternForTriggerMapper
    {
        public PatternForTrigger ToBll(DAL.Entities.PatternForTrigger dal)
        {
            return dal == null
                ? null
                : new PatternForTrigger
                {
                    Id = dal.Id,
                    TriggerId = dal.TriggerId,
                    Text = dal.Text,
                    ImageLink = dal.ImageLink
                };
        }
    }
}
