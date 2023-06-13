using System;
using System.Collections.Generic;

namespace CleanArchitecture.Domain.Entities;

public partial class LichHoc
{
    public int IdLichHoc { get; set; }

    public string Tkb { get; set; }

    public DateTime? NgayBatDau { get; set; }

    public DateTime? NgayKetThuc { get; set; }

    public string Noidung { get; set; }

    public int? ClassId { get; set; }

    public virtual Classs Class { get; set; }
}
