using System.Net;

namespace Honour.Common.Domain
{
    public class Error
    {
        public HttpStatusCode StatusCode { get; set; }

        public string Message { get; set; }
    }
}