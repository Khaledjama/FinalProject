using Schools.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tttt.Services
{
    public interface ITeacherDataService
    {
        Task<IEnumerable<TeacherDto>> GetAll();
        Task<HttpResponseMessage> Add(TeacherDto teacherDto );
        Task<HttpResponseMessage> Update(long SSN, TeacherDto teacherDto);
        Task<HttpResponseMessage> Delete(long SSN );
        Task<TeacherDto> Get(long SSN);
    }
}
