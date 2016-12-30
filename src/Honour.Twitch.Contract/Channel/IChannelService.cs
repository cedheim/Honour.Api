using System.Threading.Tasks;

namespace Honour.Twitch.Contract.Channel
{
    public interface IChannelService
    {
        Task<ChannelReadModel> GetChannelAsync(string channelName);
    }
}