using FakeItEasy;
using Honour.Twitch.Contract.Channel;
using Honour.Twitch.Logic.Channel;
using Microsoft.Extensions.Configuration;

namespace Honour.Twitch.Mocks.Logic.Channel
{
    public abstract class ChannelTestBase
    {
        protected IConfigurationRoot Configuration;

        protected IChannelService ChannelService;

        protected ChannelTestBase()
        {
            Configuration = A.Fake<IConfigurationRoot>();
            ChannelService = new ChannelService(Configuration);
        }
    }
}