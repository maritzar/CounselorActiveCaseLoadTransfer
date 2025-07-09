using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Counselor_Active_CaseLoad_Transfer.Models
{
    public class CaseProgramStatusType
    {
        [Key]
        [Column("caseprogramstatustype_id")]
        public int CaseProgramStatusTypeId { get; set; }
        public required string Code { get; set; }
    }
}
