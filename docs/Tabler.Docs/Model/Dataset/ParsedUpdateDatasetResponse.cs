using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabler.Docs.Model.Dataset
{
    public class ParsedUpdateDatasetResponse
    {
        public List<StudentSubject> StudentSubjects { get; set; }
        public List<SubjectSkill> SubjectSkills { get; set; }
    }
}
