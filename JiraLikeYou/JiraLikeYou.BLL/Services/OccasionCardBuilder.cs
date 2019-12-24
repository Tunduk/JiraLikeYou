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
    public interface IOccasionCardBuilder
    {
        IEnumerable<string> GetFieldCode();

        OccasionSmallCard BuildSmallCard(Occasion occasion);

        OccasionFullCard BuildFullCard(Occasion occasion);
    }

    public class OccasionCardBuilder : IOccasionCardBuilder
    {
        private readonly IConfigRepository _configRepository;
        private readonly Random _rand;

        public OccasionCardBuilder(IConfigRepository configRepository, IUserRepository userRepository)
        {
            _configRepository = configRepository;
            _rand = new Random();
        }

        public IEnumerable<string> GetFieldCode()
        {
            var props = typeof(Occasion).GetProperties();
            foreach (var prop in props)
            {
                yield return prop.Name;
            }
        }

        public OccasionSmallCard BuildSmallCard(Occasion occasion)
        {
            var occasionPattern = GetConfigPatternOccasion(occasion.ConfigTriggerId);

            return new OccasionSmallCard
            {
                CreateDate = occasion.CreateDate,
                ImageLink = occasion.User.AvatarLink,
                Text = BuildText(occasionPattern.Title, occasion)
                       + (String.IsNullOrEmpty(occasionPattern.Subtitle) ? BuildText(occasionPattern.Subtitle, occasion) : "")
            };
        }

        public OccasionFullCard BuildFullCard(Occasion occasion)
        {
            var occasionPattern = GetConfigPatternOccasion(occasion.ConfigTriggerId);
            var triggerPattern = GetConfigRandomPatternTrigger(occasion.ConfigTriggerId);

            return new OccasionFullCard
            {
                Title = BuildText(occasionPattern.Title, occasion),
                Subtitle = BuildText(occasionPattern.Subtitle, occasion),
                ImageLink = triggerPattern?.ImageLink,
                SoundLink = occasionPattern.SoundLink,
                Text = triggerPattern == null ? null : BuildText(triggerPattern.Text, occasion)
            };
        }

        private ConfigPatternOccasion GetConfigPatternOccasion(long triggerId)
        {
            var trigger = _configRepository.GetConfigTrigger(triggerId);
            return _configRepository.GetConfigPatternOccasion(trigger.ConfigOccasionTypeId);
        }

        private ConfigPatternTrigger GetConfigRandomPatternTrigger(long triggerId)
        {
            var triggerPatterns = _configRepository.GetConfigPatternTriggers(triggerId)?.ToArray();
            return triggerPatterns?[_rand.Next(triggerPatterns.Length)];
        }

        //TODO: надо б сделать
        private string BuildText(string pattern, Occasion occasion)
        {
            return pattern;
        }
    }
}
