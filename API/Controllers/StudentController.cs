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
            var result = await mediator.Send(new CreateStudentCommand(student.Name,
        student.Class,
        student.Father_Name,
        student.Mother_Name));
            return Ok(result);
    }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(
    Guid id,
    Student student)
        {
            var result = await mediator.Send(
                new UpdateStudentCommand(
                    id,
                    student.Name,
                    student.Class,
                    student.Father_Name,
                    student.Mother_Name
                ));

            return Ok(result);
        }
        [HttpDelete("DeleteStudent/{Id}")]
        public async Task<IActionResult> deleteStudent(Guid Id)
        {
            var result = await mediator.Send(new DeleteStudentCommand(Id));
            return Ok(result);
        }
}
}
