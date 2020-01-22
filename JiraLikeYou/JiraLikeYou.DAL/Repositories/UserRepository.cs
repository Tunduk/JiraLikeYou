using System.Linq;
using JiraLikeYou.DAL.Entities;
using JiraLikeYou.DAL.Repositories.Common;

namespace JiraLikeYou.DAL.Repositories
{
    public interface IUserRepository
    {
        User Get(string email);

        void Update(User user);

        void Create(User user);
    }

    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public User Get(string email)
        {
            return _dataContext.Users.FirstOrDefault(x => x.Email == email);
        }

        public void Update(User user)
        {
            var oldUser = _dataContext.Users.SingleOrDefault(x => x.Email == user.Email);
            _dataContext.Users.Update(user);
            _dataContext.SaveChanges();
        }

        public void Create(User user)
        {
            _dataContext.Users.Add(user);
            _dataContext.SaveChanges();
        }
    }
}
