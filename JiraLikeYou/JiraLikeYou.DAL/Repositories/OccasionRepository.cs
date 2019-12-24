using System.Collections.Generic;
using System.Linq;
using JiraLikeYou.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace JiraLikeYou.DAL.Repositories
{
    public interface IOccasionRepository
    {
        IEnumerable<Occasion> Get();

        Occasion GetLast();

        Occasion Get(long id);
    }

    public class OccasionRepository : IOccasionRepository
    {
        private readonly DataContext _dataContext;

        public OccasionRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<Occasion> Get()
        {
            return _dataContext.Occasion.Include(x => x.User).AsEnumerable();
        }

        public Occasion GetLast()
        {
            return _dataContext.Occasion.Include(x => x.User).FirstOrDefault(p => p.Id == _dataContext.Occasion.Max(x => x.Id));
        }

        public Occasion Get(long id)
        {
            return _dataContext.Occasion.Include(x => x.User).FirstOrDefault(x => x.Id == id);
        }
    }
}
