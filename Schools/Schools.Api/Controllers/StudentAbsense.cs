using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Schools.DAL.UnitOfWork;
using Schools.DataStorage.Entity;
using Schools.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Schools.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentAbsense : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _Map;
        public StudentAbsense(IUnitOfWork unit, IMapper map)
        {
            this._unitOfWork = unit;
            this._Map = map;
        }
        // GET: api/<StudentAbsense>
        [HttpGet]
        public async Task<IActionResult> GetStudentAbsence()
        {
            var CurrentStudentAbsence = await _unitOfWork.StudentAbsence.GetAllAsync();
            if (CurrentStudentAbsence is null)
                return BadRequest("Invalid Student");
            var Data = _Map.Map<IEnumerable<Studentabsence>, IEnumerable<StudentAbsenceDto>>(CurrentStudentAbsence);
            return Ok(Data);
        }
        [HttpGet("{SSN}")]
        public async Task<IActionResult> GetStudentAbsence(long? SSN)
        {
            if (SSN is null)
                return BadRequest("Invalid Student");
            var CurrentStudentAbsence = await _unitOfWork.StudentAbsence.FindAsync((s => s.StudentSSN == SSN));
            if (CurrentStudentAbsence is null)
                return BadRequest("Invalid Student");
            var Data = _Map.Map<IEnumerable<Studentabsence>, IEnumerable<StudentAbsenceDto>>(CurrentStudentAbsence);
            return Ok(Data);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStudentAbsenceinThisDay()
        {
            var StudentAbsence = await _unitOfWork.StudentAbsence.FindAsync((s => s.Date.Month == DateTime.Now.Month && s.Date.Day == DateTime.Now.Day));
            var Data = _Map.Map<IEnumerable<Studentabsence>, IEnumerable<StudentAbsenceDto>>(StudentAbsence);
            return Ok(Data);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStudentAbsenceinDay(DateTime Date)
        {
            var StudentAbsence = await _unitOfWork.StudentAbsence.FindAsync((s => s.Date.Month == Date.Month && s.Date.Day == Date.Day));
            var Data = _Map.Map<IEnumerable<Studentabsence>, IEnumerable<StudentAbsenceDto>>(StudentAbsence);
            return Ok(Data);
        }
        [HttpGet]
        public async Task<IActionResult> GetStudentAbsenseMoreThan10Days()
        {
            TotalStudentAbsenceDto totalStudentAbsenceDto;
            List<TotalStudentAbsenceDto> totalStudentAbsenceDtoList = new List<TotalStudentAbsenceDto>();
            var StudentAbsence = await _unitOfWork.StudentAbsence.GetAllAsync();
            var StudentsSSN = StudentAbsence.Select(s => s.StudentSSN).Distinct();
            foreach (var ssn in StudentsSSN)
            {
                var StudentAbsenceCount = StudentAbsence.Where(s => s.StudentSSN == ssn).Count();
                if (StudentAbsenceCount >= 10)
                {
                    totalStudentAbsenceDto = new TotalStudentAbsenceDto { StudentSSN = ssn, TotalAbsenceDay = StudentAbsenceCount };
                    totalStudentAbsenceDtoList.Add(totalStudentAbsenceDto);
                }
            }
            return Ok(totalStudentAbsenceDtoList);

        }
        // GET api/<StudentAbsense>/5
        [HttpGet]
        public async Task<IActionResult> GetAllStudentAbsenceinThisMonth()
        {
            var StudentAbsence = await _unitOfWork.StudentAbsence.FindAsync((s => s.Date.Month == DateTime.Now.Month));
            var Data = _Map.Map<IEnumerable<Studentabsence>, IEnumerable<StudentAbsenceDto>>(StudentAbsence);
            return Ok(Data);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStudentAbsenceinMonth(int? Month)
        {
            if (Month is null)
                return BadRequest("Invalid Month");
            if (Month > 12 || Month <= 0)
                return BadRequest("Invalid Month");
            var StudentAbsence = await _unitOfWork.StudentAbsence.FindAsync((s => s.Date.Month == Month));
            var Data = _Map.Map<IEnumerable<Studentabsence>, IEnumerable<StudentAbsenceDto>>(StudentAbsence);
            return Ok(Data);
        }
        [HttpGet("{FirstName}")]
        public async Task<IActionResult> GetStudentAbsenceByName(string FirstName, string MiddleName, string LastName)
        {

            var StudentAbsence = await _unitOfWork.StudentAbsence.FindAsync((s => s.Student.FirstName.ToLower().Contains(FirstName.ToLower())));
            var Data = _Map.Map<IEnumerable<Studentabsence>, IEnumerable<StudentAbsenceDto>>(StudentAbsence);
            return Ok(Data);
        }

        [HttpGet("{SchoolsYearId}")]
        public async Task<IActionResult> GetStudentAbsenceBySchoolsYear(int? SchoolsYearId)
        {
            if (SchoolsYearId is null)
            {
                return BadRequest("SchoolsYearId is not Valid");
            }
            var StudentAbsence = await _unitOfWork.StudentAbsence.FindAsync((s => s.Student.SchoolsYearId == SchoolsYearId));
            if (StudentAbsence is null)
                return BadRequest("Invalid !!");
            var Data = _Map.Map<IEnumerable<Studentabsence>, IEnumerable<StudentAbsenceDto>>(StudentAbsence);
            return Ok(Data);
        }

        [HttpGet("{SchoolsYearId}/{ClassRoomId}")]
        public async Task<IActionResult> GetStudentAbsenceByClassRoom(int? SchoolsYearId, int? ClassRoomId)
        {
            if (SchoolsYearId is null || ClassRoomId is null)
            {
                return BadRequest("SchoolsYearId is not Valid");
            }
            var StudentAbsence = await _unitOfWork.StudentAbsence.FindAsync((s => s.Student.SchoolsYearId == SchoolsYearId && s.Student.ClassRoomId==ClassRoomId));
            if (StudentAbsence is null)
                return BadRequest("Invalid !!");
            var Data = _Map.Map<IEnumerable<Studentabsence>, IEnumerable<StudentAbsenceDto>>(StudentAbsence);
            return Ok(Data);
        }

        [HttpPost]
        public async Task<IActionResult> Add(long? SSN)
        {

            if (SSN is null)
                return BadRequest("Invalid Teacher");
            var CurrentStudent = await _unitOfWork.Student.GetByIdAsync(SSN);
            if (CurrentStudent is null)
                return BadRequest("Invalid Teacher");
            var StudentAbsence = await _unitOfWork.StudentAbsence.
                FindAsync(s => s.StudentSSN == SSN
            && s.Date.Date == DateTime.Now.Date);
            if (StudentAbsence.Count() == 0)
            {

                StudentAbsenceDto studentAbsenseDto = new StudentAbsenceDto { Date = DateTime.Now, StudentSSN = SSN };
                var Data = _Map.Map<Studentabsence>(studentAbsenseDto);
                await _unitOfWork.StudentAbsence.Insert(Data);
                return _unitOfWork.Complete() > 0 ? Ok("Adding Absence Done") : BadRequest("Adding Absence Failed !");
            }
            return BadRequest("Adding Absence Failed !");
           
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id is null)
                return BadRequest("Invalid Student");
            var CurrentStudentAbsenceRecord = await _unitOfWork.StudentAbsence.GetByIdAsync(Id);
            if (CurrentStudentAbsenceRecord is null)
                return BadRequest("Invalid Student");
             _unitOfWork.StudentAbsence.Delete(Id);
            return _unitOfWork.Complete() > 0 ? Ok("Delete Absence Done") : BadRequest("Delete Absence Failed !");
        }
       
    }
}
