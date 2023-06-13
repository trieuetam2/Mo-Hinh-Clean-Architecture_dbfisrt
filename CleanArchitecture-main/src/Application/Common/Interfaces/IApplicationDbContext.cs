using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    //DbSet<TodoList> TodoLists { get; }

    //DbSet<TodoItem> TodoItems { get; }
    DbSet<Student> Students { get; }
    DbSet<Classs> Classs { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
