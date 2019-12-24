using System.Collections.Generic;
using System.Linq;
using JiraLikeYou.DAL.Entities;

namespace JiraLikeYou.DAL.Repositories
{
    public interface IConfigRepository
    {
        ConfigOccasionType GetConfigOccasionType(string code);

        ConfigTrigger GetConfigTrigger(long id);

        ConfigPatternOccasion GetConfigPatternOccasion(long occasionId);

        IEnumerable<ConfigPatternTrigger> GetConfigPatternTriggers(long triggerId);
    }

    public class ConfigRepository : IConfigRepository
    {
        private readonly DataContext _dataContext;

        public ConfigRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public ConfigOccasionType GetConfigOccasionType(string code)
        {
            return _dataContext.ConfigOccasionType.SingleOrDefault(x => x.Code == code);
        }

        public ConfigTrigger GetConfigTrigger(long id)
        {
            return _dataContext.ConfigTrigger.SingleOrDefault(x => x.Id == id);
        }

        public ConfigPatternOccasion GetConfigPatternOccasion(long occasionId)
        {
            return _dataContext.ConfigPatternOccasion.SingleOrDefault(x => x.ConfigOccasionTypeId == occasionId);
        }

        public IEnumerable<ConfigPatternTrigger> GetConfigPatternTriggers(long triggerId)
        {
            return _dataContext.ConfigPatternTrigger.Where(x => x.ConfigTriggerId == triggerId);
        }
    }
}
