using System;
using System.Net;

namespace Honour.Common.Rest
{
    public class RestServerSideException : RestHttpStatusException
    {
        public RestServerSideException(HttpStatusCode status)
            : base(status)
        {
        }


        public RestServerSideException(HttpStatusCode status, string message)
            : base(status, message)
        {
        }

        public RestServerSideException(HttpStatusCode status, Exception innerException)
            : base(status, innerException)
        {
        }

        public RestServerSideException(HttpStatusCode status, string message, Exception innerException)
            : base(status, message, innerException)
        {
        }
    }
}