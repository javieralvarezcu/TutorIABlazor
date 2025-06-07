using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabler.Docs.Model.Dataset
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SubjectSkill Skill { get; set; }
    }
}
