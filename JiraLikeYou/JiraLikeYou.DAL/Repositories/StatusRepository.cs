using JiraLikeYou.DAL.Entities;
using JiraLikeYou.DAL.Repositories.Common;

namespace JiraLikeYou.DAL.Repositories
{
    public interface IStatusRepository : IRepositoryBase<Status>
    {
    }

    public class StatusRepository : RepositoryBase<Status>, IStatusRepository
    {
        public StatusRepository(DataContext dataContext) : base(dataContext)
        {
        }

    }
}