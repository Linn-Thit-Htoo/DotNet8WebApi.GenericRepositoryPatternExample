namespace DotNet8WebApi.GenericRepositoryPatternExample.Api.Features.Student
{
    public class BL_Student
    {
        private readonly IGenericRepository<TblStudent> _genericRepository;

        public BL_Student(IGenericRepository<TblStudent> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<Result<TblStudent>> GetStudentList()
        {
            Result<TblStudent> responseModel;
            try
            {
                responseModel = await _genericRepository.GetListOrderByDescAsync(x => x.StudentId);
            }
            catch (Exception ex)
            {
                responseModel = Result<TblStudent>.FailureResult(ex);
            }

            return responseModel;
        }
    }
}
