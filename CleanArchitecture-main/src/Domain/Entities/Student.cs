using System;
using System.Collections.Generic;

namespace CleanArchitecture.Domain.Entities;

public partial class Student
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int ClassId { get; set; }

    public virtual Classs Class { get; set; }
}
