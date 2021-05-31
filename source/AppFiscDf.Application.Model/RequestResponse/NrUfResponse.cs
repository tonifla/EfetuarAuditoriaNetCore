using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AppFiscDf.Application.Model.RequestResponse
{
    public class NrUfResponse
    {
        public decimal NrUfId { get; set; }
        public string Acronym { get; set; }
        public string Name { get; set; }
        public string Responsible { get; set; }
        public string SubstituteResponsible { get; set; }
        public string Address { get; set; }
        public string PlanningEmail { get; set; }
        public string ResultEmail { get; set; }

        [JsonPropertyName("ufResponses")]
        public List<UfResponse> UfResponses { get; set; }
    }
}