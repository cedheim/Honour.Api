using System;
using System.Threading.Tasks;
using Honour.Common.Mocks.Rest;
using Honour.Common.Rest;
using NUnit.Framework;

namespace Honour.Common.Tests.Rest
{
    public class When_GET_using_rest_client
    {
        private IRestClient _client;
        private PostReadModel _result;

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            this._client = new RestClient();
            this._result = await this._client.GetAsync<PostReadModel>(new Uri("https://jsonplaceholder.typicode.com/posts/1"));
        }

        [Test]
        public void Should_have_returned_a_model()
        {
            Assert.IsNotNull(this._result);
        }
    }
}