using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FakeItEasy;
using Honour.Common.Rest;
using Honour.Twitch.Contract.Channel;
using Honour.Twitch.Contract.Hosting;
using Honour.Twitch.Domain.Channel;
using Honour.Twitch.Domain.Hosting;
using Honour.Twitch.Mocks;
using Honour.Twitch.Mocks.Logic.Hosting;
using NUnit.Framework;

namespace Honour.Twitch.Tests.Logic.Hosting
{
    [TestFixture]
    public class When_getting_hosts : HostingTestBase
    {
        private HostingDomainModel _domainModel;
        private ChannelReadModel _channel;
        private List<HostingReadModel> _result;

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            this._domainModel = ObjectMother.CreateHostingModel();
            this._channel = ObjectMother.CreateChannelReadModel();

            A.CallTo(() => RestClient.GetAsync<HostingDomainModel>(A<Uri>.Ignored, A<RestConfiguration>.Ignored, A<CancellationToken>.Ignored))
                .Returns(Task.FromResult(this._domainModel));
            A.CallTo(() => ChannelService.GetChannelAsync(Defaults.ChannelName))
                .Returns(Task.FromResult(this._channel));

            this._result = (await this.HostingService.ListHostingsAsync(Defaults.ChannelName)).ToList();
        }

        [Test]
        public void Should_have_returned_the_correct_result()
        {
            Assert.IsNotNull(this._result, "this._result != null");
            Assert.AreEqual(this._domainModel.Hosts.Length, this._result.Count, "Count");

            for (var i = 0; i < this._domainModel.Hosts.Length; ++i)
            {
                var domainModel = this._domainModel.Hosts[i];
                var readModel = this._result[i];

                Assert.AreEqual(domainModel.TargetId, readModel.Id);
                Assert.AreEqual(domainModel.TargetDisplayName, readModel.DisplayName);
                Assert.AreEqual(domainModel.TargetLogin, readModel.Name);
            }
            


        }

        [Test]
        public void Should_have_called_the_channel_service()
        {
            A.CallTo(() => ChannelService.GetChannelAsync(Defaults.ChannelName))
                .MustHaveHappened(Repeated.Exactly.Once);
        }

        [Test]
        public void Should_have_called_the_rest_client()
        {
            A.CallTo(() => RestClient.GetAsync<HostingDomainModel>(A<Uri>.That.Matches(
                uri => uri.OriginalString == TwitchSettings.HostingUri), 
                A<RestConfiguration>.That.Matches(cfg => cfg.Accept.Contains("application/json")), 
                A<CancellationToken>.Ignored))
                .MustHaveHappened(Repeated.Exactly.Once);
        }

    }
}