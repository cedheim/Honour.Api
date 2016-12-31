using System;
using System.Threading.Tasks;
using Honour.Common.Mocks.Rest;
using Honour.Common.Rest;
using NUnit.Framework;

namespace Honour.Common.Tests.Rest
{
    public class WhenGetUsingRestClient
    {
        private IRestClient _client;
        private PostReadModel _result;

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            this._client = new RestClient();
            this._result = await this._client.GetAsync<PostReadModel>(new Uri(Data.JsonPlaceHolderPostsUri));
        }

        [Test]
        public void ShouldHaveReturnedAResult()
        {
            Assert.IsNotNull(this._result);
        }

        private static class Data
        {
            public const string JsonPlaceHolderPostsUri = "https://jsonplaceholder.typicode.com/posts/1";
        }
    }
}