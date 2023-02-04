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
    public class Exams : ControllerBase
    {

        // GET: api/<Exams>
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _Map;
        public Exams(IUnitOfWork unit, IMapper map)
        {
            this._unitOfWork = unit;
            this._Map = map;
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] ExamDto examDto)
        {

            if (!ModelState.IsValid)
                return BadRequest("Invalid Exam");
            var Data = _Map.Map<Exam>(examDto);
            if (examDto.ExamPicture is null)
                return BadRequest("Adding Exam Failed");
            string ExamPdf = UploadFiles.UploadExamAsPdf(examDto.ExamPicture);
            if (string.IsNullOrEmpty(ExamPdf))
                return BadRequest("Adding Exam Failed"); ;
            Data.ExamPdf = ExamPdf;
            await _unitOfWork.Exam.Insert(Data);
            return _unitOfWork.Complete() > 0 ? Ok("Adding Exam Successfully") : BadRequest("Adding Exam Failed");

        }

        // GET api/<Exams>/5
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Exams = await _unitOfWork.Exam.GetAllAsync();
            var Data = _Map.Map<IEnumerable<Exam>, IEnumerable<ExamDto>>(Exams);
            return Ok(Data);
        }
        [HttpPost("Id:int")]
        public async Task<IActionResult> Get(int Id)
        {
            var CurrentExamAnswer = await _unitOfWork.Exam.GetByIdAsync(Id);
            if (CurrentExamAnswer != null)
            {
                var Data = _Map.Map<ExamDto>(CurrentExamAnswer);

                return Ok(Data);
            }
            else
                return BadRequest("This Exam don't Exist ");
        }
        
        [HttpPut("Id:int")]
        public async Task<IActionResult> Update(int Id, [FromForm] ExamDto examDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not Valid !");
            }
            var CurrentExam = await _unitOfWork.Exam.GetByIdAsync(Id);
            if (CurrentExam is null)
                return BadRequest("This Exam Answer are Not Found");
            CurrentExam = _Map.Map<ExamDto, Exam>(examDto, CurrentExam);
            CurrentExam.ExamPdf = string.IsNullOrEmpty(CurrentExam.ExamPdf) ? CurrentExam.ExamPdf : UploadFiles.UploadExamAsPdf(examDto.ExamPicture);
            CurrentExam.Id = Id;
            _unitOfWork.Exam.Update(CurrentExam);
            return _unitOfWork.Complete() > 0 ? Ok("Update Successfully") : BadRequest("Update Failed !!");
        }
        [HttpDelete("Id:int")]
        public IActionResult Delete(int? Id)
        {
            if (Id is null)
            {
                return BadRequest("Not valid !");
            }
            var CurrentExam = _unitOfWork.Exam.GetById(Id);
            if (CurrentExam is null)
            {
                return BadRequest("Not Found ");
            }
            else
            {
                _unitOfWork.Exam.Delete(Id);
                if (_unitOfWork.Complete() > 0)
                    return Ok("Delete ExamType has been Successfully");
                return Ok("Error please try again");
            }

        }
    }
}
