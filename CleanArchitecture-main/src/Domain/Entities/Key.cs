using System;
using System.Collections.Generic;

namespace CleanArchitecture.Domain.Entities;

public partial class Key
{
    public string Id { get; set; }

    public int Version { get; set; }

    public DateTime Created { get; set; }

    public string Use { get; set; }

    public string Algorithm { get; set; }

    public bool IsX509certificate { get; set; }

    public bool DataProtected { get; set; }

    public string Data { get; set; }
}
