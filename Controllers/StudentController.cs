using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentMarks.Context;
using StudentMarks.DTO.Student;
using StudentMarks.Mapper;
using StudentMarks.Model;
using StudentMarks.Repositery;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentMarks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepositery _studentRepositery;
        private readonly IMapper _studentMapper;
        public StudentController(IStudentRepositery studentRepositery, IMapper studentMapper) { 
            _studentRepositery = studentRepositery;
            _studentMapper = studentMapper;
        }

        // GET all students.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> Get()
        {
            var stds = await _studentRepositery.GetAll();
            var students = _studentMapper.Map< List<Student>,List<StudentDTO>>(stds);

            if(students != null )
            {
                return Ok(students);
            }
            return NotFound();
        }

        // GET the student with given id.
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDTO>> Get(int id)
        {
            var std = await _studentRepositery.Get(id);
            var student = _studentMapper.Map<Student,StudentDTO>(std);
            if(student != null)
            {
                return Ok(student);
            }
            return NotFound();
        }

        // Create the new student.
        [HttpPost]
        public async Task<ActionResult<CreateStudentDTO>> Create([FromBody] CreateStudentDTO student)
        {
            var student1 = _studentMapper.Map<CreateStudentDTO,Student>(student);
            var std = await _studentRepositery.CreateCheck(student);
            if(std)
            {
                return StatusCode(406, "Not accepted");
            }

            await _studentRepositery.Create(student1);
            return Ok(student1);
        }

        // Update the edited student.
        [HttpPut("id")]
        public async Task<ActionResult<StudentDTO>> Edit([FromBody] StudentDTO student) {
             var std = await _studentRepositery.UpdateCheck(student);
            if (std)
            {
                var student1 = _studentMapper.Map<StudentDTO,Student>(student);

                var result = await _studentRepositery.Update(student1);

                if (result == 1)
                {
                    return Ok(student);
                }
                //_studentDbContext.students.Update(std);
                //_studentDbContext.SaveChanges();
                //return Ok(student);
            }

            return StatusCode(406,"Not accepted");
        }

    }
}
