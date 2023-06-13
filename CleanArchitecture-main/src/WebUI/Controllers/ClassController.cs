using CleanArchitecture.WebUI.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.Application.ClassStudent.Queries.GetClasss;
using CleanArchitecture.Application.Students.Commands.CreateStudent;
using CleanArchitecture.Application.Students.Commands.DeleteStudent;
using CleanArchitecture.Application.Students.Commands.UpdateStudent;
using CleanArchitecture.Application.Students.Queries.GetStudents;
using CleanArchitecture.Application.ClassStudent.Commands.CreateClass;
using CleanArchitecture.Application.ClassStudent.Commands.DeleteClass;

namespace WebUI.Controllers;
public class ClassController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<ClassBriefDto>>> GetClassList()
    {
        return await Mediator.Send(new GetClasssListQuery());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<List<ClassBriefDto>>> GetClassById(int id)
    {
        return await Mediator.Send(new GetClassByIdQuery() { Id = id });
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateClassCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Update(int id, UpdateClassCommand command)
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
        await Mediator.Send(new DeleteClassCommand(id));

        return NoContent();
    }

}
