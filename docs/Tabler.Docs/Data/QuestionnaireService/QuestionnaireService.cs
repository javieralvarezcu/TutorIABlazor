using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tabler.Docs.Model.Questionnaire;

namespace Tabler.Docs.Data.QuestionnaireService
{
    public class QuestionnaireService : IQuestionnaireService
    {
        private readonly ApplicationDbContext _dbContext;
        public QuestionnaireService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task AddQuestionAsync(QuestionBase question)
        {
            throw new NotImplementedException();
        }

        public Task DeleteQuestionAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<QuestionBase>> GetQuestionByIdsAsync(int[] ids)
        {
            var questions = await _dbContext.QuestionBases
        .Where(q => ids.Contains(q.Id))
        .ToListAsync();

            // Cargar manualmente las opciones solo para las preguntas MultipleChoice
            var multipleChoiceQuestions = questions
                .OfType<MultipleChoiceQuestion>()
                .ToList();

            await _dbContext.Entry(multipleChoiceQuestions[0])
                .Collection(q => q.Options)
                .LoadAsync();

            foreach (var mcq in multipleChoiceQuestions)
            {
                await _dbContext.Entry(mcq)
                    .Collection(q => q.Options)
                    .LoadAsync();
            }

            return questions;
        }

        public Task<List<QuestionBase>> GetQuestionsAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateQuestionAsync(QuestionBase question)
        {
            throw new NotImplementedException();
        }
    }
}
