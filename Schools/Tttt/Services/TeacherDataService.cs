using Newtonsoft.Json;
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
    public class TeacherDataService : ITeacherDataService
    {

        private readonly HttpClient _httpClient;
        public TeacherDataService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }


        public async Task<IEnumerable<TeacherDto>> GetAll()
        {
            var json = await _httpClient.GetStringAsync($"api/Teachers/GetAll");
            return JsonConvert.DeserializeObject<IEnumerable<TeacherDto>>(json);
        }

        public async Task<TeacherDto> Get(long SSN)
        {
            var json = await _httpClient.GetStringAsync($"api/Teachers/Get/{SSN}");
            return JsonConvert.DeserializeObject<TeacherDto>(json);
        }

        public async Task<HttpResponseMessage> Add(TeacherDto Subject)
        {

            return await _httpClient.PostAsync($"api/Teachers/Add", getStringContentFromObject(Subject));
        }


        public async Task<HttpResponseMessage> Update(long SSN, TeacherDto teacherDto)
        {
            return await _httpClient.PutAsync($"api/Teachers/Update/{SSN}", getStringContentFromObject(teacherDto));
        }

        public async Task<HttpResponseMessage> Delete(long SSN)
        {
            return await _httpClient.DeleteAsync($"api/Teachers/Delete/{SSN}");
        }

        private StringContent getStringContentFromObject(object obj)
        {
            var serialized = JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");
            return stringContent;
        }
    }
}
