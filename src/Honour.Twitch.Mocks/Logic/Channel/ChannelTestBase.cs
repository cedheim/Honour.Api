using FakeItEasy;
using Honour.Common.Rest;
using Honour.Twitch.Contract.Channel;
using Honour.Twitch.Logic.Channel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Honour.Twitch.Mocks.Logic.Channel
{
    public abstract class ChannelTestBase
    {
        protected IOptions<Twitch.Contract.TwitchSettings> Configuration;

        protected Twitch.Contract.TwitchSettings Settings;

        protected IChannelService ChannelService;

        protected IRestClient RestClient;

        protected ChannelTestBase()
        {
            Configuration = A.Fake<IOptions<Twitch.Contract.TwitchSettings>>();
            RestClient = A.Fake<IRestClient>();
            Settings = new Contract.TwitchSettings
            {
                Channel = TwitchSettings.ChannelUriPattern,
                Accept = TwitchSettings.Accept,
                ClientId = TwitchSettings.ClientId
            };

            A.CallTo(() => Configuration.Value).Returns(Settings);

            ChannelService = new ChannelService(Configuration, RestClient);           
        }

        protected static class TwitchSettings
        {
            public const string Accept = "application/vnd.twitchtv.v3+json";
            public const string ClientId = "eo4HXy0oLvzH4JBIAbGAcLFiBucVYGBx";
            public const string ChannelUriPattern = "https://api.twitch.tv/kraken/channels/{0}";

            public static readonly string ChannelUri = string.Format(ChannelUriPattern, Defaults.ChannelName);
        }
    }
}