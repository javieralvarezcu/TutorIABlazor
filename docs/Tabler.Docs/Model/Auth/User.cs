using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tabler.Docs.Model.Dataset;

namespace Tabler.Docs.Model.Auth
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<StudentSubject> Subjects { get; set; }
    }
}
