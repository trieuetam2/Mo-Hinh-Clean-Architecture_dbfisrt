using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
//using CleanArchitecture.Domain.Events;
using MediatR;

namespace CleanArchitecture.Application.ClassStudent.Commands.CreateClass;

public record CreateClassCommand : IRequest<int>
{
    //public int Id { get; init; }
    public string NameClass { get; set; }
}

public class CreateClassCommandHandler : IRequestHandler<CreateClassCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateClassCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateClassCommand request, CancellationToken cancellationToken)
    {
        var entity = new Classs
        {
            //Id = request.Id,
            NameClass = request.NameClass
        };

        //entity.AddDomainEvent(new StudentCreatedEvent(entity));

        _context.Classs.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
