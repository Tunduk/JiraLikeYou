using System;
using System.Collections.Generic;
using System.Text;
using JiraLikeYou.BLL.Mappers;
using JiraLikeYou.BLL.Models;
using JiraLikeYou.DAL.Repositories;

namespace JiraLikeYou.BLL.Services
{
    public interface IUserUpdater
    {
        void UpdateOrCreate(UserJira userJira);
    }
    public class UserUpdater : IUserUpdater
    {
        private readonly UserMapper _userMapper;
        private readonly IUserRepository _userRepository;

        public UserUpdater(UserMapper userMapper, IUserRepository userRepository)
        {
            _userMapper = userMapper;
            _userRepository = userRepository;
        }

        public void UpdateOrCreate(UserJira userJira)
        {
            var user = _userMapper.ToBll(_userRepository.Get(userJira.Email));

            var newUser = new User
            {
                Email = userJira.Email,
                Name = userJira.Name,
                AvatarLink = userJira.AvatarLinks.Size48
            };

            if (user == null)
            {
                _userRepository.Create(_userMapper.ToDal(newUser));
            }
            else if (user.AvatarLink != newUser.AvatarLink || user.Name != newUser.Name)
            {
                _userRepository.Update(_userMapper.ToDal(newUser));
            }
        }
    }
}
