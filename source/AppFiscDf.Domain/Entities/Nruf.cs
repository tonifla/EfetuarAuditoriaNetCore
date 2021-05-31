using System.Collections.Generic;

namespace AppFiscDf.Domain.Entities
{
    public partial class NrUf
    {
        public NrUf()
        {
            InspectionAgentList = new HashSet<InspectionAgent>();
            InsDocServiceOrderList = new HashSet<InsDocServiceOrder>();
            UfList = new HashSet<Uf>();
        }

        public decimal NrUfId { get; set; }
        public string Acronym { get; set; }
        public string Name { get; set; }
        public string Responsible { get; set; }
        public string SubstituteResponsible { get; set; }
        public string Address { get; set; }
        public string PlanningEmail { get; set; }
        public string ResultEmail { get; set; }

        public virtual ICollection<InspectionAgent> InspectionAgentList { get; set; }
        public virtual ICollection<InsDocServiceOrder> InsDocServiceOrderList { get; set; }
        public virtual ICollection<Uf> UfList { get; set; }
    }
}