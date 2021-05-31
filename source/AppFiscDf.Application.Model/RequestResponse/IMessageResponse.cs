using System;
using System.Net;

namespace AppFiscDf.Application.Model.RequestResponse
{
    public interface IMessageResponse<TResponse>
    {
        string RequestSource { get; set; }

        DateTime ResponseDate { get; set; }

        HttpStatusCode StatusCode { get; set; }

        bool IsSuccess { get; set; }

        string Message { get; set; }

        TResponse Data { get; set; }

        int Count { get; set; }

        int? Page { get; set; }

        int? Limit { get; set; }

        Inconsistencies[] Inconsistencies { get; set; }
    }
}