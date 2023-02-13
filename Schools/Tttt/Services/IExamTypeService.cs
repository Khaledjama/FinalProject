using Schools.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tttt.Services
{
    public interface IExamTypeService
    {
        Task<IEnumerable<ExamTypeDto>> GetAllExamTypes();
        Task<ExamTypeDto> GetExamTypeDetails(int ExamTypeId);
        Task<ExamTypeDto> AddExamType(ExamTypeDto ExamType);
        Task UpdateExamType(int? ExamTypeId, ExamTypeDto ExamType);
        Task DeleteExamType(int? ExamTypeId);
        Task<ExamTypeDto> GetExamTypeByID(int ExamTypeId);
    }
}
