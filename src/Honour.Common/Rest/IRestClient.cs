using System;
using System.Threading;
using System.Threading.Tasks;

namespace Honour.Common.Rest
{
    public interface IRestClient
    {
        Task<TResult> GetAsync<TResult>(Uri uri, CancellationToken cancellationToken = default(CancellationToken));

        Task<TResult> GetAsync<TResult>(Uri uri, RestConfiguration configuration, CancellationToken cancellationToken = default(CancellationToken));
    }
}