using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Honour.Common.Mocks.Rest
{
    public class PostReadModel
    {
        public string UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

    }
}
