using System.Collections.Generic;

namespace AppFiscDf.Domain.Entities
{
    public partial class JudgmentSector
    {
        public JudgmentSector()
        {
            InspectionDocumentList = new HashSet<InspectionDocument>();
        }

        public decimal JudgmentSectorId { get; set; }
        public string Acronym { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ICollection<InspectionDocument> InspectionDocumentList { get; set; }
    }
}