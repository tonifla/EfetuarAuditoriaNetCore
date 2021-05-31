using System;

namespace AppFiscDf.Domain.Entities
{
    public partial class InsDocAttachment
    {
        public decimal InsDocAttachmentId { get; set; }
        public decimal InspectionDocumentId { get; set; }
        public string Name { get; set; }
        public byte[] AttachmentFile { get; set; }
        public DateTime? AttachmentDate { get; set; }
    }
}