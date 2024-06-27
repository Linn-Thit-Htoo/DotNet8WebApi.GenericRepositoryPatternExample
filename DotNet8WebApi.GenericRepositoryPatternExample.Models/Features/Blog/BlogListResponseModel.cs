using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8WebApi.GenericRepositoryPatternExample.Models.Features.Blog
{
    public class BlogListResponseModel
    {
        public List<BlogModel> Blogs { get; set; }
    }
}
