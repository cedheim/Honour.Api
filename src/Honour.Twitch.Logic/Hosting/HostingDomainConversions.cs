using System.Collections.Generic;
using System.Linq;
using Honour.Twitch.Contract.Hosting;
using Honour.Twitch.Domain.Hosting;

namespace Honour.Twitch.Logic.Hosting
{
    public static class HostingDomainConversions
    {
        public static IEnumerable<HostingReadModel> ToReadModel(this HostingDomainModel model)
        {
            if (object.ReferenceEquals(model, default(HostingDomainModel)) ||
                object.ReferenceEquals(model.Hosts, default(HostingTargetDomainModel[])))
            {
                return Enumerable.Empty<HostingReadModel>();
            }

            return model.Hosts.Where(host => !string.IsNullOrEmpty(host.TargetLogin))
                .Select(host => host.ToReadModel());
        }

        public static HostingReadModel ToReadModel(this HostingTargetDomainModel model)
        {
            return new HostingReadModel
            {
                Id = model.TargetId,
                Name = model.TargetLogin,
                DisplayName = model.TargetDisplayName
            };
        }
    }
}