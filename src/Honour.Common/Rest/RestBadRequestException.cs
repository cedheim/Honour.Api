using System;
using System.Net;

namespace Honour.Common.Rest
{
    public class RestBadRequestException : RestHttpStatusException
    {
        public RestBadRequestException(HttpStatusCode status)
            : base(status)
        {
        }


        public RestBadRequestException(HttpStatusCode status, string message)
            : base(status, message)
        {
        }

        public RestBadRequestException(HttpStatusCode status, Exception innerException)
            : base(status, innerException)
        {
        }
        
        public RestBadRequestException(HttpStatusCode status, string message, Exception innerException)
            : base(status, message, innerException)
        {
        }
    }
}