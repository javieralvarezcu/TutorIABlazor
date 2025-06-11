using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Tabler.Docs.Model.Dataset
{
    //public class StudentStateRoasterResponseBody
    //{
    //    [JsonExtensionData]
    //    public StudentSkillState[] Property1 { get; set; }
    //}

    public class StudentStateRoasterResponseBody
    {
        public string skill_name { get; set; }
        public string state { get; set; }
        public float correct_prob { get; set; }
        public float state_prob { get; set; }
    }

}
