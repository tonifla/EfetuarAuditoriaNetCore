using System.Collections.Generic;

namespace AppFiscDf.Domain.Entities
{
    public partial class Sequential
    {
        public Sequential()
        {
            InspectionDocumentList = new HashSet<InspectionDocument>();
        }

        public decimal InspectionAgentId { get; set; }
        public decimal SequentialCode { get; set; }

        public virtual InspectionAgent InspectionAgent { get; set; }
        public virtual ICollection<InspectionDocument> InspectionDocumentList { get; set; }
    }
}