using JiraLikeYou.DAL.Entities;
using JiraLikeYou.DAL.Repositories.Common;

namespace JiraLikeYou.DAL.Repositories
{
    public interface IPriorityRepository : IRepositoryBase<Priority>
    {
    }
    public class PriorityRepository : RepositoryBase<Priority>, IPriorityRepository
    {
        public PriorityRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}