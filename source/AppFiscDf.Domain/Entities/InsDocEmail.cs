namespace AppFiscDf.Domain.Entities
{
    public class InsDocEmail
    {
        public decimal InsDocEmailId { get; set; }
        public decimal InspectionDocumentId { get; set; }
        public string Sender { get; set; }
        public string Recipients { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public ResponseType TypeMessage { get; set; }
    }

    public enum ResponseType
    {
        FALHA = 0,
        SUCESSO = 1
    }
}