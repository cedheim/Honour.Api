using FakeItEasy;
using Honour.Common.Rest;
using Honour.Twitch.Contract.Channel;
using Honour.Twitch.Logic.Channel;
using Microsoft.Extensions.Options;

namespace Honour.Twitch.Mocks.Logic.Channel
{
    public abstract class ChannelTestBase : ServiceTestBase
    {
        protected IChannelService ChannelService;

        protected ChannelTestBase()
        {
            ChannelService = new ChannelService(Configuration, RestClient);           
        }
    }
}