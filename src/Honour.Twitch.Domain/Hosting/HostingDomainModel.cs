using Newtonsoft.Json;

namespace Honour.Twitch.Domain.Hosting
{
    public class HostingDomainModel
    {
        [JsonProperty("hosts")]
        public HostingTargetDomainModel[] Hosts { get; set; }
    }
}