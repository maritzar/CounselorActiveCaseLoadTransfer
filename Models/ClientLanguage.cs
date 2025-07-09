using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Counselor_Active_CaseLoad_Transfer.Models
{
    public class ClientLanguage
    {
        [Key]
        [Column("language_id")]
        public int LanguageId { get; set; }
      
        [Column("description")]
        public required string LanguageName { get; set; }

        
       
    }
}
