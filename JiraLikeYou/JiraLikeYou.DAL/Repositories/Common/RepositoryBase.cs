using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace JiraLikeYou.DAL.Repositories.Common
{
    public interface IRepositoryBase<T>
    {
        void Add(T entity);
        IQueryable<T> GetAll();
        void Delete(T entity);
        void Delete(int id);
        void Update(T entity);
        T GetById(int id);
    }
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class, new()
    {
        private readonly DbSet<T> _dbSet;

        protected RepositoryBase(DataContext dataContext)
        {
            _dbSet = dataContext.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Delete(int id)
        {
            Delete(GetById(id));
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }
    }
}