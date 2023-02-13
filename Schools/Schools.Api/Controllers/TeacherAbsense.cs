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
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherAbsense : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _Map;
        public TeacherAbsense(IUnitOfWork unit, IMapper map)
        {
            this._unitOfWork = unit;
            this._Map = map;
        }
        [HttpPost]
        public async Task<IActionResult> Add(long? SSN)
        {


            if (SSN is null)
                return BadRequest("Invalid Teacher");
            var CurrentStudent = await _unitOfWork.Teacher.GetByIdAsync(SSN);
            if (CurrentStudent is null)
                return BadRequest("Invalid Teacher");
            var TeacherAbsence = await _unitOfWork.TeacherAbsence.
                FindAsync(s => s.TeacherSSN == SSN
            && s.Date.Date == DateTime.Now.Date);
            if(TeacherAbsence.Count() ==0)
            {

                TeacherAbsenceDto teacherAbsenseDto = new TeacherAbsenceDto { Date = DateTime.Now, TeacherSSN = SSN };
                var Data = _Map.Map<Teacherabsence>(teacherAbsenseDto);
                await _unitOfWork.TeacherAbsence.Insert(Data);
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
