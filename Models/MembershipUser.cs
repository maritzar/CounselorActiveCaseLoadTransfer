using System.ComponentModel.DataAnnotations;

namespace Counselor_Active_CaseLoad_Transfer.Models
{
    public class MembershipUser
    {
        [Key]
        public Guid UserId { get; set; }
        public required string Password { get; set; }
        public string? CounselorName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
