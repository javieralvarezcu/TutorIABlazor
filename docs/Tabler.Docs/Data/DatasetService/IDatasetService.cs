using System.Collections.Generic;
using System.Threading.Tasks;
using Tabler.Docs.Model.Auth;
using Tabler.Docs.Model.Dataset;

namespace Tabler.Docs.Data.DatasetService
{
    public interface IDatasetService
    {
        Task<ParsedUpdateDatasetResponse> UpdateDataset(UpdateDatasetRequestBody updateDatasetRequestBody);
        Task<ParsedUpdateDatasetResponse> CheckDataset();
        Task<CheckStudentDatasetResponseBody> CheckStudentDataset();
        Task<List<StudentSkill>> GetStudentSkillByUserIdAsync(int userId);
    }
}
