using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Runtime.Serialization;

namespace AppFiscDf.Api.Extensions
{
    [Serializable]
    public class HttpStatusCodeException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public string ContentType { get; set; } = @"text/plain";

        public HttpStatusCodeException(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }

        public HttpStatusCodeException(HttpStatusCode statusCode, string message) : base(message)
        {
            this.StatusCode = statusCode;
        }

        public HttpStatusCodeException(HttpStatusCode statusCode, Exception inner) : this(statusCode, inner.ToString())
        {
        }

        public HttpStatusCodeException(HttpStatusCode statusCode, JObject errorObject) : this(statusCode, errorObject.ToString())
        {
            this.ContentType = @"application/json";
        }

        protected HttpStatusCodeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}