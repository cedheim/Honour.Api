using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Honour.Twitch.Contract.Channel;
using Honour.Twitch.Domain.Channel;
using Honour.Twitch.Domain.Hosting;

namespace Honour.Twitch.Mocks
{
    public static class ObjectMother
    {
        public static ChannelDomainModel CreateChannelModel()
        {
            return new ChannelDomainModel
            {
                Id = Defaults.ChannelId,
                Name = Defaults.ChannelName,
                DisplayName = Defaults.ChannelDisplayName
            };
        }

        public static ChannelReadModel CreateChannelReadModel()
        {
            return new ChannelReadModel
            {
                Id = Defaults.ChannelId,
                Name = Defaults.ChannelName,
                DisplayName = Defaults.ChannelDisplayName
            };
        }

        public static HostingDomainModel CreateHostingModel()
        {
            return new HostingDomainModel
            {
                Hosts = new[]
                {
                    new HostingTargetDomainModel
                    {
                        TargetId = Defaults.TargetId,
                        TargetDisplayName = Defaults.TargetDisplayName,
                        TargetLogin = Defaults.TargetName,
                        HostDisplayName = Defaults.ChannelDisplayName,
                        HostId = Defaults.ChannelId,
                        HostLogin = Defaults.ChannelName
                    }
                }
            };
        }
    }
}
