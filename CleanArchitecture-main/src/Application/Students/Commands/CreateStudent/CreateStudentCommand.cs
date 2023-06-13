using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
//using CleanArchitecture.Domain.Events;
using MediatR;

namespace CleanArchitecture.Application.Students.Commands.CreateStudent;

public record CreateStudentCommand : IRequest<int>
{
    //public int Id { get; init; }
    public string Name { get; set; }
    public int ClassId { get; set; }
}

public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateStudentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        var entity = new Student
        {
            //Id = request.Id,
            Name = request.Name,
            ClassId = request.ClassId,
        };

        //entity.AddDomainEvent(new StudentCreatedEvent(entity));

        _context.Students.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
