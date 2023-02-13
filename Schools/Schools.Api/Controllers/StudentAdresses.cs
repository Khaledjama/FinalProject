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
    public class StudentAdresses : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _Map;
        public StudentAdresses(IUnitOfWork unit, IMapper map)
        {
            this._unitOfWork = unit;
            this._Map = map;
        }
        // GET: api/<StudentAdresses>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var AllAdresses = await _unitOfWork.StudentAdress.GetAllAsync();
            var Data = _Map.Map<IEnumerable<StudentAdress>, IEnumerable<StudentAdressDto>>(AllAdresses);
            return Ok(Data);
        }

        // GET api/<StudentAdresses>/5
        [HttpGet("{SSN}")]
        public async Task<IActionResult> Get(long? SSN)
        {
            if (SSN is null)
                return BadRequest("Invalid SSN number");
            var CurrentStudentAdress = await _unitOfWork.StudentAdress.GetByIdAsync(SSN);
            if (CurrentStudentAdress is null)
                return BadRequest("This Student Adress is Not Found");
            var Data = _Map.Map<StudentAdressDto>(CurrentStudentAdress);
            return Ok(Data);
        }


        // POST api/<StudentAdresses>
        [HttpPost]
        public async Task<IActionResult> Add(StudentAdressDto studentAdressesDto)
        {
            var CurrentStudent = await _unitOfWork.Student.GetByIdAsync(studentAdressesDto.StudentSSN);
            var CurrentStudentTeacher = await _unitOfWork.StudentAdress.GetByIdAsync(studentAdressesDto.StudentSSN);
            if (studentAdressesDto.StudentSSN is null || CurrentStudent is null)
                return BadRequest("Invalid SSN Number");
            if (CurrentStudentTeacher is not null)
                return BadRequest("This Adress of This SSN is Already Existed !");
            if (!ModelState.IsValid)
            {
                return BadRequest("Please Compelete Form");
            }
            else
            {
                try
                {
                    var data = _Map.Map<StudentAdress>(studentAdressesDto);
                    await _unitOfWork.StudentAdress.Insert(data);
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
        public async Task<IActionResult> Update(long SSN, StudentAdressDto studentAdressesDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Please Complete Form ");
            var StudentAdress = await _unitOfWork.StudentAdress.GetByIdAsync(SSN);
            if(StudentAdress is null)
            {
                return BadRequest("SSN is Not Valid");
            }
            StudentAdress = _Map.Map<StudentAdressDto,StudentAdress>(studentAdressesDto,StudentAdress);
            StudentAdress.StudentSSN = SSN;
            _unitOfWork.StudentAdress.Updating(SSN, StudentAdress);
            return _unitOfWork.Complete() > 0 ? Ok("Update Successfully") : BadRequest("Update Failed ");
        }

        // DELETE api/<StudentAdresses>/5
        [HttpDelete("SSN")]
        public async Task<IActionResult>  Delete(long? SSN)
        {
            if (SSN is null)
                return BadRequest("Invalid SSN Number !");
            var CurrentStudentAdress = await _unitOfWork.StudentAdress.GetByIdAsync(SSN);
            if (CurrentStudentAdress is null)
                return BadRequest("This Adress Not Found !");
            _unitOfWork.StudentAdress.Delete(SSN);
            return _unitOfWork.Complete() > 0 ? Ok("Deleted Succefully") : BadRequest("Deleted Failed");
        }
    }
}
