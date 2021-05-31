using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AppFiscDf.Application.Model.RequestResponse
{
    public class UorgResponse
    {
        public UorgResponse()
        {
            InspectionProcedureList = new HashSet<InspectionProcedureResponse>();
        }

        public decimal UorgId { get; set; }
        public string Acronym { get; set; }
        public string Name { get; set; }

        [JsonPropertyName("inspectionProcedures")]
        public virtual ICollection<InspectionProcedureResponse> InspectionProcedureList { get; set; }
    }
}