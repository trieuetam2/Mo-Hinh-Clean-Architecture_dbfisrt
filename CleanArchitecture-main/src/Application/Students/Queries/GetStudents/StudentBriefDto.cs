using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Students.Queries.GetStudents;

public class StudentBriefDto : IMapFrom<Student>
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int ClassId { get; set; }
}
