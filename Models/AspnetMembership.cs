using System.ComponentModel.DataAnnotations;

namespace Counselor_Active_CaseLoad_Transfer.Models
{
    public class AspnetMembership
    {
        [Key]
        public Guid UserId { get; set; }
        public required string Password { get; set; }
        public Guid ApplicationId { get; set; }
        public bool IsApproved { get; set; }
    }
}
