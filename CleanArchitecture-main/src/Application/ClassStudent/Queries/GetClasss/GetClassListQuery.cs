using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Students.Queries.GetStudents;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.ClassStudent.Queries.GetClasss;

public record GetClasssListQuery : IRequest<List<ClassBriefDto>>
{
    public int Id { get; init; }
}

public class GetClasssQueryHandler : IRequestHandler<GetClasssListQuery, List<ClassBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetClasssQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ClassBriefDto>> Handle(GetClasssListQuery request, CancellationToken cancellationToken)
    {
        var query = await _context.Classs
            //.Where(x => x.Id == request.Id)
            .Include(c => c.Students)
            .OrderBy(x => x.Id)
            .Select(c => new ClassBriefDto
            {
                Id = c.Id,
                NameClass = c.NameClass,
                Students = c.Students.Select(s => new StudentBriefDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    ClassId = s.ClassId,
                    // Map other student properties if needed
                }).ToList()
            })
            .ToListAsync(cancellationToken);
        return query;
    }

}
