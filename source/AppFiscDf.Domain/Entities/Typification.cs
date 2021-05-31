using System.Collections.Generic;

namespace AppFiscDf.Domain.Entities
{
    public partial class Typification
    {
        public Typification()
        {
            InsDocTypificationList = new HashSet<InsDocTypification>();
        }

        public decimal TypificationId { get; set; }
        public decimal ActivityId { get; set; }
        public decimal InspectionProcedureId { get; set; }
        public string Title { get; set; }
        public string Model { get; set; }
        public string JsonInput { get; set; }
        public string HTMLInput { get; set; }

        public virtual Activity Activity { get; set; }
        public virtual InspectionProcedure InspectionProcedure { get; set; }
        public virtual ICollection<InsDocTypification> InsDocTypificationList { get; set; }
    }
}