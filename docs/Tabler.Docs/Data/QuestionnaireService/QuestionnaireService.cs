using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tabler.Docs.Model.Evaluation;
using Tabler.Docs.Model.Questionnaire;

namespace Tabler.Docs.Data.QuestionnaireService
{
    public class QuestionnaireService : IQuestionnaireService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly HttpClient _http;
        public QuestionnaireService(ApplicationDbContext dbContext, IHttpClientFactory httpClientFactory)
        {
            _dbContext = dbContext;
            _http = httpClientFactory.CreateClient("InternalApiClient");
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

        public async Task<StartRealTimeEvaluationResponse> StartRealTimeEvaluation(int userId, string[] skillNames)
        {
            var payload = new
            {
                user_id = userId.ToString(),
                skill_names = skillNames
            };

            var content = new StringContent(
                JsonSerializer.Serialize(payload),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _http.PostAsync("/evaluation/start_real_time_evaluation", content);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<StartRealTimeEvaluationResponse>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return result!;
        }
    }
}
