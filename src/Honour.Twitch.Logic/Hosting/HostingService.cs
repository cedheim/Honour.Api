using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Honour.Common.Rest;
using Honour.Twitch.Contract;
using Honour.Twitch.Contract.Channel;
using Honour.Twitch.Contract.Hosting;
using Honour.Twitch.Domain.Hosting;
using Microsoft.Extensions.Options;

namespace Honour.Twitch.Logic.Hosting
{
    public class HostingService : IHostingService
    {
        private static readonly Dictionary<string, long> ChannelReadModels = new Dictionary<string, long>();

        private readonly IRestClient _client;
        private readonly IChannelService _channelService;
        private readonly TwitchSettings _configuration;

        public HostingService(IOptions<TwitchSettings> configuration, IRestClient client, IChannelService channelService)
        {
            this._client = client;
            this._channelService = channelService;
            this._configuration = configuration.Value;
        }

        public async Task<IEnumerable<HostingReadModel>> ListHostingsAsync(string channelName)
        {
            var channelId = await GetChannelIdAsync(channelName);
            var hostingUri = new Uri(string.Format(this._configuration.Hosts, channelId));

            var model = await this._client.GetAsync<HostingDomainModel>(hostingUri, new RestConfiguration
            {
                Accept = new List<string> {"application/json"}
            });

            return model.ToReadModel();
        }

        private async Task<long> GetChannelIdAsync(string channelName)
        {
            lock (ChannelReadModels)
            {
                if (ChannelReadModels.ContainsKey(channelName))
                {
                    return ChannelReadModels[channelName];
                }
            }

            var channel = await this._channelService.GetChannelAsync(channelName);

            lock (ChannelReadModels)
            {
                if (!ChannelReadModels.ContainsKey(channelName))
                {
                    ChannelReadModels.Add(channelName, channel.Id);
                }
            }

            return channel.Id;
        }
    }
}