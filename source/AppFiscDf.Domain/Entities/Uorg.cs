using System.Collections.Generic;

namespace AppFiscDf.Domain.Entities
{
    public partial class Uorg
    {
        public Uorg()
        {
            InspectionProcedureList = new HashSet<InspectionProcedure>();
        }

        public decimal UorgId { get; set; }
        public string Acronym { get; set; }
        public string Name { get; set; }

        public virtual ICollection<InspectionProcedure> InspectionProcedureList { get; set; }
    }
}