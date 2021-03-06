﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace JiraLikeYou.Backend.Dto
{
    public class JiraWebhookResponseDto
    {
        [JsonProperty("user")]
        public UserJiraDto User { get; set; }

        [JsonProperty("issue")]
        public IssueJiraDto Issue { get; set; }

        [JsonProperty("changelog")]
        public ChangeLogJiraDto ChangeLog { get; set; }
    }

    public class UserJiraDto
    {
        [JsonProperty("emailAddress")]
        public string Email { get; set; }

        [JsonProperty("displayName")]
        public string Name { get; set; }

        [JsonProperty("avatarUrls")]
        public AvatarLinkJiraDto AvatarLinks { get; set; }
    }

    public class AvatarLinkJiraDto
    {
        [JsonProperty("48x48")]
        public string Size48 { get; set; }

        [JsonProperty("32x32")]
        public string Size32 { get; set; }

        [JsonProperty("24x24")]
        public string Size24 { get; set; }

        [JsonProperty("16x16")]
        public string Size16 { get; set; }
    }

    public class IssueJiraDto
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("fields")]
        public FieldIssueJiraDto Field { get; set; }
    }

    public class FieldIssueJiraDto
    {
        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("status")]
        public StatusJiraDto Status { get; set; }

        [JsonProperty("priority")]
        public PriorityJiraDto Priority { get; set; }
    }

    public class StatusJiraDto
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
    }

    public class PriorityJiraDto
    {
        [JsonProperty("Id")]
        public int Id { get;set;}
    }

    public class ChangeLogJiraDto
    {
        [JsonProperty("items")]
        public IEnumerable<ItemJiraDto> Items { get; set; }
    }

    public class ItemJiraDto
    {
        [JsonProperty("field")]
        public string Field { get; set; }
    }
}
