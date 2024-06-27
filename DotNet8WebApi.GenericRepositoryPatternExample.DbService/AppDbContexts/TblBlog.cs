using System;
using System.Collections.Generic;

namespace DotNet8WebApi.GenericRepositoryPatternExample.DbService.AppDbContexts;

public partial class TblBlog
{
    public int BlogId { get; set; }

    public string? BlogTitle { get; set; }

    public string? BlogAuthor { get; set; }

    public string? BlogContent { get; set; }
}
