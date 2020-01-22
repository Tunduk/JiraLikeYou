using JiraLikeYou.BLL.Models;

namespace JiraLikeYou.BLL.Mappers
{
    public class OccasionMapper
    {
        private readonly UserMapper _userMapper;
        private readonly TicketMapper _ticketMapper;

        public OccasionMapper(UserMapper userMapper, TicketMapper ticketMapper)
        {
            _userMapper = userMapper;
            _ticketMapper = ticketMapper;
        }

        public Occasion ToBll(DAL.Entities.Occasion dal)
        {
            return dal == null ? null : new Occasion
            {
                Id = dal.Id,
                TriggerId = dal.TriggerId,
                DaysInStatus = dal.DaysInStatus,
                CountTickets = dal.CountTickets,
                CreateDate = dal.CreateDate,
                User = _userMapper.ToBll(dal.User),
                Ticket = _ticketMapper.MapFromEntity(dal.Ticket)
            };
        }

        public DAL.Entities.Occasion ToDal(Occasion bll)
        {
            return bll == null ? null : new DAL.Entities.Occasion
            {
                TriggerId = bll.TriggerId,
                DaysInStatus = bll.DaysInStatus,
                CountTickets = bll.CountTickets,
                UserEmail = bll.User.Email,
                TicketId = bll.Ticket?.Id
            };
        }
    }
}
