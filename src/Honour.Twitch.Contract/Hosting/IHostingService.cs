using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Honour.Twitch.Contract.Hosting;

namespace Honour.Twitch.Contract.Hosting
{
    public interface IHostingService
    {
        Task<IEnumerable<HostingReadModel>> ListHostingsAsync(string channel);
    }
}
