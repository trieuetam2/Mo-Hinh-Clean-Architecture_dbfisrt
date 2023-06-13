using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Application.Students.Queries.GetStudents;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.ClassStudent.Queries.GetClasss;

public class ClassBriefDto : IMapFrom<Classs>
{
    public int Id { get; set; }

    public string NameClass { get; set; }

    //public virtual ICollection<Student> Students { get; } = new List<Student>();

    public List<StudentBriefDto> Students { get; set; }
}
