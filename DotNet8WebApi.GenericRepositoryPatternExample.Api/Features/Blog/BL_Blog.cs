namespace DotNet8WebApi.GenericRepositoryPatternExample.Api.Features.Blog;

public class BL_Blog
{
    private readonly IGenericRepository<TblBlog> _genericRepository;

    public BL_Blog(IGenericRepository<TblBlog> genericRepository)
    {
        _genericRepository = genericRepository;
    }

    public async Task<Result<TblBlog>> GetBlogs()
    {
        Result<TblBlog> responseModel;
        try
        {
            responseModel = await _genericRepository.GetListOrderByDescAsync(x => x.BlogId);
        }
        catch (Exception ex)
        {
            responseModel = Result<TblBlog>.FailureResult(ex);
        }

        return responseModel;
    }

    public async Task<Result<TblBlog>> GetBlogById(int id)
    {
        Result<TblBlog> responseModel;
        try
        {
            if (id <= 0)
            {
                responseModel = Result<TblBlog>.FailureResult(MessageResource.InvalidId);
                goto result;
            }

            responseModel = await _genericRepository.GetByIdAsync(id);
        }
        catch (Exception ex)
        {
            responseModel = Result<TblBlog>.FailureResult(ex);
        }

        result:
        return responseModel;
    }

    public async Task<Result<TblBlog>> CreateBlog(BlogRequestModel requestModel)
    {
        Result<TblBlog> responseModel;
        try
        {
            responseModel = await _genericRepository.AddAsync(requestModel.Change());
        }
        catch (Exception ex)
        {
            responseModel = Result<TblBlog>.FailureResult(ex);
        }

        return responseModel;
    }

    public async Task<Result<TblBlog>> UpdateBlog(BlogRequestModel requestModel, int id)
    {
        Result<TblBlog> responseModel;
        try
        {
            if (id <= 0)
            {
                responseModel = Result<TblBlog>.FailureResult(MessageResource.InvalidId);
                goto result;
            }

            var model = new TblBlog
            {
                BlogId = id,
                BlogTitle = requestModel.BlogTitle,
                BlogAuthor = requestModel.BlogAuthor,
                BlogContent = requestModel.BlogContent
            };
            responseModel = await _genericRepository.UpdateAsync(model, id);
        }
        catch (Exception ex)
        {
            responseModel = Result<TblBlog>.FailureResult(ex);
        }

        result:
        return responseModel;
    }

    public async Task<Result<TblBlog>> DeleteBlog(int id)
    {
        Result<TblBlog> responseModel;
        try
        {
            if (id <= 0)
            {
                responseModel = Result<TblBlog>.FailureResult(MessageResource.InvalidId);
                goto result;
            }

            responseModel = await _genericRepository.DeleteAsync(id);
        }
        catch (Exception ex)
        {
            responseModel = Result<TblBlog>.FailureResult(ex);
        }

        result:
        return responseModel;
    }
}