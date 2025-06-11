using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tabler.Docs.Model.Evaluation;
using Tabler.Docs.Model.Questionnaire;

namespace Tabler.Docs.Data.QuestionnaireService
{
    public interface IQuestionnaireService
    {
        Task<List<QuestionBase>> RequestQuestionsToAi(string topic, string difficulty, int numQuestions);
        Task<List<QuestionBase>> GetQuestionByIdsAsync(int[] id);
        Task<StartRealTimeEvaluationResponse> StartRealTimeEvaluation(int userId, string[] skillNames);
    }
}
