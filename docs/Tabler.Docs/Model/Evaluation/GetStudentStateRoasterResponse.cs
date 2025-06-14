using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabler.Docs.Model.Evaluation
{
    public class GetStudentStateRoasterResponse
    {
        public string skill_name { get; set; }
        public string state { get; set; }
        public float correct_prob { get; set; }
        public float state_prob { get; set; }
    }

}
