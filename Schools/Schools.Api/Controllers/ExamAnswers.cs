using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Schools.DAL.UnitOfWork;
using Schools.DataStorage.Entity;
using Schools.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schools.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExamAnswers : ControllerBase
    {
        // GET: api/<Parent>
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _Map;
        public ExamAnswers(IUnitOfWork unit, IMapper map)
        {
            this._unitOfWork = unit;
            this._Map = map;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ExamAnswers = await _unitOfWork.ExamAnswer.GetAllAsync();
            var Data = _Map.Map<IEnumerable<ExamAnswer>, IEnumerable<ExamAnswerDto>>(ExamAnswers);
            return Ok(Data);
        }
        [HttpPost("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var CurrentExamAnswer = await _unitOfWork.ExamAnswer.GetByIdAsync(Id);
            if (CurrentExamAnswer != null)
            {
                var Data = _Map.Map<ExamAnswerDto>(CurrentExamAnswer);

                return Ok(Data);
            }
            else
                return BadRequest("This Student don't Exist ");
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] ExamAnswerDto examAnswerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please insert informatio in right way");
            }
            else
            {
                try
                {

                    var Data = _Map.Map<ExamAnswer>(examAnswerDto);
                    await _unitOfWork.ExamAnswer.Insert(Data);
                    if (_unitOfWork.Complete() > 0)
                    {
                        return Ok("Adding Exam Answer Successfully");
                    }
                    else
                    {
                        return BadRequest("Error when Adding Exam Answer");
                    }
                }
                catch (Exception ex)
                {

                    return BadRequest($"Adding Teacher Failed Message {ex.Message}");
                }

            }
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(int Id, [FromForm] ExamAnswerDto examAnswerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not Valid !");
            }
            var CurrentExamAnswer = await _unitOfWork.ExamAnswer.GetByIdAsync(Id);
            if (CurrentExamAnswer is null)
                return BadRequest("This Exam Answer are Not Found");
            CurrentExamAnswer = _Map.Map<ExamAnswerDto, ExamAnswer>(examAnswerDto, CurrentExamAnswer);
            CurrentExamAnswer.Id = Id;
            _unitOfWork.ExamAnswer.Updating(Id,CurrentExamAnswer);
            return _unitOfWork.Complete() > 0 ? Ok("Update Successfully") : BadRequest("Update Failed !!");
        }
        [HttpDelete("{Id}")]
        public IActionResult Delete(int? Id)
        {
            if (Id is null)
            {
                return BadRequest("Not valid !");
            }
            var CurrentExamAnswer = _unitOfWork.ExamAnswer.GetById(Id);
            if (CurrentExamAnswer is null)
            {
                return BadRequest("Not Found ");
            }
            else
            {
                _unitOfWork.ExamAnswer.Delete(Id);
                if (_unitOfWork.Complete() > 0)
                    return Ok("Delete ExamType has been Successfully");
                return Ok("Error please try again");
            }

        }
    }
}
