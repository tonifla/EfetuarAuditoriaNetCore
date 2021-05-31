namespace AppFiscDf.Domain.Entities
{
    public partial class EconomicAgent
    {
        public string EconomicAgentId { get; set; }
        public string InstallationCnpj { get; set; }
        public string Company { get; set; }
        public string ZipCode { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string Neighborhood { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string AuthorizationNumber { get; set; }
        public string PublicationDate { get; set; }
        public string Status { get; set; }
        public string InstallationType { get; set; }
        public string InstallationIdentification { get; set; }
        public string ReducedCompany { get; set; }
        public string AdministratorCnpj { get; set; }
        public string EffectiveStartDate { get; set; }
        public string EffectiveEndDate { get; set; }
        public string UfAcronym { get; set; }
    }
}