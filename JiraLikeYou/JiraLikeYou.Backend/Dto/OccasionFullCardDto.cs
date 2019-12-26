using Newtonsoft.Json;

namespace JiraLikeYou.Backend.Dto
{
    
    public class OccasionFullCardDto
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("subtitle")]
        public string Subtitle { get; set; }
        [JsonProperty("imageLink")]
        public string ImageLink { get; set; }
        [JsonProperty("soundLink")]
        public string SoundLink { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
