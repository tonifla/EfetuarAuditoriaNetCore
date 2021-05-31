namespace AppFiscDf.Domain.Entities
{
    public partial class InsDocInspectionAgent
    {
        public decimal InspectionAgentId { get; set; }
        public decimal InspectionDocumentId { get; set; }
        public decimal Sort { get; set; }

        public virtual InspectionAgent InspectionAgent { get; set; }
        public virtual InspectionDocument InspectionDocument { get; set; }
    }
}