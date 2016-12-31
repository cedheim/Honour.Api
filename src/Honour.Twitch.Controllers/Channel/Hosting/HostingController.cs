using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Honour.Twitch.Contract.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Honour.Twitch.Controllers.Channel.Hosting
{
    [Route("api/twitch/channel/{channel}/hosting")]
    public class HostingController : Controller
    {
        private readonly IHostingService _service;

        public HostingController(IHostingService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<HostingReadModel>> Get(string channel)
        {
            return await this._service.ListHostingsAsync(channel);
        }

    }
}
