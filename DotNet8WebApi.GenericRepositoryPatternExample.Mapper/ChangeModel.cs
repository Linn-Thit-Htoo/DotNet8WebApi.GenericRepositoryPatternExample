namespace DotNet8WebApi.GenericRepositoryPatternExample.Mapper;

public static class ChangeModel
{
    public static BlogModel Change(this TblBlog dataModel)
    {
        return new BlogModel
        {
            BlogId = dataModel.BlogId,
            BlogTitle = dataModel.BlogTitle,
            BlogAuthor = dataModel.BlogAuthor,
            BlogContent = dataModel.BlogContent
        };
    }

    public static TblBlog Change(this BlogRequestModel requestModel)
    {
        return new TblBlog
        {
            BlogTitle = requestModel.BlogTitle,
            BlogAuthor = requestModel.BlogAuthor,
            BlogContent = requestModel.BlogContent
        };
    }
}
