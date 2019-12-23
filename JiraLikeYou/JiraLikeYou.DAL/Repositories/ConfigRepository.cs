using System.Collections.Generic;
using System.Linq;
using JiraLikeYou.DAL.Entities;

namespace JiraLikeYou.DAL.Repositories
{
    public interface IConfigRepository
    {
        ConfigEventType GetConfigEventType(string code);

        ConfigTrigger GetConfigTrigger(long id);

        ConfigPatternEvent GetConfigPatternEvent(long eventId);

        IEnumerable<ConfigPatternTrigger> GetConfigPatternTriggers(long triggerId);
    }

    public class ConfigRepository : IConfigRepository
    {
        private readonly DataContext _dataContext;

        public ConfigRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public ConfigEventType GetConfigEventType(string code)
        {
            return _dataContext.ConfigEventType.SingleOrDefault(x => x.Code == code);
        }

        public ConfigTrigger GetConfigTrigger(long id)
        {
            return _dataContext.ConfigTrigger.SingleOrDefault(x => x.Id == id);
        }

        public ConfigPatternEvent GetConfigPatternEvent(long eventId)
        {
            return _dataContext.ConfigPatternEvent.SingleOrDefault(x => x.ConfigEventTypeId == eventId);
        }

        public IEnumerable<ConfigPatternTrigger> GetConfigPatternTriggers(long triggerId)
        {
            return _dataContext.ConfigPatternTrigger.Where(x => x.ConfigTriggerId == triggerId);
        }
    }
}
