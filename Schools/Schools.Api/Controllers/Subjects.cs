using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Schools.DAL.UnitOfWork;
using Schools.DataBase.Context;
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
    public class Subjects : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _Map;
        private readonly SchoolsDB _Db;
        public Subjects(IUnitOfWork unit,IMapper map, SchoolsDB Db)
        {
            this._unitOfWork = unit;
            this._Map = map;
            this._Db = Db;
        }
        // GET: api/<Subject>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Subjects = await _unitOfWork.Subject.GetAllAsync();
            var Data = _Map.Map<IEnumerable<Subject>, IEnumerable<SubjectDto>>(Subjects);
            return Ok(Data);
        }

        // GET api/<Subject>/5
        [HttpGet("{CodedId}")]
        public async Task<IActionResult> Get(string CodedId)
        {
            bool StatuesCodedId = string.IsNullOrEmpty(CodedId);
            if (StatuesCodedId)
                return BadRequest("Coded Id is Not Valid !");
            var CurrentSubject = await _unitOfWork.Subject.GetByIdAsync(CodedId);
            if (CurrentSubject is null)
                return BadRequest("This Subject is Not Found");
            var Data = _Map.Map<SubjectDto>(CurrentSubject);
            return Ok(Data);
        }
        [HttpPut("{CodedId}")]
        public async Task<IActionResult> Update(string CodedId, SubjectDto subjectDto)
        {
            bool StatuesCodedId = string.IsNullOrEmpty(CodedId);
            if (StatuesCodedId)
                return BadRequest("Invalid Coded Id");
            var CurrentSubject = await _unitOfWork.Subject.GetByIdAsync(CodedId);
            if (CurrentSubject is null)
                return BadRequest("This Subject are Not Found");
            CurrentSubject = _Map.Map<Subject>(subjectDto);
            CurrentSubject.CodeId = CodedId;
            _unitOfWork.Subject.Updating(CodedId, CurrentSubject);
            return _unitOfWork.Complete() > 0 ? Ok("Update Successfully") : BadRequest("Update Failed !!");
                
        }
        [HttpPut("{CodedId}")]
        public async Task<IActionResult> Updating(string CodedId, SubjectDto subjectDto)
        {
            bool StatuesCodedId = string.IsNullOrEmpty(CodedId);
            if (StatuesCodedId)
                return BadRequest("Invalid Coded Id");
            var CurrentSubject = await _unitOfWork.Subject.GetByIdAsync(CodedId);
            if (CurrentSubject is null)
                return BadRequest("This Subject are Not Found");
            CurrentSubject = _Map.Map<Subject>(subjectDto);
            CurrentSubject.CodeId = CodedId;
            _unitOfWork.Subject.Updating(CodedId, CurrentSubject);
            return _unitOfWork.Complete() > 0 ? Ok("Update Successfully") : BadRequest("Update Failed !!");
                
        }

        [HttpPost]
        public async Task<IActionResult> Add(SubjectDto subjectDto )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model Validate is Not Correct");
            }
            else
            {
                try
                {
                    var data = _Map.Map<Subject>(subjectDto);
                    await _unitOfWork.Subject.Insert(data);
                    if(await _unitOfWork.CompleteAsync() > 0)
                    {
                        return Ok("Adding Subject Successfully");
                    }
                    else
                    {
                        return BadRequest("Adding Subject Failed !!!");
                    }

                }
                catch (Exception ex)
                {
                    return BadRequest($"Adding Subject Failed !!!{ex.Message}");

                }
            }
        }

        // DELETE api/<Subject>/5
        [HttpDelete("{CodedId}")]
        public async Task<IActionResult> Delete(string CodedId)
        {
            bool StatuesCodedId = string.IsNullOrEmpty(CodedId);
            if (StatuesCodedId)
                return BadRequest("Invalid Coded Id");
            var CurrentSubject = await _unitOfWork.Subject.GetByIdAsync(CodedId);
            if (CurrentSubject is null)
                return BadRequest("This Subject are Not Found");
            _unitOfWork.Subject.Delete(CodedId);
            return _unitOfWork.Complete() > 0 ? Ok("Delete Successfully") : BadRequest("Delete Failed !!");

        }
    }
}
