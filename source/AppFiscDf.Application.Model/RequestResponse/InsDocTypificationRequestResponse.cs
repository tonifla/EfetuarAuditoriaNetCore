namespace AppFiscDf.Application.Model.RequestResponse
{
    public class InsDocTypificationRequestResponse
    {
        public decimal InsDocTypificationId { get; set; }
        public decimal TypificationId { get; set; }
        public decimal InspectionDocumentId { get; set; }
        public string JsonOutput { get; set; }
        public bool FreeText { get; set; }
    }
}