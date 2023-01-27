using AutoMapper;
using Microsoft.AspNetCore.Http;
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
    public class Teachers : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _Map;
        public Teachers(IUnitOfWork unit ,IMapper map)
        {
            this._unitOfWork = unit;
            this._Map = map;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Teachers = await _unitOfWork.Teacher.GetAllAsync();
            var Data = _Map.Map<IEnumerable<Teacher>, IEnumerable<TeacherDto>>(Teachers);
            return Ok(Data);
        }

        [HttpPost("SSN:long")]
        public async Task<IActionResult> Get(long SSN)
        {
            var CurrentTeacher = await _unitOfWork.Teacher.GetByIdAsync(SSN);
            if (CurrentTeacher != null)
            {
                var Data = _Map.Map<TeacherDto>(CurrentTeacher);

                return Ok(Data);
            }
            else
                return BadRequest("This Teacher don't Exist ");
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromForm]TeacherDto teacherDto )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please insert informatio in right way");
            }
            else
            {
                try
                {
                    
                    var Data = _Map.Map<Teacher>(teacherDto);
                    Data.Image = UploadFiles.UploadImage(teacherDto.Picture);
                    await _unitOfWork.Teacher.Insert(Data);
                    if (_unitOfWork.Complete() > 0)
                    {
                        return Ok("Adding Teacher Successfully");
                    }
                    else
                    {
                        return BadRequest("Error when Adding Teacher Data or Adress of Teacher");
                    }
                }
                catch (Exception ex)
                {

                    return BadRequest($"Adding Teacher Failed Message {ex.Message}");
                }
                
            }
        }
       
      
        [HttpPut("SSN:long")]
        public IActionResult Update(long SSN, [FromForm] TeacherDto teacherDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not Valid !");
            }
            var CurrentTeacher = _unitOfWork.Teacher.GetById(SSN);
            if (CurrentTeacher == null)
            {
                return BadRequest("This Student Not Found");
            }
            else
            {
                CurrentTeacher = _Map.Map<TeacherDto, Teacher>(teacherDto, CurrentTeacher);
                CurrentTeacher.TeacherSSN = SSN;
                CurrentTeacher.Image = teacherDto.Image != null ? UploadFiles.UploadImage(teacherDto.Picture) : CurrentTeacher.Image;
                _unitOfWork.Teacher.Update(CurrentTeacher);
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

        [HttpDelete("{SSN:long}")]
        public IActionResult Delete(long? SSN)
        {
            if (SSN is null)
            {
                return BadRequest("Serial Number Is not valid !");
            }
            var CurrentTeacher = _unitOfWork.Teacher.GetById(SSN);
            if (CurrentTeacher is null)
            {
                return BadRequest("Not Found ");
            }
            else
            {
                _unitOfWork.Teacher.Delete(SSN);
                if (_unitOfWork.Complete() > 0)
                    return Ok("Delete Student has been Successfully");
                return Ok("Error please try again");
            }

        }
    }
}
