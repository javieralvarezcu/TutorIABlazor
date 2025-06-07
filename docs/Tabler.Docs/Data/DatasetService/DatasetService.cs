using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tabler.Docs.Data.AuthService;
using Tabler.Docs.Model.Auth;
using Tabler.Docs.Model.Dataset;
using static System.Net.WebRequestMethods;
using Tabler.Docs.Model.Evaluation;
using Tabler.Docs.Migrations;

namespace Tabler.Docs.Data.DatasetService
{
    public class DatasetService : IDatasetService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly HttpClient _http;
        public DatasetService(ApplicationDbContext dbContext, IHttpClientFactory httpClientFactory)
        {
            _dbContext = dbContext;
            _http = httpClientFactory.CreateClient("InternalApiClient");
        }

        public async Task<CheckDatasetResponseBody> CheckDataset()
        {
            var response = await _http.PostAsync("/evaluation/check_students_dataset", null);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<CheckDatasetResponseBody>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (result == null)
            {
                throw new Exception("Failed to deserialize response from CheckDataset");
            }

            // Procesar manualmente el campo `data`
            if (result.data.ValueKind == JsonValueKind.Array)
            {
                result.ParsedData = result.data
                    .EnumerateArray()
                    .Select(element => JsonSerializer.Deserialize<Datum>(element.GetRawText()))
                    .Where(x => x != null)
                    .ToList()!;
            }
            else
            {
                result.ParsedData = new List<Datum>();
            }

            return result;
        }


        public async Task<ParsedUpdateDatasetResponse> UpdateDataset(UpdateDatasetRequestBody updateDatasetRequestBody)
        {
            var content = new StringContent(
            JsonSerializer.Serialize(updateDatasetRequestBody),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _http.PostAsync("/evaluation/update_dataset", content);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<UpdateDatasetResponseBody>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (result == null)
            {
                throw new Exception("Failed to deserialize response from UpdateDataset");
            }

            var parsed = ParseUpdateDatasetResponse(result);

            return parsed!;
        }

        internal ParsedUpdateDatasetResponse ParseUpdateDatasetResponse(UpdateDatasetResponseBody response)
        {
            var parsed = new ParsedUpdateDatasetResponse
            {
                StudentSubject = new StudentSubject
                {
                    Name = response.Property1.First().students_states.First().id,
                    Skills = response.Property1.First().students_states
                        .SelectMany(s => s.student_subject_list)
                        .SelectMany(sub => sub.student_skill_list.Select(skill => new StudentSkill
                        {
                            Name = skill.name,
                            Learn = skill.learn
                        }))
                        .ToList()
                },
                SubjectSkills = response.Property1.First().skills_states
                    .Select(skillState => new SubjectSkill
                    {
                        Name = skillState.skill_name,
                        Subjects = skillState.subject_skill_list.Select(subject => new Subject
                        {
                            Name = subject.subject_skill_name
                        }).ToList()
                    })
                    .ToList()
            };

            // Relacionar StudentSkill con su StudentSubject
            foreach (var skill in parsed.StudentSubject.Skills)
            {
                skill.StudentSubject = parsed.StudentSubject;
            }

            return parsed;
        }
    }
}
