namespace AppFiscDf.Application.Model.RequestResponse
{
    public class InsDocServiceOrderRequestResponse
    {
        public decimal InspectionDocumentId { get; set; }
        public decimal? Number { get; set; }
        public decimal? Year { get; set; }
        public decimal? NrUfId { get; set; }
        public bool Type { get; set; }
    }
}