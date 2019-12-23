using System;
using System.Collections.Generic;
using System.Text;
using JiraLikeYou.BLL.Models;
using JiraLikeYou.DAL.Repositories;

namespace JiraLikeYou.BLL.Services
{
    public interface ISomeThingForClient
    {
        IEnumerable<EventSmallCard> GetHistory();
    }

    public class SomeThingForClient : ISomeThingForClient
    {
        private readonly IEventCardBuilder _cardBuilder;
        private readonly IEventHistoryRepository _eventHistoryRepository;

        public SomeThingForClient(IEventCardBuilder cardBuilder, IEventHistoryRepository eventHistoryRepository)
        {
            _cardBuilder = cardBuilder;
            _eventHistoryRepository = eventHistoryRepository;
        }

        public IEnumerable<EventSmallCard> GetHistory()
        {
            var events = _eventHistoryRepository.Get();

            foreach (var ev in events)
            {
                yield return _cardBuilder.BuildSmallCard(ev);
            }
        }
    }
}
