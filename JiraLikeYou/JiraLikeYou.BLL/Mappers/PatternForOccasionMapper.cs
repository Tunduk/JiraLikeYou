using JiraLikeYou.BLL.Models;

namespace JiraLikeYou.BLL.Mappers
{
    public class PatternForOccasionMapper
    {
        public PatternForOccasion ToBll(DAL.Entities.PatternForOccasionType dal)
        {
            return dal == null
                ? null
                : new PatternForOccasion
                {
                    Id = dal.Id,
                    OccasionTypeId = dal.OccasionTypeId,
                    Title = dal.Title,
                    Subtitle = dal.Subtitle,
                    SoundLink = dal.SoundLink
                };
        }
    }
}
