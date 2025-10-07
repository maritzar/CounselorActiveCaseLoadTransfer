// File: Controllers/CaseProgramController.cs
using Counselor_Active_CaseLoad_Transfer.Data;
using Counselor_Active_CaseLoad_Transfer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Counselor_Active_CaseLoad_Transfer.Controllers
{
    public class CaseProgramController : Controller
    {
        private readonly AdvocateDbContext _context;
        private readonly AdvocateUsersDbContext _contextUsers;

        public CaseProgramController(AdvocateDbContext context, AdvocateUsersDbContext contextUsers)
        {
            _context = context;
            _contextUsers = contextUsers;
        }

        [HttpGet]
        public IActionResult UpdateForm()
        {
            var counselors = (from m in _contextUsers.AspnetMemberships
                              join v in _contextUsers.VwProfileProperties on m.UserId equals v.UserId
                              where m.ApplicationId == Guid.Parse("C7F6470F-7773-4167-802A-E1727BDA5D95") && m.IsApproved
                              orderby v.FirstName + v.LastName
                              select new SelectListItem
                              {
                                  Value = m.UserId.ToString(),
                                  Text = (v.FirstName + " " + v.LastName).ToUpper()
                              }).ToList();

            var programTypes = _context.ProgramTypes
                .Where(p => !string.IsNullOrEmpty(p.Code))
                .OrderBy(p => p.Code)
                .Select(p => new SelectListItem { Value = p.Code, Text = p.Description ?? p.Code })
                .ToList();

            var languages = _context.ClientLanguages
                .OrderBy(l => l.LanguageName)
                .Select(l => new SelectListItem { Value = l.LanguageId.ToString(), Text = l.LanguageName })
                .ToList();

            ViewBag.Counselors = counselors;
            ViewBag.ProgramTypes = programTypes;
            ViewBag.Languages = languages;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ReplaceCounselor(CounselorUpdateModel request)
        {
            if (!ModelState.IsValid)
                return View("UpdateForm", request);

            var programCodeMap = _context.ProgramTypes
                .Where(p => !string.IsNullOrEmpty(p.Code))
                .ToDictionary(p => p.ProgramId.ToString(), p => p.Code);

            var allPrograms = request.ProgramTypes.Count == programCodeMap.Count;
            var allLanguages = request.LanguageId.Count == _context.ClientLanguages.Count();

            request.AllProgramsSelected = allPrograms;
            request.AllLanguagesSelected = allLanguages;

            var programFilter = new HashSet<string>(request.ProgramTypes);
            var languageFilter = new HashSet<int>(request.LanguageId);

            var matchingIds = await (from cp in _context.CasePrograms
                                     join cps in _context.CaseProgramStatuses on cp.CaseProgramId equals cps.CaseProgramId
                                     join cpst in _context.CaseProgramStatusTypes on cps.CaseProgramStatusTypeId equals cpst.CaseProgramStatusTypeId
                                     join p in _context.ProgramTypes on cp.ProgramId equals p.ProgramId
                                     join c in _context.Cases on cp.CaseId equals c.CaseId
                                     join cl in _context.Clients on c.ClientId equals cl.ClientId
                                     where cp.CounselorId == request.CounselorIn
                                           && !new[] { "ST", "RVKD", "CLSD", "RVKCT", "STIC", "ACT", "FTC", "TRTFD" }.Contains(cpst.Code)
                                           //&& !string.IsNullOrEmpty(p.Code)
                                           //&& (allPrograms || programFilter.Contains(p.Code))
                                           //&& (allLanguages || languageFilter.Contains(cl.LanguageId))
                                     select cp.CaseProgramId).Distinct().ToListAsync();

            var toUpdate = await _context.CasePrograms
                .Where(cp => matchingIds.Contains(cp.CaseProgramId))
                .ToListAsync();

            toUpdate.ForEach(cp => cp.CounselorId = request.CounselorOut);
            await _context.SaveChangesAsync();

            var counselorNames = await _contextUsers.VwProfileProperties
                .AsNoTracking()
                .Where(x => x.UserId == request.CounselorIn || x.UserId == request.CounselorOut)
                .ToDictionaryAsync(x => x.UserId, x => (x.FirstName + " " + x.LastName).ToUpper());

            ViewBag.CounselorInName = counselorNames.GetValueOrDefault(request.CounselorIn, request.CounselorIn.ToString());
            ViewBag.CounselorOutName = counselorNames.GetValueOrDefault(request.CounselorOut, request.CounselorOut.ToString());
            ViewBag.ProgramSummary = allPrograms ? "All Programs" : string.Join(", ", request.ProgramTypes);
            ViewBag.LanguageSummary = allLanguages ? "All Languages" : string.Join(", ", request.LanguageId);
            ViewBag.Message = $"Updated {toUpdate.Count} records.";

            return View("UpdateForm");
        }
    }
}
