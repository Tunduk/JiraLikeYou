using System;
using System.Collections.Generic;
using System.Linq;
using JiraLikeYou.BLL.Mappers;
using JiraLikeYou.BLL.Models;
using JiraLikeYou.DAL.Repositories;
using Occasion = JiraLikeYou.BLL.Models.Occasion;
using PatternForTrigger = JiraLikeYou.BLL.Models.PatternForTrigger;

namespace JiraLikeYou.BLL.Services
{
    public interface IOccasionCardBuilder
    {
        OccasionSmallCard BuildSmallCard(Occasion occasion);

        OccasionFullCard BuildFullCard(Occasion occasion);
    }

    public class OccasionCardBuilder : IOccasionCardBuilder
    {
        private readonly IConfigRepository _configRepository;
        private readonly TriggerMapper _triggerMapper;
        private readonly PatternForOccasionMapper _patternForOccasionMapper;
        private readonly PatternForTriggerMapper _patternForTriggerMapper;
        
        public OccasionCardBuilder(IConfigRepository configRepository,
            TriggerMapper triggerMapper,
            PatternForOccasionMapper patternForOccasionMapper,
            PatternForTriggerMapper patternForTriggerMapper)
        {
            _configRepository = configRepository;
            _triggerMapper = triggerMapper;
            _patternForOccasionMapper = patternForOccasionMapper;
            _patternForTriggerMapper = patternForTriggerMapper;
        }

        public OccasionSmallCard BuildSmallCard(Occasion occasion)
        {
            var occasionPattern = GetPatternForOccasion(occasion.TriggerId);
            var textBuilder = new TextBuilder(occasion);

            return new OccasionSmallCard
            {
                CreateDate = occasion.CreateDate,
                ImageLink = occasion.User.AvatarLink,
                Text = textBuilder.Build(occasionPattern.Title)
                       + (String.IsNullOrEmpty(occasionPattern.Subtitle) ? textBuilder.Build(occasionPattern.Subtitle) : "")
            };
        }

        public OccasionFullCard BuildFullCard(Occasion occasion)
        {
            var occasionPattern = GetPatternForOccasion(occasion.TriggerId);
            var triggerPattern = GetRandomPatternForTrigger(occasion.TriggerId);
            var textBuilder = new TextBuilder(occasion);

            return new OccasionFullCard
            {
                Title = textBuilder.Build(occasionPattern.Title),
                Subtitle = textBuilder.Build(occasionPattern.Subtitle),
                ImageLink = triggerPattern?.ImageLink,
                SoundLink = occasionPattern.SoundLink,
                Text = triggerPattern == null ? null : textBuilder.Build(triggerPattern.Text)
            };
        }

        private PatternForOccasion GetPatternForOccasion(long triggerId)
        {
            var trigger = _triggerMapper.ToBll(_configRepository.GetTrigger(triggerId));
            return _patternForOccasionMapper.ToBll(_configRepository.GetPatternForOccasion(trigger.OccasionTypeId));
        }

        private PatternForTrigger GetRandomPatternForTrigger(long triggerId)
        {
            var rand = new Random();
            var triggerPatterns = _configRepository.GetPatternForTriggers(triggerId)
                ?.Select(x => _patternForTriggerMapper.ToBll(x))
                .ToArray();
            return triggerPatterns?[rand.Next(triggerPatterns.Length)];
        }
    }
}
