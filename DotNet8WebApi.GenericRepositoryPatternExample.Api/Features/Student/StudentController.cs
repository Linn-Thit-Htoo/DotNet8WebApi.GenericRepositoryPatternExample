namespace DotNet8WebApi.GenericRepositoryPatternExample.Api.Features.Student;

[Route("api/[controller]")]
[ApiController]
public class StudentController : BaseController
{
    private readonly BL_Student _bL_Student;

    public StudentController(BL_Student bL_Student)
    {
        _bL_Student = bL_Student;
    }

    [HttpGet]
    public async Task<IActionResult> GetStudentList()
    {
        try
        {
            var result = await _bL_Student.GetStudentList();
            return Content(result);
        }
        catch (Exception ex)
        {
            return InternalServerError(ex);
        }
    }
}
