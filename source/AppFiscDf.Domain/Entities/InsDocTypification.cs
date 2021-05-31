namespace AppFiscDf.Domain.Entities
{
    public partial class InsDocTypification
    {
        public decimal InsDocTypificationId { get; set; }
        public decimal TypificationId { get; set; }
        public decimal InspectionDocumentId { get; set; }
        public string JsonOutput { get; set; }
        public bool FreeText { get; set; }

        public virtual Typification Typification { get; set; }
    }
}