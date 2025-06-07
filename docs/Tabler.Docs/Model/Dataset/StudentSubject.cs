using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tabler.Docs.Model.Auth;

namespace Tabler.Docs.Model.Dataset
{
    public class StudentSubject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public User User { get; set; }
        public List<StudentSkill> Skills { get; set; }
    }
}
