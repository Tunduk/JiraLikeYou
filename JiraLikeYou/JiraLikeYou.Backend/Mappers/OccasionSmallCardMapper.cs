using JiraLikeYou.Backend.Dto;
using JiraLikeYou.BLL.Models;

namespace JiraLikeYou.Backend.Mappers
{
    public class OccasionSmallCardMapper
    {
        public OccasionSmallCardDto ToDto(OccasionSmallCard cardBll)
        {
            return cardBll == null
                ? null
                : new OccasionSmallCardDto
                {
                    CreateDate = cardBll.CreateDate,
                    ImageLink = cardBll.ImageLink,
                    Text = cardBll.Text
                };
        }
    }
}
