using System;

namespace AppFiscDf.Domain.Entities
{
    public partial class InsDocRepresentative
    {
        public decimal InspectionDocumentId { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public string Employment { get; set; }
        public DateTime? SignatureDate { get; set; }
        public byte[] SignatureImage { get; set; }
    }
}