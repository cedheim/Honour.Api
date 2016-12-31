using System;
using System.Net;

namespace Honour.Common.Rest
{
    public class RestHttpStatusException : RestException
    {
        public RestHttpStatusException(HttpStatusCode status)
            : base($"HttpStatus: {status} occured.")
        {
            StatusCode = status;
        }

        public RestHttpStatusException(HttpStatusCode status, string message)
            : base($"HttpStatus: {status} occured.\n{message}")
        {
            StatusCode = status;
        }

        public RestHttpStatusException(HttpStatusCode status, Exception innerException)
            : base($"HttpStatus: {status} occured.", innerException)
        {
            StatusCode = status;
        }


        public RestHttpStatusException(HttpStatusCode status, string message, Exception innerException)
            : base($"HttpStatus: {status} occured.\n{message}", innerException)
        {
            StatusCode = status;
        }

        public HttpStatusCode StatusCode { get; set; }
    }
}