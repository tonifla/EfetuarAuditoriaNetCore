namespace AppFiscDf.Application.Model.RequestResponse
{
    public class InsDocAttachmentRequestResponse
    {
        public decimal InsDocAttachmentId { get; set; }
        public decimal InspectionDocumentId { get; set; }
        public string Name { get; set; }
        public byte[] AttachmentFile { get; set; }
    }
}