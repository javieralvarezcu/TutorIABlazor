using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tabler.Docs.Model.Questionnaire;

namespace Tabler.Docs.Data.QuestionnaireService
{
    public interface IQuestionnaireService
    {
        Task<List<QuestionBase>> GetQuestionsAsync();
        Task<List<QuestionBase>> GetQuestionByIdsAsync(int[] id);
        Task AddQuestionAsync(QuestionBase question);
        Task UpdateQuestionAsync(QuestionBase question);
        Task DeleteQuestionAsync(int id);
    }
}
