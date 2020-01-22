using Newtonsoft.Json;

namespace JiraLikeYou.Backend.Dto.Status
{
    public class StatusCreateDto
    {
        [JsonProperty("syscode")]
        public int Syscode { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}