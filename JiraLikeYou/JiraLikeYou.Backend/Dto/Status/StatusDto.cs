using Newtonsoft.Json;

namespace JiraLikeYou.Backend.Dto.Status
{
    public class StatusDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}