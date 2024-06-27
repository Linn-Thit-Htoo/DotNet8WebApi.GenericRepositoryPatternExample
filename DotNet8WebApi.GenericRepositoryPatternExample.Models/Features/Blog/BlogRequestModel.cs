using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8WebApi.GenericRepositoryPatternExample.Models.Features.Blog
{
    public class BlogRequestModel
    {
        public string? BlogTitle { get; set; } = null!;

        public string? BlogAuthor { get; set; } = null!;

        public string? BlogContent { get; set; } = null!;
    }
}
