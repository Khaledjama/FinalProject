using Newtonsoft.Json;
using Schools.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;



namespace Tttt.Services
{
    public class SubjectDataService : ISubjectDataService
    {

        private readonly HttpClient _httpClient;
        public SubjectDataService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }


        public async Task<IEnumerable<SubjectDto>> GetAll()
        {
            var json = await _httpClient.GetStringAsync($"api/Subjects/GetAll");
            return JsonConvert.DeserializeObject<IEnumerable<SubjectDto>>(json);
        }

        public async Task<SubjectDto> Get(string SubjectId)
        {
            var json = await _httpClient.GetStringAsync($"api/Subjects/Get/{SubjectId}");
            return JsonConvert.DeserializeObject<SubjectDto>(json);
        }

        public async Task<HttpResponseMessage> Add(SubjectDto Subject)
        {

            return await _httpClient.PostAsync($"api/Subjects/Add", getStringContentFromObject(Subject));
        }


        public async Task<HttpResponseMessage> Update(string CodedId, SubjectDto Subject)
        {
            return await _httpClient.PutAsync($"api/Subjects/Update/{CodedId}", getStringContentFromObject(Subject));
        }

        public async Task<HttpResponseMessage> Delete(string SubjectId)
        {
            var client = new HttpClient();
            return await _httpClient.DeleteAsync($"api/Subjects/Delete/{SubjectId}");
        }

        private StringContent getStringContentFromObject(object obj)
        {
            var serialized = JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");
            return stringContent;
        }
    }
}
