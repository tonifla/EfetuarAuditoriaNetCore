using System.Collections.Generic;

namespace AppFiscDf.Domain.Entities
{
    public partial class InspectionProcedure
    {
        public InspectionProcedure()
        {
            TypificationList = new HashSet<Typification>();
        }

        public decimal InspectionProcedureId { get; set; }
        public decimal UorgId { get; set; }
        public string Text { get; set; }
        public decimal? Sort { get; set; }

        public virtual Uorg Uorg { get; set; }
        public virtual ICollection<Typification> TypificationList { get; set; }
    }
}