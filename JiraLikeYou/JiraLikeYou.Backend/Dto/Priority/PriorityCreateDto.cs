using Newtonsoft.Json;

namespace JiraLikeYou.Backend.Dto.Priority
{
    public class PriorityCreateDto
    {
        [JsonProperty("syscode")]
        public int Syscode { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}