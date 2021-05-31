using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AppFiscDf.Application.Model.RequestResponse
{
    public class InspectionAgentResponse
    {
        public decimal InspectionAgentId { get; set; }
        public string Name { get; set; }
        public string Employment { get; set; }
        public string Organ { get; set; }
        public decimal NrUfId { get; set; }
        public string Registry { get; set; }
        public byte[] SignatureImage { get; set; }
        public DateTime? SignatureDate { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public bool Status { get; set; }

        [JsonPropertyName("sequentialRequestResponses")]
        public List<SequentialRequestResponse> SequentialRequestResponses { get; set; }
    }
}