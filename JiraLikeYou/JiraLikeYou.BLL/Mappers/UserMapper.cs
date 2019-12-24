using JiraLikeYou.DAL.Entities;

namespace JiraLikeYou.BLL.Mappers
{
    public class UserMapper
    { 
        public Models.User ToBll(User dal)
        {
            return dal == null
                ? null
                : new Models.User
                {
                    Email = dal.Email,
                    Name = dal.Name,
                    AvatarLink = dal.AvatarLink
                };
        }

        public User ToDal(Models.User bll)
        {
            return bll == null
                ? null
                : new User
                {
                    Email = bll.Email,
                    Name = bll.Name,
                    AvatarLink = bll.AvatarLink
                };
        }
    }
}
