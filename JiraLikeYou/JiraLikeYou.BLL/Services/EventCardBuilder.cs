using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using JiraLikeYou.BLL.Models;
using JiraLikeYou.DAL.Entities;
using JiraLikeYou.DAL.Repositories;

namespace JiraLikeYou.BLL.Services
{
    public interface IEventCardBuilder
    {
        IEnumerable<string> GetFieldCode();

        EventSmallCard BuildSmallCard(EventHistory eventHistory);

        EventFullCard BuildFullCard(EventHistory eventHistory);
    }

    public class EventCardBuilder : IEventCardBuilder
    {
        private readonly IConfigRepository _configRepository;
        private readonly IUserRepository _userRepository;
        private readonly Random _rand;

        public EventCardBuilder(IConfigRepository configRepository, IUserRepository userRepository)
        {
            _configRepository = configRepository;
            _userRepository = userRepository;
            _rand = new Random();
        }

        public IEnumerable<string> GetFieldCode()
        {
            var props = typeof(EventHistory).GetProperties();
            foreach (var prop in props)
            {
                yield return prop.Name;
            }
        }

        public EventSmallCard BuildSmallCard(EventHistory eventHistory)
        {
            var trigger = _configRepository.GetConfigTrigger(eventHistory.ConfigTriggerId);
            var eventPattern = _configRepository.GetConfigPatternEvent(trigger.ConfigEventTypeId);
            var user = _userRepository.Get(eventHistory.UserEmail);

            return new EventSmallCard
            {
                CreateDate = eventHistory.CreateDate,
                ImageLink = user.AvatarLink,
                Text = BuildText(eventPattern.Title, eventHistory)
                       + eventPattern.Subtitle != "" ? BuildText(eventPattern.Subtitle, eventHistory) : ""
            };
        }

        public EventFullCard BuildFullCard(EventHistory eventHistory)
        {
            var trigger = _configRepository.GetConfigTrigger(eventHistory.ConfigTriggerId);
            var eventPattern = _configRepository.GetConfigPatternEvent(trigger.ConfigEventTypeId);
            var user = _userRepository.Get(eventHistory.UserEmail);

            var triggerPatterns = _configRepository.GetConfigPatternTriggers(eventHistory.ConfigTriggerId).ToArray();
            var triggerPattern = triggerPatterns[_rand.Next(triggerPatterns.Length)];

            return new EventFullCard
            {
                Title = BuildText(eventPattern.Title, eventHistory),
                Subtitle = BuildText(eventPattern.Subtitle, eventHistory),
                ImageLink = triggerPattern.ImageLink,
                SoundLink = eventPattern.SoundLink,
                Text = BuildText(triggerPattern.Text, eventHistory),
            };
        }

        //TODO: надо б сделать
        private string BuildText(string pattern, EventHistory eventHistory)
        {
            return pattern;
        }
    }
}
