using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Schools.Api.Sevice.UploadImages;
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
    public class Students : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _Map;
        public Students(IUnitOfWork unit, IMapper map)
        {
            this._unitOfWork = unit;
            this._Map = map;
        }
        [HttpGet]
        public async Task<IActionResult>GetAll()
        {
            var Students = await _unitOfWork.Student.GetAllAsync();
            var Data = _Map.Map<IEnumerable<Student>,IEnumerable<StudentDto>>(Students);
            return Ok(Data);
        }
        [HttpPost("{SSN}")]
        public async Task<IActionResult> Get(long SSN)
        {
            var CurrentStudent = await _unitOfWork.Student.GetByIdAsync(SSN);
            if (CurrentStudent != null)
            {
                var Data = _Map.Map<StudentDto>(CurrentStudent);

                return Ok(Data);
            }
            else
                return BadRequest("This Student don't Exist ");
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromForm]StudentDto studentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please insert informatio in right way");
            }
            else
            {
                try
                {

                    var Data = _Map.Map<Student>(studentDto);
                    Data.Image = UploadFiles.UploadImage(studentDto.Picture);
                    await _unitOfWork.Student.Insert(Data);
                    if (_unitOfWork.Complete() > 0)
                    {
                        return Ok("Adding student Successfully");
                    }
                    else
                    {
                        return BadRequest("Error when Adding student Data or Adress of Teacher");
                    }
                }
                catch (Exception ex)
                {

                    return BadRequest($"Adding Teacher Failed Message {ex.Message}");
                }

            }
        }

        [HttpPut("{SSN}")]
        public IActionResult Update( long SSN ,[FromForm] StudentDto studentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not Valid !");
            }
            var CurrentStudent = _unitOfWork.Student.GetById(SSN);
            if (CurrentStudent == null)
            {
                return BadRequest("This Student Not Found");
            }
            else
            {
                CurrentStudent = _Map.Map<StudentDto,Student>(studentDto,CurrentStudent);
                CurrentStudent.StudenntSSN = SSN;
                CurrentStudent.Image = studentDto.Image!= null? UploadFiles.UploadImage(studentDto.Picture) : CurrentStudent.Image;
                _unitOfWork.Student.Updating(SSN,CurrentStudent);
                if (_unitOfWork.Complete() > 0)
                {
                    return Ok("Update student Successfully");
                }
                else
                {
                    return BadRequest("Error please retrey again !");
                }
            }
            
        }

        [HttpDelete("{SSN}")]
        public IActionResult Delete(long? SSN)
        {
            if(SSN is null)
            {
                return BadRequest("Serial Number Is not valid !");
            }
            var CurrentSudent =  _unitOfWork.Student.GetById(SSN);
            if(CurrentSudent is null)
            {
                return BadRequest("Not Found ");
            }
            else
            {
                 _unitOfWork.Student.Delete(SSN);
                if (_unitOfWork.Complete() > 0)
                    return Ok("Delete Student has been Successfully");
                return Ok("Error please try again");
            }

        }
    }
}
