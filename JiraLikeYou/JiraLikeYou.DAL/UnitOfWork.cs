using JiraLikeYou.DAL.Repositories.Common;

namespace JiraLikeYou.DAL
{
    public interface IUnitOfWork
    {
        int Commit();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;
        public UnitOfWork(DataContext context)
        {
            _dataContext = context;
        }

        public int Commit()
        {
            return _dataContext.SaveChanges();
        }
    }
}