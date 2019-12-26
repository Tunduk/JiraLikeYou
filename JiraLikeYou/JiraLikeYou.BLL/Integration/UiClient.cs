using System.Collections.Generic;
using System.Linq;
using JiraLikeYou.BLL.Mappers;
using JiraLikeYou.BLL.Models;
using JiraLikeYou.DAL.Repositories;

namespace JiraLikeYou.BLL.Services
{
    public interface IUiClient
    {
        IEnumerable<OccasionSmallCard> GetHistory();

        OccasionFullCard GetLastCard();

        void SendOccasion(Occasion occasion);
    }

    public class UiClient : IUiClient
    {
        private readonly IOccasionCardBuilder _cardBuilder;
        private readonly IOccasionRepository _occasionRepository;
        private readonly OccasionMapper _occasionMapper;

        public UiClient(IOccasionCardBuilder cardBuilder, IOccasionRepository occasionRepository, OccasionMapper occasionMapper)
        {
            _cardBuilder = cardBuilder;
            _occasionRepository = occasionRepository;
            _occasionMapper = occasionMapper;
        }

        public IEnumerable<OccasionSmallCard> GetHistory()
        {
            var occasions = _occasionRepository.Get();
            return occasions.Select(x => _cardBuilder.BuildSmallCard(_occasionMapper.ToBll(x)));
        }

        public OccasionFullCard GetLastCard()
        {
            return _cardBuilder.BuildFullCard(_occasionMapper.ToBll(_occasionRepository.GetLast()));
        }

        public void SendOccasion(Occasion occasion)
        {

        }
    }
}
