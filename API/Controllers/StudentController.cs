using Application.Commands;
using Application.Queries;
using Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(IMediator mediator) : ControllerBase
    {
        [HttpGet("GetAllStudents")]
       public async Task<IActionResult> GetAllStudents()
        {   
            var result = await mediator.Send(new GetAllStudentsQuery());
            return Ok(result);

        }

        [HttpPost("AddStudent")]
        public async Task<IActionResult> addStudent(Student student)
        {
            var result = await mediator.Send(new CreateStudentCommand(student));
            return Ok(result);
    }
        [HttpPut("UpdateStudent")]
        public async Task<IActionResult> updateStudent(Guid Id, Student student)
        {
            var result = await mediator.Send(new UpdateStudentCommand(Id, student));
            return Ok(result);
        }
        [HttpDelete("DeleteStudent")]
        public async Task<IActionResult> deleteStudent(Guid Id)
        {
            var result = await mediator.Send(new DeleteStudentCommand(Id));
            return Ok(result);
        }
}
}
