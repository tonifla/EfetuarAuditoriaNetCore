using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AppFiscDf.Application.Model.RequestResponse
{
    public class InspectionProcedureResponse
    {
        public InspectionProcedureResponse()
        {
            TypificationList = new HashSet<TypificationResponse>();
        }

        public decimal InspectionProcedureId { get; set; }
        public decimal UorgId { get; set; }
        public string Text { get; set; }
        public decimal? Sort { get; set; }

        [JsonPropertyName("typifications")]
        public virtual ICollection<TypificationResponse> TypificationList { get; set; }
    }
}