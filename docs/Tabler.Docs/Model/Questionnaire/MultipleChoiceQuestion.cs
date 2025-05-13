using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabler.Docs.Model.Questionnaire
{
    public class MultipleChoiceQuestion : QuestionBase
    {
        public List<AnswerOption> Options { get; set; } = new();
    }
}
