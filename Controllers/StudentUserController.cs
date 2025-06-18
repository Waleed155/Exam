using Exam.Dto.StudentUserDto;
using Exam.Helper;
using Exam.Mediator.StudentUser;
using Exam.Service.StudentService;
using Exam.ViewModels;
using Exam.ViewModels.StudentUserViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentUserController : ControllerBase
    {
        IStudentUserMediator _studentUserMediator;
        public StudentUserController(IStudentUserMediator studentUserMediator)
        {
        _studentUserMediator = studentUserMediator;
        }
        [HttpPost]
        public ResultViewModel<StudentUserViewModel> Add([FromQuery]StudentUserViewModel studentUserViewModel)
        {
          var studentUserDto  =_studentUserMediator.Add(studentUserViewModel.Mapone<StudentUserDto>());
            return ResultViewModel<StudentUserViewModel>.Success(studentUserDto.Mapone<StudentUserViewModel>());
        }
    }
}
