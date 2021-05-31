using System;
using System.Net;

namespace AppFiscDf.Application.Model.RequestResponse
{
    public class MessageResponse<TResponse> : IMessageResponse<TResponse>
    {
        public string RequestSource { get; set; }
        public DateTime ResponseDate { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; }
        public TResponse Data { get; set; }
        public int Count { get; set; }
        public int? Page { get; set; }
        public int? Limit { get; set; }
        public Inconsistencies[] Inconsistencies { get; set; }
    }
}