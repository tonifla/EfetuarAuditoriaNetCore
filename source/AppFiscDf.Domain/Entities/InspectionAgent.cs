using System;
using System.Collections.Generic;

namespace AppFiscDf.Domain.Entities
{
    public partial class InspectionAgent
    {
        public InspectionAgent()
        {
            InsDocInspectionAgentList = new HashSet<InsDocInspectionAgent>();
            SequentialList = new HashSet<Sequential>();
        }

        public decimal InspectionAgentId { get; set; }
        public string Name { get; set; }
        public string Employment { get; set; }
        public string OrganOfOrigin { get; set; }
        public decimal NrUfId { get; set; }
        public string Registry { get; set; }
        public byte[] SignatureImage { get; set; }
        public DateTime? SignatureDate { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public bool Status { get; set; }

        public virtual NrUf NrUf { get; set; }
        public virtual ICollection<InsDocInspectionAgent> InsDocInspectionAgentList { get; set; }
        public virtual ICollection<Sequential> SequentialList { get; set; }
    }
}