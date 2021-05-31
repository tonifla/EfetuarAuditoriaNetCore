using System.Collections.Generic;

namespace AppFiscDf.Domain.Entities
{
    public partial class Activity
    {
        public Activity()
        {
            InsDocEconomicAgentList = new HashSet<InsDocEconomicAgent>();
            TypificationList = new HashSet<Typification>();
        }

        public decimal ActivityId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<InsDocEconomicAgent> InsDocEconomicAgentList { get; set; }
        public virtual ICollection<Typification> TypificationList { get; set; }
    }
}