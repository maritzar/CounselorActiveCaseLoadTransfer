using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Counselor_Active_CaseLoad_Transfer.Models
{
    public class CaseProgramStatus
    {
        [Key]
        [Column("caseprogram_id")]
        public int CaseProgramId { get; set; }

        [Column("caseprogramstatustype_id")]
        public int CaseProgramStatusTypeId { get; set; }

        [ForeignKey(nameof(CaseProgramId))]
        public required CaseProgram CaseProgram { get; set; }
       
        [ForeignKey(nameof(CaseProgramStatusTypeId))]
        public required CaseProgramStatusType CaseProgramStatusType { get; set; }

    }
}
