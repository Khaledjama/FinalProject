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
    public class ClassRooms : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _Map;
        public ClassRooms(IUnitOfWork unit, IMapper map)
        {
            this._unitOfWork = unit;
            this._Map = map;
        }
        // GET: api/<Department>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Departments = await _unitOfWork.ClassRoom.GetAllAsync();
            var Data = _Map.Map<IEnumerable<ClassRoom>, IEnumerable<ClassRoomDto>>(Departments);
            return Ok(Data);
        }

        // GET api/<Department>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            if (id is null)
                return BadRequest("Not Valid !!");
            var CurrentClassRoom = await _unitOfWork.ClassRoom.GetByIdAsync(id);
            if (CurrentClassRoom is null)
                return BadRequest("Not Valid !!");
            var Data = _Map.Map<ClassRoomDto>(CurrentClassRoom);
            return Ok(Data);
        }

        // POST api/<Department>
        [HttpPost]
        public async Task<IActionResult> Add(ClassRoomDto classRoomDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not Valid !!");
            var Data = _Map.Map<ClassRoom>(classRoomDto);
            await _unitOfWork.ClassRoom.Insert(Data);
            return _unitOfWork.Complete() > 0 ? Ok("Done") : BadRequest("Error in Add Department");
        }

        // PUT api/<Department>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ClassRoomDto classRoomDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not Valid !!");
            var CurrentClassRoom = await _unitOfWork.ClassRoom.GetByIdAsync(id);
            if (CurrentClassRoom is null)
                return BadRequest("Not Found This Department");
            CurrentClassRoom = _Map.Map<ClassRoomDto, ClassRoom>(classRoomDto, CurrentClassRoom);
            CurrentClassRoom.Id = id;
            _unitOfWork.ClassRoom.Updating(id,CurrentClassRoom);
            return _unitOfWork.Complete() > 0 ? Ok("Done") : BadRequest("Error in Update Department");
        }

        // DELETE api/<Department>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var CurrentClassRoom = _unitOfWork.ClassRoom.GetById(id);
            if (CurrentClassRoom is null)
                return BadRequest("Not Found This Department");
            _unitOfWork.ClassRoom.Delete(id);
            return _unitOfWork.Complete() > 0 ? Ok("Done") : BadRequest("Error in Delete Department");
        }
    }
}
