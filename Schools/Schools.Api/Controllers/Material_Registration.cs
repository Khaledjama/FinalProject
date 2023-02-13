using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Schools.DAL.UnitOfWork;
using Schools.DataStorage.Entity;
using Schools.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Schools.Api.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class Material_Registration : ControllerBase
    {
        // GET: api/<Material_RegistrationController>
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _Map;
        private readonly UserManager<ApplicationUser> _userManager;

        public Material_Registration(IUnitOfWork unit, IMapper map , UserManager<ApplicationUser> user)
        {
            this._unitOfWork = unit;
            this._Map = map;
        }
        [HttpPost("{MaterialId}")]
        public async Task<IActionResult> RegisterMaterial(string MaterialId)
        {
            
            var CurrentUser = await _userManager.GetUserAsync(User);
            var UserId = long.Parse(CurrentUser.Id);
            var CurrentSubject = _unitOfWork.Subject.GetById(MaterialId);
            StudentsSubjectsDto studentsSubjects = new StudentsSubjectsDto { StudentId = UserId,
                SubjectId = MaterialId,
                Description="Student : "+CurrentUser.UserName + "is rolled Course :"+CurrentSubject.Name +"at : "+DateTime.Now };
            var Data = _Map.Map<StudentsSubjects>(studentsSubjects);
           await _unitOfWork.StudentSubject.Insert(Data);
            if (_unitOfWork.Complete() > 0)
                return Ok("Adding Course To Your RegisterMaterial Done");
            else
                return BadRequest("Error");
            
        }
        [HttpGet]
        public async Task<IActionResult> GetMyRegisteration()
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            var UserId = CurrentUser.Id;
            var Student_SSN=  _unitOfWork.UserRepo.GetCurrentUserByUserId(UserId).StudenntSSN;
            var studentsSubjects =await _unitOfWork.StudentSubject.FindAsync((s) => s.StudentId == Student_SSN);
            var Data = _Map.Map<StudentsSubjectsDto>(studentsSubjects);
            return Ok(Data) ;
        }

        // GET api/<Material_RegistrationController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Material_RegistrationController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<Material_RegistrationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Material_RegistrationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
