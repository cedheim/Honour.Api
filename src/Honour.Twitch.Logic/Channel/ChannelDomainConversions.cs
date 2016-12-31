using Honour.Twitch.Contract.Channel;
using Honour.Twitch.Domain.Channel;

namespace Honour.Twitch.Logic.Channel
{
    public static class ChannelDomainConversions
    {
        public static ChannelReadModel ToReadModel(this ChannelDomainModel domainModel)
        {
            return new ChannelReadModel
            {
                Background = domainModel.Background,
                Banner = domainModel.Banner,
                BroadcasterLanguage = domainModel.BroadcasterLanguage,
                CreatedAt = domainModel.CreatedAt,
                Delay = domainModel.Delay,
                DisplayName = domainModel.DisplayName,
                Followers = domainModel.Followers,
                Game = domainModel.Game,
                Id = domainModel.Id,
                Language = domainModel.Language,
                Logo = domainModel.Logo,
                Mature = domainModel.Mature,
                Name = domainModel.Name,
                Partner = domainModel.Partner,
                ProfileBanner = domainModel.ProfileBanner,
                ProfileBannerBackgroundColor = domainModel.ProfileBannerBackgroundColor,
                Status = domainModel.Status,
                UpdatedAt = domainModel.UpdatedAt,
                Url = domainModel.Url,
                VideoBanner = domainModel.VideoBanner,
                Views = domainModel.Views
            };
        }
    }
}