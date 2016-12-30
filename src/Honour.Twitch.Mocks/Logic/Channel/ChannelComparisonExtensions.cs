using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Honour.Twitch.Contract.Channel;
using Honour.Twitch.Domain.Channel;
using KellermanSoftware.CompareNetObjects;

namespace Honour.Twitch.Mocks.Logic.Channel
{
    public static class ChannelComparisonExtensions
    {
        public static bool CompareTo(this ChannelDomainModel domainModel, ChannelReadModel readModel)
        {
            var compareLogic = new CompareLogic(new ComparisonConfig
            {
                IgnoreObjectTypes = true
            });
            var comparisonResult = compareLogic.Compare(domainModel, readModel);

            if (!comparisonResult.AreEqual)
            {
                var differences = comparisonResult.Differences.Select(difference => $"{difference.GetShortItem()} {difference.GetWhatIsCompared()}").Aggregate((work, next) => $"{work}\n{next}");
                Console.WriteLine(differences);
            }

            

            return comparisonResult.AreEqual;
        }

    }
}
