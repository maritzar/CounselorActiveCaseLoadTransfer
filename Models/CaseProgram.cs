using Microsoft.Graph.SecurityNamespace;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Counselor_Active_CaseLoad_Transfer.Models
{
    public class CaseProgram
    {
        [Key]
        [Column("caseprogram_id")]

        public int CaseProgramId { get; set; }

        [Column("case_id")]
        public int CaseId { get; set; }

        [Column("program_id")]
        public int ProgramId { get; set; }

        

        [Column("counselor_id")]
        public Guid? CounselorId { get; set; }

        [ForeignKey(nameof(CaseId))]
        public required Case Case { get; set; }

        [ForeignKey(nameof(ProgramId))]
        public required ProgramType Program { get; set; }
    }
}
