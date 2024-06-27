namespace DotNet8WebApi.GenericRepositoryPatternExample.Repositories.Features.GenericRepository;

public interface IGenericRepository<T> where T : class
{
    Task<Result<T>> GetListAsync();
    Task<Result<T>> GetListOrderByDescAsync<TKey>(Func<T, TKey> orderBySelector);
    Task<Result<T>> GetByIdAsync(int id);
    Task<Result<T>> AddAsync(T requestModel);
    Task<Result<T>> UpdateAsync(T requestModel, int id);
    Task<Result<T>> DeleteAsync(int id);
}