using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Honour.Common.Rest;
using Honour.Twitch.Contract;
using Honour.Twitch.Contract.Channel;
using Honour.Twitch.Domain.Channel;
using Microsoft.Extensions.Options;

namespace Honour.Twitch.Logic.Channel
{
    public class ChannelService : IChannelService
    {
        private const string ClientIdHeader = "Client-ID";

        private readonly IRestClient _client;
        private readonly TwitchSettings _configuration;

        public ChannelService(IOptions<TwitchSettings> configuration, IRestClient client)
        {
            this._client = client;
            this._configuration = configuration.Value;
        }

        public async Task<ChannelReadModel> GetChannelAsync(string channelName)
        {
            var model = await _client.GetAsync<ChannelDomainModel>(GetChannelUri(channelName), new RestConfiguration
            {
                Accept = new List<string> {  this._configuration.Accept },
                CustomHeaders = new Dictionary<string, List<string>> { { ClientIdHeader, new List<string> { this._configuration.ClientId } } }
            });
            return model.ToReadModel();
        }

        private Uri GetChannelUri(string channelName)
        {
            return new Uri(string.Format(this._configuration.Channel, channelName));
        }
    }
}