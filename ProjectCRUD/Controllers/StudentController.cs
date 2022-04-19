using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("GetAllStudents")]
        public async Task<IActionResult> getAllStudents()
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _studentInterface.getAllStudents();
            var mapResult = _mapper.Map<IList<StudentViewModel>>(result);
            return Ok(mapResult);
        }

    }
}
