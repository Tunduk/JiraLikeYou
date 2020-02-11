using System;
using System.Linq;
using JiraLikeYou.BLL.Mappers;
using JiraLikeYou.BLL.Models;
using JiraLikeYou.BLL.Models.Ticket;
using JiraLikeYou.DAL.Repositories;

namespace JiraLikeYou.BLL.Services
{
    public interface IOccasionHandler
    {
        void HandleNewTicket(TicketModel ticket);
    }

    public class OccasionHandler : IOccasionHandler
    {
        private readonly IConfigRepository _configRepository;
        private readonly IOccasionRepository _occasionRepository;
        private readonly IUserRepository _userRepository;
        private readonly OccasionMapper _occasionMapper;
        private readonly OccasionTypeMapper _occasionTypeMapper;
        private readonly UserMapper _userMapper;
        private readonly IUiClient _uiClient;

        public OccasionHandler(IConfigRepository configRepository,
            IOccasionRepository occasionRepository,
            IUserRepository userRepository,
            OccasionMapper occasionMapper,
            OccasionTypeMapper occasionTypeMapper, UserMapper userMapper,
            IUiClient uiClient)
        {
            _configRepository = configRepository;
            _occasionRepository = occasionRepository;
            _userRepository = userRepository;
            _occasionMapper = occasionMapper;
            _occasionTypeMapper = occasionTypeMapper;
            _userMapper = userMapper;
            _uiClient = uiClient;
        }

        public void HandleNewTicket(TicketModel ticket)
        {
            CreateChangeStatusOccasion(ticket);
        }

        private void CreateChangeStatusOccasion(TicketModel ticket)
        {
            var triggerId = 0L;
            var occasionType = _occasionTypeMapper.ToBll(_configRepository.GetOccasionType("ChangeStatus"));

            var needTriggers = occasionType.Triggers.Where(x => x.Status?.Id == ticket.Status?.Id && x.Priority?.Id == ticket.Priority?.Id).ToList();

            if (needTriggers.Count == 0)
            {
                needTriggers = occasionType.Triggers.Where(x => x.Status?.Id == ticket.Status?.Id && x.Priority == null).ToList();
            }
            if (needTriggers.Count == 0)
            {
                return;
            }
            if (needTriggers.Count > 1)
            {
                throw new NotImplementedException();
            }
            if(needTriggers.Count == 1)
            {
                triggerId = needTriggers.Single().Id;
            }
            
            var occasion = new Occasion
            {
                TriggerId = triggerId,
                Ticket = ticket,
                User = _userMapper.ToBll(_userRepository.Get(ticket.UserEmail))
            };
            CreateOccasion(occasion);
        }

        private void CreateOccasion(Occasion occasion)
        {
            _occasionRepository.Create(_occasionMapper.ToDal(occasion));
            
            _uiClient.SendOccasion(occasion);
        }
    }
}
