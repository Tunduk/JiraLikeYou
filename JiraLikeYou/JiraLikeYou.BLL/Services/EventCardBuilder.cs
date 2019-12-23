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
        private readonly Random _rand;

        public EventCardBuilder(IConfigRepository configRepository, IUserRepository userRepository)
        {
            _configRepository = configRepository;
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
            var eventPattern = GetConfigPatternEvent(eventHistory.ConfigTriggerId);

            return new EventSmallCard
            {
                CreateDate = eventHistory.CreateDate,
                ImageLink = eventHistory.User.AvatarLink,
                Text = BuildText(eventPattern.Title, eventHistory)
                       + (String.IsNullOrEmpty(eventPattern.Subtitle) ? BuildText(eventPattern.Subtitle, eventHistory) : "")
            };
        }

        public EventFullCard BuildFullCard(EventHistory eventHistory)
        {
            var eventPattern = GetConfigPatternEvent(eventHistory.ConfigTriggerId);
            var triggerPattern = GetConfigRandomPatternTrigger(eventHistory.ConfigTriggerId);

            return new EventFullCard
            {
                Title = BuildText(eventPattern.Title, eventHistory),
                Subtitle = BuildText(eventPattern.Subtitle, eventHistory),
                ImageLink = triggerPattern?.ImageLink,
                SoundLink = eventPattern.SoundLink,
                Text = triggerPattern == null ? null : BuildText(triggerPattern.Text, eventHistory)
            };
        }

        private ConfigPatternEvent GetConfigPatternEvent(long triggerId)
        {
            var trigger = _configRepository.GetConfigTrigger(triggerId);
            return _configRepository.GetConfigPatternEvent(trigger.ConfigEventTypeId);
        }

        private ConfigPatternTrigger GetConfigRandomPatternTrigger(long triggerId)
        {
            var triggerPatterns = _configRepository.GetConfigPatternTriggers(triggerId)?.ToArray();
            return triggerPatterns?[_rand.Next(triggerPatterns.Length)];
        }

        //TODO: надо б сделать
        private string BuildText(string pattern, EventHistory eventHistory)
        {
            return pattern;
        }
    }
}
