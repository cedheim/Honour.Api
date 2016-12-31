using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeItEasy;
using Honour.Twitch.Contract.Channel;
using Honour.Twitch.Contract.Hosting;
using Honour.Twitch.Logic.Hosting;

namespace Honour.Twitch.Mocks.Logic.Hosting
{
    public abstract class HostingTestBase : ServiceTestBase
    {
        protected IChannelService ChannelService;

        protected IHostingService HostingService;

        protected HostingTestBase()
        {
            ChannelService = A.Fake<IChannelService>();

            HostingService = new HostingService(Configuration, RestClient, ChannelService);
        }

    }
}
