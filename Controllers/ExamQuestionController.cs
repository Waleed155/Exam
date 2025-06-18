using Exam.Dto.ExamQuestionDto;
using Exam.Helper;
using Exam.Mediator.ExamQuestion;
using Exam.ViewModels;
using Exam.ViewModels.ExamQuestionViewmodel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamQuestionController : ControllerBase
    {
        IExamQuestionMediator _mediator;
        public ExamQuestionController(IExamQuestionMediator mediator)
            {
        _mediator = mediator;
        }
        [HttpPost]
        public ResultViewModel<ExamQuestionViewModel> AddExam(ExamQuestionViewModel examQuestionViewModel)
        {
          _mediator.AddExam(examQuestionViewModel.Mapone<ExamQuestionDto>());

            return ResultViewModel<ExamQuestionViewModel>.
                    Success(examQuestionViewModel);
        }

    }
}
