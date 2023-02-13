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
    public class SchoolsYear : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _Map;
        public SchoolsYear(IUnitOfWork unit, IMapper map)
        {
            this._unitOfWork = unit;
            this._Map = map;
        }
        // GET: api/<Department>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var SchoolsYears = await _unitOfWork.SchoolsYears.GetAllAsync();
            var Data = _Map.Map<IEnumerable<SchoolYears>, IEnumerable<SchoolYearsDto>>(SchoolsYears);
            return Ok(Data);
        }

        // GET api/<Department>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            if (id is null)
                return BadRequest("Not Valid !!");
            var CurrentSchoolYear = await _unitOfWork.SchoolsYears.GetByIdAsync(id);
            if (CurrentSchoolYear is null)
                return BadRequest("Not Valid !!");
            var Data = _Map.Map<SchoolYearsDto>(CurrentSchoolYear);
            return Ok(Data);
        }

        // POST api/<Department>
        [HttpPost]
        public async Task<IActionResult> Add(SchoolYearsDto schoolYearsDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not Valid !!");
            var Data = _Map.Map<SchoolYears>(schoolYearsDto);
            await _unitOfWork.SchoolsYears.Insert(Data);
            return _unitOfWork.Complete() > 0 ? Ok("Done") : BadRequest("Error in Add Department");
        }

        // PUT api/<Department>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SchoolYearsDto schoolYearsDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not Valid !!");
            var CurrentSchoolYear = await _unitOfWork.SchoolsYears.GetByIdAsync(id);
            if (CurrentSchoolYear is null)
                return BadRequest("Not Found This Department");
            CurrentSchoolYear = _Map.Map<SchoolYearsDto, SchoolYears>(schoolYearsDto, CurrentSchoolYear);
            CurrentSchoolYear.Id = id;
            _unitOfWork.SchoolsYears.Updating(id,CurrentSchoolYear);
            return _unitOfWork.Complete() > 0 ? Ok("Done") : BadRequest("Error in Update Department");
        }

        // DELETE api/<Department>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var CurrentSchoolYear = _unitOfWork.SchoolsYears.GetById(id);
            if (CurrentSchoolYear is null)
                return BadRequest("Not Found This Department");
            _unitOfWork.SchoolsYears.Delete(id);
            return _unitOfWork.Complete() > 0 ? Ok("Done") : BadRequest("Error in Delete Department");
        }
    }
}
