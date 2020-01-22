using Newtonsoft.Json;

namespace JiraLikeYou.Backend.Dto.Status
{
    public class StatusUpdateDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}