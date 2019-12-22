using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiraLikeYou.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace JiraLikeYou.DAL.Repositories
{
    public interface IHistoryRepository
    {
        IEnumerable<History> Get();
    }

    public class HistoryRepository : IHistoryRepository
    {
        private readonly DataContext _dataContext;

        public HistoryRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<History> Get()
        {
            return _dataContext.History.AsEnumerable();
        }
    }
}
