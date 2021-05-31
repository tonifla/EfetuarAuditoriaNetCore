using System;

namespace AppFiscDf.Application.Model.RequestResponse
{
    public class InsDocRepresentativeRequestResponse
    {
        public decimal InspectionDocumentId { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public string Employment { get; set; }
        public DateTime? SignatureDate { get; set; }
        public byte[] SignatureImage { get; set; }
    }
}