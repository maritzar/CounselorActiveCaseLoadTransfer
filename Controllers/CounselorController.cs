using Counselor_Active_CaseLoad_Transfer.Data;
using Counselor_Active_CaseLoad_Transfer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Counselor_Active_CaseLoad_Transfer.Controllers
{
    public class CounselorController : Controller
    {
        private readonly AdvocateUsersDbContext _context;

        public CounselorController(AdvocateUsersDbContext context)
        {
            _context = context;
        }

        public IActionResult List()
        {
            var result = (from m in _context.AspnetMemberships
                          join v in _context.VwProfileProperties on m.UserId equals v.UserId
                          where m.ApplicationId == Guid.Parse("C7F6470F-7773-4167-802A-E1727BDA5D95")
                                && m.IsApproved
                          orderby (v.FirstName.ToUpper() + " " + v.LastName.ToUpper())
                          select new MembershipUser
                          {
                              UserId = m.UserId,
                              Password = m.Password,
                              CounselorName = v.FirstName.ToUpper() + " " + v.LastName.ToUpper(),
                              FirstName = v.FirstName.ToUpper(),
                              LastName = v.LastName.ToUpper()
                          }).ToList();

            return View(result);
        }
    }
}

