using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AppFiscDf.Application.Model.RequestResponse
{
    public class InspectionDocumentRequestResponse
    {
        public decimal InspectionDocumentId { get; set; }
        public decimal UfReference { get; set; }
        public decimal SequentialCode { get; set; }
        public string DocumentNumber { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? OrderServiceId { get; set; }
        public decimal? RepresentativeId { get; set; }
        public decimal? JudgmentSectorId { get; set; }

        [JsonPropertyName("InsDocSerializedRequestResponses")]
        public InsDocSerializedRequestResponse InsDocSerializedRequestResponses { get; set; }

        [JsonPropertyName("InsDocServiceOrderRequestResponses")]
        public InsDocServiceOrderRequestResponse InsDocServiceOrderRequestResponses { get; set; }

        [JsonPropertyName("insDocEconomicAgentRequestResponses")]
        public InsDocEconomicAgentRequestResponse InsDocEconomicAgentRequestResponses { get; set; }

        [JsonPropertyName("insDocRepresentativeRequestResponses")]
        public InsDocRepresentativeRequestResponse InsDocRepresentativeRequestResponses { get; set; }

        [JsonPropertyName("insDocInspectionAgentRequestResponses")]
        public List<InsDocInspectionAgentRequestResponse> InsDocInspectionAgentRequestResponses { get; set; }

        [JsonPropertyName("insDocWitnessRequestResponses")]
        public List<InsDocWitnessRequestResponse> InsDocWitnessRequestResponses { get; set; }

        [JsonPropertyName("insDocTypificationRequestResponses")]
        public List<InsDocTypificationRequestResponse> InsDocTypificationRequestResponses { get; set; }

        [JsonPropertyName("insDocAttachmentRequestResponses")]
        public List<InsDocAttachmentRequestResponse> InsDocAttachmentRequestResponses { get; set; }
    }
}