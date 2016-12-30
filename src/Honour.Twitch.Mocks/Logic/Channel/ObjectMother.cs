using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Honour.Twitch.Domain.Channel;

namespace Honour.Twitch.Mocks.Logic.Channel
{
    public static class ObjectMother
    {
        public static ChannelDomainModel CreateChannelModel()
        {
            return new ChannelDomainModel();
        }
    }
}
