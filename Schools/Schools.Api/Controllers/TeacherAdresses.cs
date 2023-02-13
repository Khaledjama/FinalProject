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
    public class TeacherAdresses : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _Map;
        public TeacherAdresses(IUnitOfWork unit, IMapper map)
        {
            this._unitOfWork = unit;
            this._Map = map;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var AllAdresses = await _unitOfWork.TeacherAdress.GetAllAsync();
            var Data = _Map.Map<IEnumerable<TeacherAdress>, IEnumerable<TeacherAdressDto>>(AllAdresses);
            return Ok(Data);
        }

        // GET api/<StudentAdresses>/5
        [HttpGet("{SSN}")]
        public async Task<IActionResult> Get(long? SSN)
        {
            if (SSN is null)
                return BadRequest("Invalid SSN number");
            var CurrentStudentAdress = await _unitOfWork.TeacherAdress.GetByIdAsync(SSN);
            if (CurrentStudentAdress is null)
                return BadRequest("This Student Adress is Not Found");
            var Data = _Map.Map<TeacherAdressDto>(CurrentStudentAdress);
            return Ok(Data);
        }


        // POST api/<StudentAdresses>
        [HttpPost]
        public async Task<IActionResult> Add(TeacherAdressDto teacherAdressDto)
        {
            var CurrentTeacher = await _unitOfWork.Teacher.GetByIdAsync(teacherAdressDto.TeacherSSN);
            var CurrentTeacherAdress = await _unitOfWork.TeacherAdress.GetByIdAsync(teacherAdressDto.TeacherSSN);
            if (teacherAdressDto.TeacherSSN is null || CurrentTeacher is null)
                return BadRequest("Invalid SSN Number");
            if (CurrentTeacherAdress is not null)
                return BadRequest("This Adress of This SSN is Already Existed !");
            if (!ModelState.IsValid)
            {
                return BadRequest("Please Compelete Form");
            }
            else
            {
                try
                {
                    var data = _Map.Map<TeacherAdress>(teacherAdressDto);
                    await _unitOfWork.TeacherAdress.Insert(data);
                    if (await _unitOfWork.CompleteAsync() > 0)
                    {
                        return Ok("Adding Student Adress Successfully");
                    }
                    else
                    {
                        return BadRequest("Error Please Try Again");
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest($"Adding Teacher Adress Failed !!{ex.Message}");
                }
            }
        }


        // PUT api/<StudentAdresses>/5
        [HttpPut("{SSN}")]
        public async Task<IActionResult> Update(long SSN, TeacherAdressDto teacherAdressDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Please Complete Form ");
            var TeacherAdress = await _unitOfWork.TeacherAdress.GetByIdAsync(SSN);
            if (TeacherAdress is null)
            {
                return BadRequest("SSN is Not Valid");
            }
            TeacherAdress = _Map.Map<TeacherAdressDto, TeacherAdress>(teacherAdressDto, TeacherAdress);
            TeacherAdress.TeacherSSN = SSN;
            _unitOfWork.TeacherAdress.Updating(SSN, TeacherAdress);
            return _unitOfWork.Complete() > 0 ? Ok("Update Successfully") : BadRequest("Update Failed ");
        }

        // DELETE api/<StudentAdresses>/5
        [HttpDelete("{SSN}")]
        public async Task<IActionResult> Delete(long? SSN)
        {
            if (SSN is null)
                return BadRequest("Invalid SSN Number !");
            var CurrentTeacherAdress = await _unitOfWork.TeacherAdress.GetByIdAsync(SSN);
            if (CurrentTeacherAdress is null)
                return BadRequest("This Adress Not Found !");
            _unitOfWork.TeacherAdress.Delete(SSN);
            return _unitOfWork.Complete() > 0 ? Ok("Deleted Succefully") : BadRequest("Deleted Failed");
        }
    }
}
