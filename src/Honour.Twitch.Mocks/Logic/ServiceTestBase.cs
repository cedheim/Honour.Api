using FakeItEasy;
using Honour.Common.Rest;
using Honour.Twitch.Contract.Channel;
using Microsoft.Extensions.Options;

namespace Honour.Twitch.Mocks.Logic
{
    public abstract class ServiceTestBase
    {
        protected IOptions<Twitch.Contract.TwitchSettings> Configuration;

        protected Twitch.Contract.TwitchSettings Settings;

        protected IRestClient RestClient;

        protected ServiceTestBase()
        {
            Configuration = A.Fake<IOptions<Twitch.Contract.TwitchSettings>>();
            RestClient = A.Fake<IRestClient>();
            Settings = new Contract.TwitchSettings
            {
                Channel = TwitchSettings.ChannelUriPattern,
                Accept = TwitchSettings.Accept,
                ClientId = TwitchSettings.ClientId,
                Hosts = TwitchSettings.HostingUriPattern
            };

            A.CallTo(() => Configuration.Value).Returns(Settings);
        }
        
        protected static class TwitchSettings
        {
            public const string Accept = "application/vnd.twitchtv.v3+json";
            public const string ClientId = "eo4HXy0oLvzH4JBIAbGAcLFiBucVYGBx";
            public const string ChannelUriPattern = "https://api.twitch.tv/kraken/channels/{0}";
            public const string HostingUriPattern = "https://tmi.twitch.tv/hosts?include_logins=1&host={0}";
            public static readonly string ChannelUri = string.Format(ChannelUriPattern, Defaults.ChannelName);
            public static readonly string HostingUri = string.Format(HostingUriPattern, Defaults.ChannelId);
        }
    }
}