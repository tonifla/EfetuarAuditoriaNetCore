namespace AppFiscDf.Domain.Entities
{
    public class InsDocServiceOrder
    {
        public decimal InspectionDocumentId { get; set; }
        public decimal? Number { get; set; }
        public decimal? Year { get; set; }
        public decimal? NrUfId { get; set; }
        public bool Type { get; set; }

        public virtual NrUf NrUf { get; set; }
    }
}