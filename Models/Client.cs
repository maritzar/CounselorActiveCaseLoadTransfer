using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Counselor_Active_CaseLoad_Transfer.Models
{
    public class Client
    {
        [Key]
        [Column("client_id")]
        public int ClientId { get; set; }

        [Column("language_id")]
        public int LanguageId { get; set; }

        [ForeignKey(nameof(LanguageId))]
        public  ClientLanguage? Language { get; set; }
    }
}
