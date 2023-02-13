using Schools.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tttt.Services
{
    public interface ISubjectDataService
    {
        Task<IEnumerable<SubjectDto>> GetAll();
        Task<HttpResponseMessage> Add(SubjectDto Subject);
        Task<HttpResponseMessage> Update(string CodedId, SubjectDto Subject);
        Task<HttpResponseMessage> Delete(string SubjectId);
        Task<SubjectDto> Get(string SubjectId);
    }
}
