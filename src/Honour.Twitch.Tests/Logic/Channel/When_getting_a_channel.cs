using System.Threading.Tasks;
using Honour.Twitch.Contract.Channel;
using Honour.Twitch.Mocks.Logic.Channel;
using NUnit.Framework;

namespace Honour.Twitch.Tests.Logic.Channel
{
    [TestFixture]
    public class When_getting_a_channel : ChannelTestBase
    {
        private ChannelReadModel _result;

        [SetUp]
        public async Task SetUp()
        {
            this._result = await this.ChannelService.GetChannelAsync(Defaults.ChannelName);
        }

        [Test]
        public void Should_return_a_result()
        {
            
        }
    }
}