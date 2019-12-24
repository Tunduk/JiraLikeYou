﻿using System.Collections.Generic;
using System.Linq;
using JiraLikeYou.DAL.Entities;

namespace JiraLikeYou.DAL.Repositories
{
    public interface IUserRepository
    {
        User Get(string email);

        void UpdateOrCreate(User user);
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

        public void UpdateOrCreate(User user)
        {
            var oldUser = _dataContext.Users.SingleOrDefault(x => x.Email == user.Email);

            if (oldUser == null)
            {
                _dataContext.Users.Add(user);
            }
            else if(oldUser.AvatarLink != user.AvatarLink || oldUser.Name != user.Name)
            {
                _dataContext.Users.Update(user);
            }
            _dataContext.SaveChanges();
        }
    }
}
