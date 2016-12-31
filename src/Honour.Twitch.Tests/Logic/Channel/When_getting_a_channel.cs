using System;
using System.Threading;
using System.Threading.Tasks;
using FakeItEasy;
using Honour.Common.Rest;
using Honour.Twitch.Contract.Channel;
using Honour.Twitch.Domain.Channel;
using Honour.Twitch.Mocks;
using Honour.Twitch.Mocks.Logic;
using Honour.Twitch.Mocks.Logic.Channel;
using NUnit.Framework;

namespace Honour.Twitch.Tests.Logic.Channel
{
    [TestFixture]
    public class When_getting_a_channel : ChannelTestBase
    {
        private ChannelReadModel _result;
        private ChannelDomainModel _domainModel;

        [OneTimeSetUp]
        public async Task SetUp()
        {
            this._domainModel = ObjectMother.CreateChannelModel();

            A.CallTo(() => RestClient.GetAsync<ChannelDomainModel>(A<Uri>.Ignored, A<RestConfiguration>.Ignored, A<CancellationToken>.Ignored))
                .Returns(Task.FromResult(this._domainModel));

            this._result = await this.ChannelService.GetChannelAsync(Defaults.ChannelName);
        }

        [Test]
        public void Should_return_a_result()
        {
            Assert.IsNotNull(this._result);
        }

        [Test]
        public void Should_return_the_correct_result()
        {
            Assert.IsTrue(this._domainModel.CompareTo(this._result), "this._model.CompareTo(this._result)");
        }

        [Test]
        public void Should_have_called_the_rest_client_with_the_correct_uri()
        {
            A.CallTo(() => RestClient.GetAsync<ChannelDomainModel>(A<Uri>.That.Matches(uri => uri.OriginalString == TwitchSettings.ChannelUri), A<RestConfiguration>.Ignored, A<CancellationToken>.Ignored))
                .MustHaveHappened(Repeated.Exactly.Once);
        }

        [Test]
        public void Should_have_called_the_rest_client_with_the_correct_api_version()
        {
            A.CallTo(() => RestClient.GetAsync<ChannelDomainModel>(A<Uri>.Ignored, A<RestConfiguration>.That.Matches(cfg => cfg.Accept.Contains(TwitchSettings.Accept)), A<CancellationToken>.Ignored))
                .MustHaveHappened(Repeated.Exactly.Once);
        }

        [Test]
        public void Should_have_called_the_rest_client_with_the_correct_client_id()
        {
            A.CallTo(() => RestClient.GetAsync<ChannelDomainModel>(A<Uri>.Ignored, A<RestConfiguration>.That.Matches(cfg => cfg.CustomHeaders["Client-ID"].Contains(TwitchSettings.ClientId)), A<CancellationToken>.Ignored))
                .MustHaveHappened(Repeated.Exactly.Once);
        }
    }
}