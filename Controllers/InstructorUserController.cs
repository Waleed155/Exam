using Exam.Mediator.InstructorUser;
using Exam.ViewModels;
using Exam.ViewModels.InstructorUserViewMdel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorUserController : ControllerBase
    {
        IInstructorUserMediator _mediator;
        public InstructorUserController(IInstructorUserMediator mediator) {
        _mediator = mediator;
        }

        [HttpPost]
        public ResultViewModel<InstructorUserViewModel> Add (InstructorUserViewModel instructorUserViewModel)
        {
            return ResultViewModel<InstructorUserViewModel>.
                   Success(_mediator.Add(instructorUserViewModel));
        }

    }
}
