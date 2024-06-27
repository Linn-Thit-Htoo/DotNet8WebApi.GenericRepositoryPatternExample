using DotNet8WebApi.GenericRepositoryPatternExample.DbService.AppDbContexts;
using DotNet8WebApi.GenericRepositoryPatternExample.Models.Enums;
using DotNet8WebApi.GenericRepositoryPatternExample.Models.Features;
using DotNet8WebApi.GenericRepositoryPatternExample.Models.Resources;
using Microsoft.EntityFrameworkCore;

namespace DotNet8WebApi.GenericRepositoryPatternExample.Repositories.Features.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _table;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public async Task<Result<T>> GetListAsync()
        {
            Result<T> responseModel;
            try
            {
                var lst = await _table.ToListAsync();
                responseModel = Result<T>.SuccessResult(lst);
            }
            catch (Exception ex)
            {
                responseModel = Result<T>.FailureResult(ex);
            }

            return responseModel;
        }

        public async Task<Result<T>> GetListOrderByDescAsync<TKey>(Func<T, TKey> orderBySelector)
        {
            Result<T> responseModel;
            try
            {
                var lst = await _table.ToListAsync();
                responseModel = Result<T>.SuccessResult(lst.OrderByDescending(orderBySelector).ToList());
            }
            catch (Exception ex)
            {
                responseModel = Result<T>.FailureResult(ex);
            }

            return responseModel;
        }

        public async Task<Result<T>> GetByIdAsync(int id)
        {
            Result<T> responseModel;
            try
            {
                var item = await _table.FindAsync(id);
                if (item is null)
                {
                    responseModel = Result<T>.FailureResult(MessageResource.NotFound, EnumStatusCode.NotFound);
                    goto result;
                }

                List<T> lst = new() { item };
                responseModel = Result<T>.SuccessResult(lst);
            }
            catch (Exception ex)
            {
                responseModel = Result<T>.FailureResult(ex);
            }

        result:
            return responseModel;
        }

        public async Task<Result<T>> AddAsync(T requestModel)
        {
            Result<T> responseModel;
            try
            {
                await _context.Set<T>().AddAsync(requestModel);
                int result = await _context.SaveChangesAsync();

                responseModel = Result<T>.ExecuteResult(result, successStatusCode: EnumStatusCode.Created);
            }
            catch (Exception ex)
            {
                responseModel = Result<T>.FailureResult(ex);
            }

            return responseModel;
        }

        public async Task<Result<T>> UpdateAsync(T requestModel, int id)
        {
            Result<T> responseModel;
            try
            {
                var item = await _table.FindAsync(id);
                if (item is null)
                {
                    responseModel = Result<T>.FailureResult(MessageResource.NotFound, EnumStatusCode.NotFound);
                    return responseModel;
                }

                var properties = typeof(T).GetProperties();
                foreach (var property in properties)
                {
                    var newValue = property.GetValue(requestModel);
                    if (newValue is not null)
                    {
                        property.SetValue(item, newValue);
                    }
                }

                _table.Update(item);
                int result = await _context.SaveChangesAsync();

                responseModel = Result<T>.ExecuteResult(result, successStatusCode: EnumStatusCode.Accepted);
            }
            catch (Exception ex)
            {
                responseModel = Result<T>.FailureResult(ex);
            }

            return responseModel;
        }

        public async Task<Result<T>> DeleteAsync(int id)
        {
            Result<T> responseModel;
            try
            {
                var item = await _table.FindAsync(id);
                if (item is null)
                {
                    responseModel = Result<T>.FailureResult(MessageResource.NotFound, EnumStatusCode.NotFound);
                    goto result;
                }

                _table.Remove(item);
                int result = await _context.SaveChangesAsync();

                responseModel = Result<T>.ExecuteResult(result, successStatusCode: EnumStatusCode.Accepted);
            }
            catch (Exception ex)
            {
                responseModel = Result<T>.FailureResult(ex);
            }

        result:
            return responseModel;
        }
    }
}
