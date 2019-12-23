using System.Collections.Generic;
using System.Linq;
using JiraLikeYou.DAL.Entities;

namespace JiraLikeYou.DAL.Repositories
{
    public interface IEventHistoryRepository
    {
        IEnumerable<EventHistory> Get();

        EventHistory GetLast();

        EventHistory Get(long id);
    }

    public class EventHistoryRepository : IEventHistoryRepository
    {
        private readonly DataContext _dataContext;

        public EventHistoryRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<EventHistory> Get()
        {
            return _dataContext.EventHistory.AsEnumerable();
        }

        public EventHistory GetLast()
        {
            return _dataContext.EventHistory.FirstOrDefault(p => p.Id == _dataContext.EventHistory.Max(x => x.Id));
        }

        public EventHistory Get(long id)
        {
            return _dataContext.EventHistory.FirstOrDefault(x => x.Id == id);
        }
    }
}
