using Newtonsoft.Json;

namespace VkToDiscordTransfer.Models
{
    public class Request
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("group_id")]
        public int GroupId { get; set; }
    }
}