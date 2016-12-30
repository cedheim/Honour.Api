using System.Collections.Generic;
using System.Linq;

namespace Honour.Common.Rest
{
    public class RestConfiguration
    {
        public RestConfiguration()
        {
            Accept = new List<string> {"application/json"};
            CustomHeaders = new Dictionary<string, List<string>>();
            ContentType = new List<string> { "application/json" };
        }

        public List<string> Accept { get; set; }
        public Dictionary<string, List<string>> CustomHeaders { get; set; }
        public List<string> ContentType { get; set; }

        public RestConfiguration Copy()
        {
            return new RestConfiguration
            {
                Accept = this.Accept.ToList(),
                CustomHeaders = this.CustomHeaders.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.ToList()),
                ContentType = this.ContentType.ToList()
            };
        }
    }
}