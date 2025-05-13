using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabler.Docs.Model.Questionnaire
{
    public class AnswerOption
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public bool IsSelected { get; set; }

        public int QuestionId { get; set; }
        public MultipleChoiceQuestion Question { get; set; } = default!;
    }
}
