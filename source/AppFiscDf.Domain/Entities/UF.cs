using System.Collections.Generic;

namespace AppFiscDf.Domain.Entities
{
    public partial class Uf
    {
        public Uf()
        {
            InsDocEconomicAgentList = new HashSet<InsDocEconomicAgent>();
            InspectionDocumentList = new HashSet<InspectionDocument>();
        }

        public string UfAcronym { get; set; }
        public decimal NrUfId { get; set; }
        public string Name { get; set; }
        public decimal UfReference { get; set; }

        public virtual NrUf NrUf { get; set; }
        public virtual ICollection<InsDocEconomicAgent> InsDocEconomicAgentList { get; set; }
        public virtual ICollection<InspectionDocument> InspectionDocumentList { get; set; }
    }
}