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
    public class Employees : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _Map;
        public Employees(IUnitOfWork unit, IMapper map)
        {
            this._unitOfWork = unit;
            this._Map = map;
        }
        // GET: api/<Department>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Departments = await _unitOfWork.Employee.GetAllAsync();
            var Data = _Map.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(Departments);
            return Ok(Data);
        }

        // GET api/<Department>/5
        [HttpGet("SSN:long")]
        public async Task<IActionResult> Get(long? SSN)
        {
            if (SSN is null)
                return BadRequest("Not Valid !!");
            var CurrentEmployee = await _unitOfWork.Employee.GetByIdAsync(SSN);
            if (CurrentEmployee is null)
                return BadRequest("Not Valid !!");
            var Data = _Map.Map<EmployeeDto>(CurrentEmployee);
            return Ok(Data.Department.DepartmentName);
        }

        // POST api/<Department>
        [HttpPost]
        public async Task<IActionResult> Add(EmployeeDto employeeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not Valid !!");
            var Data = _Map.Map<Employee>(employeeDto);
            await _unitOfWork.Employee.Insert(Data);
            return _unitOfWork.Complete() > 0 ? Ok("Done") : BadRequest("Error in Add Employee");
        }

        // PUT api/<Department>/5
        [HttpPut("SSN:long")]
        public async Task<IActionResult> Update(long SSN, [FromBody] EmployeeDto employeeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not Valid !!");
            var CurrentEmployee = await _unitOfWork.Employee.GetByIdAsync(SSN);
            if (CurrentEmployee is null)
                return BadRequest("Not Found This Department");
            CurrentEmployee = _Map.Map<EmployeeDto, Employee>(employeeDto, CurrentEmployee);
            CurrentEmployee.EmployeeSSN = SSN;
            _unitOfWork.Employee.Update(CurrentEmployee);
            return _unitOfWork.Complete() > 0 ? Ok("Done") : BadRequest("Error in Update Employee");
        }

        // DELETE api/<Department>/5
        [HttpDelete("SSN:long")]
        public async Task<IActionResult> Delete(long SSN)
        {
            var CurrentEmployee =await _unitOfWork.Employee.GetByIdAsync(SSN);
            if (CurrentEmployee is null)
                return BadRequest("Not Found This Employee");
            _unitOfWork.Employee.Delete(SSN);
            return _unitOfWork.Complete() > 0 ? Ok("Done") : BadRequest("Error in Delete Employee");
        }
        
    }
}
