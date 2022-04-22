using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectCRUD.Models;
using ProjectCRUD.Repository;
using ProjectCRUD.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentInterface _studentInterface;
        private readonly IMapper _mapper;

        public StudentController(IStudentInterface studentInterface, IMapper mapper)
        {
            _studentInterface = studentInterface;
            _mapper = mapper;
        }

        [HttpPost("AddStudent")]
        public async Task<IActionResult> addStudent(AddStudentViewModel student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _studentInterface.addStudent(_mapper.Map<Student>(student));
            var mapResult = _mapper.Map<Student>(result);
            return CreatedAtAction(nameof(getStudentsById), new { studentId = result.Id }, mapResult);
        }

        [HttpGet("GetAllStudents")]
        public async Task<IActionResult> getAllStudents()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _studentInterface.getAllStudents();
            var mapResult = _mapper.Map<IList<StudentViewModel>>(result);
            return Ok(mapResult);
        }
        [HttpGet("GetStudentsById"), ActionName("getStudentsById")]
        public async Task<IActionResult> getStudentsById(Guid studentId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _studentInterface.getStudentsById(studentId);
            var mapResult = _mapper.Map<StudentViewModel>(result);
            return Ok(mapResult);
        }

        [HttpGet("GetGender")]
        public async Task<IActionResult> getGender()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            var result = await _studentInterface.getGender();
            var mapResult = _mapper.Map<IList<GenderViewModel>>(result);
            return Ok(mapResult);
        }

        [HttpPut("UpdateStudent")]
        public async Task<IActionResult> updateStudentDetails(Guid studentId, [FromBody] UpdateStudentViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }

            var user = await _studentInterface.UserExists(studentId);

            if (user)
            {
                var result = await _studentInterface.UpdateUser(studentId, _mapper.Map<Student>(request));
                if (result != null)
                {
                    return Ok(_mapper.Map<Student>(result));
                }
            }

            return NotFound();


        }

        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> deleteUser(Guid studentId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _studentInterface.UserExists(studentId);

            if(user)
            {
                var result = await _studentInterface.deleteUser(studentId);
                var mapResult = _mapper.Map<Student>(result);
                return Ok(mapResult);
            }
            return NotFound();

        }
    }
}
