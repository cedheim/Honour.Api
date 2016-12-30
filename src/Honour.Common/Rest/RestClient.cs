using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Honour.Common.Rest
{
    public class RestClient : IRestClient
    {
        private static readonly RestConfiguration DefaultConfiguration = new RestConfiguration
        {
            
        };

        public async Task<TResult> GetAsync<TResult>(Uri uri, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.GetAsync<TResult>(uri, DefaultConfiguration.Copy(), cancellationToken);
        }

        public async Task<TResult> GetAsync<TResult>(Uri uri, RestConfiguration configuration, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var client = new HttpClient())
            {
                ConfigureHttpClient(client, configuration);

                var result = await client.GetAsync(uri, cancellationToken);
                return Newtonsoft.Json.JsonConvert.DeserializeObject<TResult>(await result.Content.ReadAsStringAsync());
            }
        }

        private static void ConfigureHttpClient(HttpClient client, RestConfiguration configuration)
        {
            foreach (var accept in configuration.Accept)
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(accept));
            }

            foreach (var customHeader in configuration.CustomHeaders)
            {
                client.DefaultRequestHeaders.Add(customHeader.Key, customHeader.Value);
            }

            //client.DefaultRequestHeaders.Add("Content-Type", configuration.ContentType);
        }
    }
}