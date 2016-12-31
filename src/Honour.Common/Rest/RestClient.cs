using System;
using System.Net;
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
                HttpResponseMessage result;
                string message;

                try
                {
                    result = await client.GetAsync(uri, cancellationToken);
                    message = await result.Content.ReadAsStringAsync();
                }
                catch (Exception e)
                {
                    throw new RestException("An error occured during remote call", e);
                }
                
                if ((int)result.StatusCode >= 400 && (int)result.StatusCode < 500)
                {
                    throw new RestBadRequestException(result.StatusCode, message);
                }
                if ((int) result.StatusCode >= 500)
                {
                    throw new RestServerSideException(result.StatusCode, message);
                }
                if (result.StatusCode != HttpStatusCode.OK)
                {
                    throw new RestHttpStatusException(result.StatusCode, message);
                }

                return Newtonsoft.Json.JsonConvert.DeserializeObject<TResult>(message);
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