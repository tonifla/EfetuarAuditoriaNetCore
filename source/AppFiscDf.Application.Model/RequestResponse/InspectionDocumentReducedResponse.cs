using System;

namespace AppFiscDf.Application.Model.RequestResponse
{
    public class InspectionDocumentReducedResponse
    {
        public decimal InspectionDocumentId { get; set; }
        public decimal SequentialCode { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}