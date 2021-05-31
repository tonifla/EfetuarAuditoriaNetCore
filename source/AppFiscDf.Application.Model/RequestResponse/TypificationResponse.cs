using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AppFiscDf.Application.Model.RequestResponse
{
    public class TypificationResponse
    {
        public TypificationResponse()
        {
            InsDocTypificationList = new HashSet<InsDocTypificationRequestResponse>();
        }

        public decimal TypificationId { get; set; }
        public decimal ActivityId { get; set; }
        public decimal InspectionProcedureId { get; set; }
        public string Title { get; set; }
        public string Model { get; set; }
        public string JsonInput { get; set; }
        public string HTMLInput { get; set; }
        public virtual ActivityResponse Activity { get; set; }
        public virtual InspectionProcedureResponse InspectionProcedure { get; set; }

        [JsonPropertyName("insDocTypifications")]
        public virtual ICollection<InsDocTypificationRequestResponse> InsDocTypificationList { get; set; }
    }
}