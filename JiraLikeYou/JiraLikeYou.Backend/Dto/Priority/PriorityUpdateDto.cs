using Newtonsoft.Json;

namespace JiraLikeYou.Backend.Dto.Priority
{
    public class PriorityUpdateDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}