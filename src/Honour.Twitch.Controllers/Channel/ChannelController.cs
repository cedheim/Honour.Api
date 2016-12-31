using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Honour.Twitch.Contract.Channel;
using Microsoft.AspNetCore.Mvc;

namespace Honour.Twitch.Controllers.Channel
{
    [Route("api/twitch/channel/{channel}")]
    public class ChannelController : Controller
    {
        private readonly IChannelService _service;

        public ChannelController(IChannelService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ChannelReadModel> Get(string channel)
        {
            return await this._service.GetChannelAsync(channel);
        }


    }
}