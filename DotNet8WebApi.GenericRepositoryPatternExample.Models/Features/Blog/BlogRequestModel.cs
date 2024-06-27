namespace DotNet8WebApi.GenericRepositoryPatternExample.Models.Features.Blog;

public class BlogRequestModel
{
    public string? BlogTitle { get; set; } = null!;

    public string? BlogAuthor { get; set; } = null!;

    public string? BlogContent { get; set; } = null!;
}
