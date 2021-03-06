﻿using System.Linq;
using JiraLikeYou.Backend.Dto;
using JiraLikeYou.BLL.Models;

namespace JiraLikeYou.Backend.Mappers
{
    public class JiraWebhookResponseMapper
    {
        public JiraWebhookResponse ToBll(JiraWebhookResponseDto dto)
        {
            return dto == null
                ? null
                : new JiraWebhookResponse
                {
                    Key = dto.Issue.Key,
                    Name = dto.Issue.Field.Summary,
                    StatusId = dto.Issue.Field.Status.Id,
                    PriorityId = dto.Issue.Field.Priority.Id,
                    User = ToBll(dto.User),
                    ChangeFields = dto.ChangeLog?.Items.Select(x => x.Field) ?? Enumerable.Empty<string>()
                };
        }

        public UserJira ToBll(UserJiraDto dto)
        {
            return dto == null
                ? null
                : new UserJira
                {
                    Email = dto.Email,
                    Name = dto.Name,
                    AvatarLinks = ToBll(dto.AvatarLinks)
                };
        }

        public AvatarLinkJira ToBll(AvatarLinkJiraDto dto)
        {
            return dto == null
                ? null
                : new AvatarLinkJira
                {
                    Size16 = dto.Size16,
                    Size24 = dto.Size24,
                    Size32 = dto.Size32,
                    Size48 = dto.Size48
                };
        }
    }
}
