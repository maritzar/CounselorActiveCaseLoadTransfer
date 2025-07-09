using System;
using System.Collections.Generic;


namespace Counselor_Active_CaseLoad_Transfer.Models
{
    public class CounselorUpdateModel
    {
        public Guid CounselorIn { get; set; }
        public Guid CounselorOut { get; set; }
        public List<string> ProgramTypes { get; set; } = new();
      
        public List<int> LanguageId { get; set; } = new();
        public bool AllProgramsSelected { get; set; } = false;
        public bool AllLanguagesSelected { get; set; } = false;
        public string ProgramSummary => AllProgramsSelected ? "All Programs" : string.Join(", ", ProgramTypes);
        public string LanguageSummary => AllLanguagesSelected ? "All Languages" : string.Join(", ", LanguageId);
    }
}


    