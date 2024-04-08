using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using StudentMarks.BusinessLogic;
using StudentMarks.Context;
using StudentMarks.DTO.Subject;
using StudentMarks.Mapper;
using StudentMarks.Model;
using StudentMarks.Repositery;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentMarks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectRepositery _subjectRepositery;
        private readonly IMapper _mapper;
        public SubjectController(ISubjectRepositery subjectRepositery, IMapper mapper)
        {
            _subjectRepositery = subjectRepositery;
            _mapper = mapper;
        }

        // Get all subjects.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetSubjectDTO>>> Get()
        {
            var subs = await _subjectRepositery.GetAll();
            var subjects = _mapper.Map<List<Subject>, List<GetSubjectDTO>>(subs);

            if (subjects != null)
            {
                return Ok(subjects);
            }

            return NotFound();
        }

        // Get the subject using its Id.
        [HttpGet("{id}")]
        public async Task<ActionResult<GetSubjectDTO>> Get(int id)
        {
            var sub = await _subjectRepositery.Get(id);
            if (sub != null) { 
                var subject = _mapper.Map<Subject, GetSubjectDTO>(sub);
                return Ok(subject);
            }
            return NotFound();
        }

        // Creates the subject.
        [HttpPost]
        public async Task<ActionResult<CreateSubjectDTO>> Create([FromBody] CreateSubjectDTO createSubject)
        {

            var student = await _subjectRepositery.CreateCheck(createSubject);

            if (student)
            {
                var subject = _mapper.Map<CreateSubjectDTO, Subject>(createSubject);
                subject.Result = ResultCalculation.GetResult(createSubject.Marks);
                await _subjectRepositery.Create(subject);
                return Ok(createSubject);
            }

            return StatusCode(406, "Not accepted");
        }

        // Update the edited subject.
        [HttpPut("id")]
        public async Task<ActionResult<UpdateSubjectDTO>> Edit([FromBody] UpdateSubjectDTO updateSubject)
        {
            var subj = await _subjectRepositery.UpdateCheck(updateSubject);
            if (subj && updateSubject != null)
            {
                var subject = _mapper.Map<UpdateSubjectDTO, Subject>(updateSubject);
                subject.Result = ResultCalculation.GetResult(updateSubject.Marks);

                var result = await _subjectRepositery.Update(subject);
                if (result == 1)
                {
                    return Ok(subject);
                }
                return StatusCode(406, "Not accepted");
                //_studentDbContext.subjects.Update(subj);
                //_studentDbContext.SaveChanges();
                //return Ok(updateSubject);
            }

            return StatusCode(406, "Not accepted");
        }
    }
}
