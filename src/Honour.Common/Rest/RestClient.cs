using System;
using System.Threading.Tasks;

namespace Honour.Common.Rest
{
    public class RestClient : IRestClient
    {
        private static readonly RestConfiguration DefaultConfiguration = new RestConfiguration();

        public async Task<TResult> GetAsync<TResult>(Uri uri)
        {
            return await this.GetAsync<TResult>(uri, DefaultConfiguration.Copy());
        }

        public async Task<TResult> GetAsync<TResult>(Uri uri, RestConfiguration configuration)
        {
            throw new NotImplementedException();
        }
    }
}