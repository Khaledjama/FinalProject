using Schools.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Tttt.Services
{
    public class ExamTypeSerVice : IExamTypeService
    {
        private readonly HttpClient _httpClient;

        public ExamTypeSerVice(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<IEnumerable<ExamTypeDto>> GetAllExamTypes()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<ExamTypeDto>>
                (await _httpClient.GetStreamAsync("api/ExamTypes/GetAll"), new JsonSerializerOptions
                { PropertyNameCaseInsensitive = true });
        }

        public async Task<ExamTypeDto> AddExamType(ExamTypeDto ExamType)
        {
            var ExamTypeObjSer = new StringContent(JsonSerializer.Serialize(ExamType),
                Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/ExamTypes/Add/", ExamTypeObjSer);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<ExamTypeDto>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public async Task<ExamTypeDto> GetExamTypeByID(int ExamTypeId)
        {
            return await JsonSerializer.DeserializeAsync<ExamTypeDto>
                (await _httpClient.GetStreamAsync("api/ExamTypes/Get/" + ExamTypeId), new JsonSerializerOptions()
                { PropertyNameCaseInsensitive = true });
        }

        public async Task<ExamTypeDto> GetExamTypeDetails(int ExamTypeId)
        {
            return await JsonSerializer.DeserializeAsync<ExamTypeDto>
                (await _httpClient.GetStreamAsync("api/ExamTypes/Get/" + ExamTypeId), new JsonSerializerOptions()
                { PropertyNameCaseInsensitive = true });
        }

        public async Task UpdateExamType(int? ExamTypeId, ExamTypeDto ExamType)
        {
            var SubjectObjSer = new StringContent(JsonSerializer.Serialize(ExamType),
               Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync("api/ExamTypes/Update/"+ExamTypeId, SubjectObjSer);

            if (response.IsSuccessStatusCode)
            {
                 await JsonSerializer.DeserializeAsync<SubjectDto>(await response.Content.ReadAsStreamAsync());
            }

        }

        public async Task DeleteExamType(int? ExamTypeId)
        {
            await _httpClient.DeleteAsync("api/ExamTypes/Delete/" + ExamTypeId);
        }
    }
}
