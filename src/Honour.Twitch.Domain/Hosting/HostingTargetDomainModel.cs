using Newtonsoft.Json;

namespace Honour.Twitch.Domain.Hosting
{
    public class HostingTargetDomainModel
    {
        [JsonProperty("host_id")]
        public long HostId { get; set; }

        [JsonProperty("target_id")]
        public long TargetId { get; set; }

        [JsonProperty("host_login")]
        public string HostLogin { get; set; }

        [JsonProperty("target_login")]
        public string TargetLogin { get; set; }

        [JsonProperty("host_display_name")]
        public string HostDisplayName { get; set; }

        [JsonProperty("target_display_name")]
        public string TargetDisplayName { get; set; }
    }
}