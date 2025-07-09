using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Counselor_Active_CaseLoad_Transfer.Models
{
    public class Case
    {
        [Key]
        [Column("case_id")]
        public int CaseId { get; set; }

        [Column("client_id")]
        public int ClientId { get; set; }

        [ForeignKey(nameof(ClientId))]
        public required Client Client { get; set; }
    }
}
