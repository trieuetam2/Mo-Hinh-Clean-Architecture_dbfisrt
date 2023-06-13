using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
//using CleanArchitecture.Domain.Events;
using MediatR;

namespace CleanArchitecture.Application.ClassStudent.Commands.DeleteClass;

public record DeleteClassCommand(int Id) : IRequest;

public class DeleteClassCommandHandler : IRequestHandler<DeleteClassCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteClassCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteClassCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Classs
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Classs), request.Id);
        }

        _context.Classs.Remove(entity);

        //entity.AddDomainEvent(new TodoItemDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }

}
