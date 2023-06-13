using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Students.Queries.GetStudents;

public record GetStudentsListQuery : IRequest<List<StudentBriefDto>>
{
    public int Id { get; init; }
}

public class GetStudentsQueryHandler : IRequestHandler<GetStudentsListQuery, List<StudentBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetStudentsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<StudentBriefDto>> Handle(GetStudentsListQuery request, CancellationToken cancellationToken)
    {
        var query = await _context.Students
            //.Where(x => x.Id == request.Id)
            .OrderBy(x => x.Id)
            .ProjectTo<StudentBriefDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
        return query;
    }
}
