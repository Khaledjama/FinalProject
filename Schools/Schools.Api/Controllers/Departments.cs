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
    public class Departments : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _Map;
        public Departments(IUnitOfWork unit, IMapper map)
        {
            this._unitOfWork = unit;
            this._Map = map;
        }
        // GET: api/<Department>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Departments = await _unitOfWork.Department.GetAllAsync();
            var Data = _Map.Map<IEnumerable<Department>, IEnumerable<DepartmentDto>>(Departments);
            return Ok(Data);
        }

        // GET api/<Department>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            if (id is null)
                return BadRequest("Not Valid !!");
            var CurrentDepartment = await _unitOfWork.Department.GetByIdAsync(id);
            if(CurrentDepartment is null)
                return BadRequest("Not Valid !!");
            var Data = _Map.Map<DepartmentDto>(CurrentDepartment);
            return Ok(Data);
        }

        // POST api/<Department>
        [HttpPost]
        public async Task<IActionResult> Add( DepartmentDto departmentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not Valid !!");
            var Data = _Map.Map<Department>(departmentDto);
           await _unitOfWork.Department.Insert(Data);
            return _unitOfWork.Complete() > 0 ? Ok("Done") : BadRequest("Error in Add Department");
        }

        // PUT api/<Department>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id ,[FromBody] DepartmentDto departmentDto)
        {
            if ( !ModelState.IsValid)
                return BadRequest("Not Valid !!");
            var CurrentDepartment = await _unitOfWork.Department.GetByIdAsync(id);
            if (CurrentDepartment is null)
                return BadRequest("Not Found This Department");
            CurrentDepartment = _Map.Map<DepartmentDto, Department>(departmentDto, CurrentDepartment);
            CurrentDepartment.DepartmentId = id;
            _unitOfWork.Department.Updating(id,CurrentDepartment);
            return _unitOfWork.Complete() > 0 ? Ok("Done") : BadRequest("Error in Update Department");
        }

        // DELETE api/<Department>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var CurrentDepartment =  _unitOfWork.Department.GetById(id);
            if (CurrentDepartment is null)
                return BadRequest("Not Found This Department");
            _unitOfWork.Department.Delete(id);
            return _unitOfWork.Complete() > 0 ? Ok("Done") : BadRequest("Error in Delete Department");
        }
    }
}
