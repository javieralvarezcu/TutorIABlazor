using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabler.Docs.Model.Dataset
{
    public class SubjectSkillDetail
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // Esta es la propiedad que faltaba
        public int SubjectSkillId { get; set; }
        public SubjectSkill SubjectSkill { get; set; } = default!;
        public List<SkillState> States { get; set; } = new();
    }

}
