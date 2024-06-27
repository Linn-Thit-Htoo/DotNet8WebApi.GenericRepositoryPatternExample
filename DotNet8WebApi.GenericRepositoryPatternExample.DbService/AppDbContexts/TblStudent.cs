using System;
using System.Collections.Generic;

namespace DotNet8WebApi.GenericRepositoryPatternExample.DbService.AppDbContexts;

public partial class TblStudent
{
    public int StudentId { get; set; }

    public string StudentName { get; set; } = null!;

    public int Age { get; set; }

    public string Major { get; set; } = null!;

    public bool IsActive { get; set; }
}
