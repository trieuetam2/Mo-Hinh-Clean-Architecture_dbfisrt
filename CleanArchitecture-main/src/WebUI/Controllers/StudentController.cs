using CleanArchitecture.Application.Students.Commands.CreateStudent;
using CleanArchitecture.Application.Students.Commands.UpdateStudent;
using CleanArchitecture.Application.Students.Queries.GetStudents;
using CleanArchitecture.Application.Students.Commands.DeleteStudent;
using CleanArchitecture.WebUI.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;
public class StudentController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<StudentBriefDto>>> GetStudentsList()
    {
        return await Mediator.Send(new GetStudentsListQuery());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<List<StudentBriefDto>>> GetStudentsById(int id)
    {
        return await Mediator.Send(new GetStudentsByIdQuery() { Id = id });
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateStudentCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Update(int id, UpdateStudentCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteStudentCommand(id));

        return NoContent();
    }
}
