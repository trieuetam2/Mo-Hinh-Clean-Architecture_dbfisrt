using System;
using System.Collections.Generic;

namespace CleanArchitecture.Domain.Entities;

public partial class Classs
{
    public int Id { get; set; }

    public string NameClass { get; set; }

    public virtual ICollection<LichHoc> LichHocs { get; } = new List<LichHoc>();

    public virtual ICollection<Student> Students { get; } = new List<Student>();
}
