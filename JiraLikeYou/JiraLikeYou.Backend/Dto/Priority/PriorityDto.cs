using Newtonsoft.Json;

namespace JiraLikeYou.Backend.Dto.Priority
{
    public class PriorityDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("syscode")]
        public int Syscode { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}