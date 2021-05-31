using System;
using System.Collections.Generic;

namespace AppFiscDf.Domain.Entities
{
    public partial class InspectionDocument
    {
        public InspectionDocument()
        {
            InsDocInspectionAgentList = new HashSet<InsDocInspectionAgent>();
            InsDocWitnessList = new HashSet<InsDocWitness>();
            InsDocTypificationList = new HashSet<InsDocTypification>();
            InsDocAttachmentList = new HashSet<InsDocAttachment>();
        }

        public decimal InspectionDocumentId { get; set; }
        public decimal UfReference { get; set; }
        public decimal SequentialCode { get; set; }
        public string DocumentNumber { get; set; }
        public bool Finished { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? JudgmentSectorId { get; set; }

        public virtual Sequential Sequential { get; set; }
        public virtual Uf Uf { get; set; }
        public virtual InsDocSerialized InsDocSerialized { get; set; }
        public virtual InsDocServiceOrder InsDocServiceOrder { get; set; }

        public virtual InsDocEconomicAgent InsDocEconomicAgent { get; set; }

        public virtual InsDocRepresentative InsDocRepresentative { get; set; }
        public virtual ICollection<InsDocInspectionAgent> InsDocInspectionAgentList { get; set; }
        public virtual ICollection<InsDocWitness> InsDocWitnessList { get; set; }
        public virtual ICollection<InsDocTypification> InsDocTypificationList { get; set; }
        public virtual ICollection<InsDocAttachment> InsDocAttachmentList { get; set; }
        public virtual ICollection<InsDocEmail> InsDocEmailList { get; set; }
    }
}