using System.Collections.Generic;
using System.Linq;
using JiraLikeYou.DAL.Entities;
using JiraLikeYou.DAL.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace JiraLikeYou.DAL.Repositories
{
    public interface IConfigRepository
    {
        OccasionType GetOccasionType(string code);

        Trigger GetTrigger(long id);

        PatternForOccasionType GetPatternForOccasion(long id);

        IEnumerable<PatternForTrigger> GetPatternForTriggers(long id);
    }

    public class ConfigRepository : IConfigRepository
    {
        private readonly DataContext _dataContext;

        public ConfigRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public OccasionType GetOccasionType(string code)
        {
            return _dataContext.OccasionTypes
                .Include(x => x.Triggers)
                .SingleOrDefault(x => x.Code == code);
        }

        public Trigger GetTrigger(long id)
        {
            return _dataContext.Triggers.SingleOrDefault(x => x.Id == id);
        }

        public PatternForOccasionType GetPatternForOccasion(long id)
        {
            return _dataContext.PatternsForOccasion.SingleOrDefault(x => x.OccasionTypeId == id);
        }

        public IEnumerable<PatternForTrigger> GetPatternForTriggers(long id)
        {
            return _dataContext.PatternsForTrigger.Where(x => x.TriggerId == id);
        }
    }
}
