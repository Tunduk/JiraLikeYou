using JiraLikeYou.Backend.Dto;
using JiraLikeYou.BLL.Models;

namespace JiraLikeYou.Backend.Mappers
{
    public class OccasionFullCardMapper
    {
        public OccasionFullCardDto ToDto(OccasionFullCard cardBll)
        {
            return cardBll == null
                ? null
                : new OccasionFullCardDto
                {
                    Title = cardBll.Title,
                    Subtitle = cardBll.Subtitle,
                    ImageLink = cardBll.ImageLink,
                    SoundLink = cardBll.SoundLink,
                    Text = cardBll.Text
                };
        }
    }
}
