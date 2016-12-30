using System;
using Newtonsoft.Json;

namespace Honour.Twitch.Domain.Channel
{
    public class ChannelDomainModel
    {
        [JsonProperty("mature")]
        public bool Mature { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("broadcaster_language")]
        public string BroadcasterLanguage { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("game")]
        public string Game { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("_id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
  
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("delay")]
        public string Delay { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }

        [JsonProperty("banner")]
        public string Banner { get; set; }

        [JsonProperty("video_banner")]
        public string VideoBanner { get; set; }
        
        [JsonProperty("background")]
        public string Background { get; set; }
        
        [JsonProperty("profile_banner")]
        public string ProfileBanner { get; set; }

        [JsonProperty("profile_banner_background_color")]
        public string ProfileBannerBackgroundColor { get; set; }

        [JsonProperty("partner")]
        public bool Partner { get; set; }
        
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("views")]
        public long Views { get; set; }

        [JsonProperty("followers")]
        public long Followers { get; set; }

        //"_links": {
          //  "self": "https://api.twitch.tv/kraken/channels/honourforever",
          //  "follows": "https://api.twitch.tv/kraken/channels/honourforever/follows",
          //  "commercial": "https://api.twitch.tv/kraken/channels/honourforever/commercial",
          //  "stream_key": "https://api.twitch.tv/kraken/channels/honourforever/stream_key",
          //  "chat": "https://api.twitch.tv/kraken/chat/honourforever",
          //  "subscriptions": "https://api.twitch.tv/kraken/channels/honourforever/subscriptions",
          //  "editors": "https://api.twitch.tv/kraken/channels/honourforever/editors",
          //  "teams": "https://api.twitch.tv/kraken/channels/honourforever/teams",
          //  "videos": "https://api.twitch.tv/kraken/channels/honourforever/videos"
  //}
    }
}