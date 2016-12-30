using System.Threading.Tasks;
using Honour.Twitch.Contract.Channel;
using Microsoft.Extensions.Configuration;

namespace Honour.Twitch.Logic.Channel
{
    public class ChannelService : IChannelService
    {
        public ChannelService(IConfigurationRoot configuration)
        {
            
        }

        public Task<ChannelReadModel> GetChannelAsync(string channelName)
        {
            throw new System.NotImplementedException();
        }
    }
}