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
    public class ExamTypes : ControllerBase
    {
        // GET: api/<Parent>
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _Map;
        public ExamTypes(IUnitOfWork unit, IMapper map)
        {
            this._unitOfWork = unit;
            this._Map = map;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ExamTypes = await _unitOfWork.ExamType.GetAllAsync();
            var Data = _Map.Map<IEnumerable<ExamType>, IEnumerable<ExamTypeDto>>(ExamTypes);
            return Ok(Data);
        }
        [HttpPost("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var CurrentExamType = await _unitOfWork.ExamType.GetByIdAsync(Id);
            if (CurrentExamType != null)
            {
                var Data = _Map.Map<ExamTypeDto>(CurrentExamType);

                return Ok(Data);
            }
            else
                return BadRequest("This Student don't Exist ");
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] ExamTypeDto examTypeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please insert informatio in right way");
            }
            else
            {
                try
                {

                    var Data = _Map.Map<ExamType>(examTypeDto);
                    await _unitOfWork.ExamType.Insert(Data);
                    if (_unitOfWork.Complete() > 0)
                    {
                        return Ok("Adding Exam Type Successfully");
                    }
                    else
                    {
                        return BadRequest("Error when Adding Exam type");
                    }
                }
                catch (Exception ex)
                {

                    return BadRequest($"Adding Teacher Failed Message {ex.Message}");
                }

            }
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(int Id, [FromForm] ExamTypeDto examTypeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not Valid !");
            }
            var CurrentExamType = await _unitOfWork.ExamType.GetByIdAsync(Id);
            if (CurrentExamType is null)
                return BadRequest("This Exam Answer are Not Found");
            CurrentExamType = _Map.Map<ExamTypeDto, ExamType>(examTypeDto, CurrentExamType);
            CurrentExamType.Id = Id;
            _unitOfWork.ExamType.Updating(Id,CurrentExamType);
            return _unitOfWork.Complete() > 0 ? Ok("Update Successfully") : BadRequest("Update Failed !!");
        }
        [HttpDelete("{Id}")]
        public IActionResult Delete(int? Id)
        {
            if (Id is null)
            {
                return BadRequest("Not valid !");
            }
            var CurrentExamType = _unitOfWork.ExamType.GetById(Id);
            if (CurrentExamType is null)
            {
                return BadRequest("Not Found ");
            }
            else
            {
                _unitOfWork.ExamType.Delete(Id);
                if (_unitOfWork.Complete() > 0)
                    return Ok("Delete ExamType has been Successfully");
                return Ok("Error please try again");
            }

        }
    }
}
