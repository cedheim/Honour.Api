using System;
using System.Threading.Tasks;

namespace Honour.Common.Rest
{
    public interface IRestClient
    {
        Task<TResult> GetAsync<TResult>(Uri uri);

        Task<TResult> GetAsync<TResult>(Uri uri, RestConfiguration configuration);
    }
}