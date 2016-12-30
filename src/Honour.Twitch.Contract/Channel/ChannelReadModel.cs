using System;

namespace Honour.Twitch.Contract.Channel
{
    public class ChannelReadModel
    {
        public bool Mature { get; set; }
        
        public string Status { get; set; }
        
        public string BroadcasterLanguage { get; set; }
        
        public string DisplayName { get; set; }
        
        public string Game { get; set; }
        
        public string Language { get; set; }

        public long Id { get; set; }
        
        public string Name { get; set; }
        
        public DateTime CreatedAt { get; set; }
        
        public DateTime UpdatedAt { get; set; }
        
        public string Delay { get; set; }

        public string Logo { get; set; }
        
        public string Banner { get; set; }
        
        public string VideoBanner { get; set; }
        
        public string Background { get; set; }
        
        public string ProfileBanner { get; set; }
        
        public string ProfileBannerBackgroundColor { get; set; }

        public bool Partner { get; set; }

        public string Url { get; set; }

        public long Views { get; set; }

        public long Followers { get; set; }
    }
}