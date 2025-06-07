using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabler.Docs.Model.Dataset
{
    public class StudentSkill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Learn { get; set; } // 1 to 5
        public StudentSubject StudentSubject { get; set; }
    }
}
