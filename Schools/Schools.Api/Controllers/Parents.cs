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
    public class Parents : ControllerBase
    {
        // GET: api/<Parent>
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _Map;
        public Parents(IUnitOfWork unit, IMapper map)
        {
            this._unitOfWork = unit;
            this._Map = map;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Parents = await _unitOfWork.Parent.GetAllAsync();
            var Data = _Map.Map<IEnumerable<Parent>, IEnumerable<ParentDto>>(Parents);
            return Ok(Data);
        }
        [HttpPost("{SSN}")]
        public async Task<IActionResult> Get(long SSN)
        {
            var CurrentParent = await _unitOfWork.Parent.GetByIdAsync(SSN);
            if (CurrentParent != null)
            {
                var Data = _Map.Map<ParentDto>(CurrentParent);

                return Ok(Data);
            }
            else
                return BadRequest("This Student don't Exist ");
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] ParentDto studentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please insert informatio in right way");
            }
            else
            {
                try
                {

                    var Data = _Map.Map<Parent>(studentDto);
                    Data.Image = UploadFiles.UploadImage(studentDto.Picture);
                    await _unitOfWork.Parent.Insert(Data);
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
        public IActionResult Update(long SSN, [FromForm] ParentDto studentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not Valid !");
            }
            var CurrentParent = _unitOfWork.Parent.GetById(SSN);
            if (CurrentParent == null)
            {
                return BadRequest("This Student Not Found");
            }
            else
            {
                CurrentParent = _Map.Map<ParentDto, Parent>(studentDto, CurrentParent);
                CurrentParent.ParentSSN = SSN;
                CurrentParent.Image = studentDto.Image != null ? UploadFiles.UploadImage(studentDto.Picture) : CurrentParent.Image;
                _unitOfWork.Parent.Updating(SSN,CurrentParent);
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
            if (SSN is null)
            {
                return BadRequest("Serial Number Is not valid !");
            }
            var CurrentParent = _unitOfWork.Parent.GetById(SSN);
            if (CurrentParent is null)
            {
                return BadRequest("Not Found ");
            }
            else
            {
                _unitOfWork.Parent.Delete(SSN);
                if (_unitOfWork.Complete() > 0)
                    return Ok("Delete Student has been Successfully");
                return Ok("Error please try again");
            }

        }
    }
}
