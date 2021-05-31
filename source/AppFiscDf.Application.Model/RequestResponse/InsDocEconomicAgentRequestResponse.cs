using System;

namespace AppFiscDf.Application.Model.RequestResponse
{
    public class InsDocEconomicAgentRequestResponse
    {
        public decimal InspectionDocumentId { get; set; }
        public decimal UfReference { get; set; }
        public decimal ActivityId { get; set; }
        public string AuthorizationNumber { get; set; }
        public string CpfCnpj { get; set; }
        public string InspectedUnit { get; set; }
        public string CompanyName { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Neighborhood { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string AddressComplement { get; set; }
        public string Block { get; set; }
        public string CellPhone { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime? PublicationDf { get; set; }
    }
}