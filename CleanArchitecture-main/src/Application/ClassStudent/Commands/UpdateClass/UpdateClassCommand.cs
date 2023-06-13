using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Students.Commands.UpdateStudent;

public record UpdateClassCommand : IRequest
{
    public int Id { get; init; }
    public string NameClass { get; set; }
}

public class UpdateClassCommandHandler : IRequestHandler<UpdateClassCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateClassCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateClassCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Classs
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Classs), request.Id);
        }

        entity.NameClass = request.NameClass;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
