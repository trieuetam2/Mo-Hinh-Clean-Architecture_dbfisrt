using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Students.Commands.UpdateStudent;

public record UpdateStudentCommand : IRequest
{
    public int Id { get; init; }
    public string Name { get; set; }
    public int ClassId { get; set; }
}

public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateStudentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Students
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Students), request.Id);
        }

        entity.Name = request.Name;
        entity.ClassId = request.ClassId;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
