using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Counselor_Active_CaseLoad_Transfer.Models
{
    public class ProgramType
    {
        [Key]
        [Column("program_id")]
        public int ProgramId { get; set; }
        public string? Code { get; set; }
      
        public string? Description { get; set; } // optional, depending on schema
    }
}
