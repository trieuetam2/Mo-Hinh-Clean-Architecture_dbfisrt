using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.ClassStudent.Queries.GetClasss;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.ClassStudent.Queries.GetClasss;

public record GetClassByIdQuery : IRequest<List<ClassBriefDto>>
{
    public int Id { get; init; }
}

public class GetClassByIdQueryHandler : IRequestHandler<GetClassByIdQuery, List<ClassBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetClassByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ClassBriefDto>> Handle(GetClassByIdQuery request, CancellationToken cancellationToken)
    {
        var query = await _context.Classs
            .Where(x => x.Id == request.Id)
            .OrderBy(x => x.Id)
            .ProjectTo<ClassBriefDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
        return query;
    }
}
