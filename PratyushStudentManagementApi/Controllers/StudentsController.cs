using MediatR;
using Microsoft.AspNetCore.Mvc;
using PratyushStudentManagementApi.Handlers.Commands;
using PratyushStudentManagementApi.Handlers.Queries;
using PratyushStudentManagementApi.Models;

namespace PratyushStudentManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetAllStudents()
        {
            var studentList = await _mediator.Send(new GetAllStudentsQuery());
            return Ok(studentList);
        }

        // GET: api/students/{studentId}
        [HttpGet("{studentId:int}")]
        public async Task<ActionResult<Student>> GetStudentById(int studentId)
        {
            var student = await _mediator.Send(new GetStudentByIdQuery(studentId));

            if (student is null)
                return NotFound();

            return Ok(student);
        }

        // POST: api/students
        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent([FromBody] AddStudentCommand command)
        {
            var createdStudent = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetStudentById),
                new { studentId = createdStudent.StudentId },
                createdStudent);
        }

        // PUT: api/students/{studentId}
        [HttpPut("{studentId:int}")]
        public async Task<IActionResult> UpdateStudent(int studentId, [FromBody] UpdateStudentCommand command)
        {
            if (studentId != command.StudentId)
            {
                return BadRequest("Route studentId and body StudentId must match.");
            }

            var updated = await _mediator.Send(command);

            if (!updated)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/students/{studentId}
        [HttpDelete("{studentId:int}")]
        public async Task<IActionResult> DeleteStudent(int studentId)
        {
            var removed = await _mediator.Send(new DeleteStudentCommand(studentId));

            if (!removed)
                return NotFound();

            return NoContent();
        }
    }
}
