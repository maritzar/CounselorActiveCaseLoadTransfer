using System;
using System.ComponentModel.DataAnnotations;


namespace Counselor_Active_CaseLoad_Transfer.Models
{
    public class AspNetProfile
    {
        [Key]
        public Guid UserId { get; set; }

        public string? PropertyNames { get; set; }

        public string? PropertyValuesString { get; set; }


    }
}
