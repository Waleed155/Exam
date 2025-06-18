using Exam.Dto.QuestionChoiceDto;
using Exam.Helper;
using Exam.Service.QuestionChoiceService;
using Exam.ViewModels;
using Exam.ViewModels.QuestionChoiceViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionChoiceController : ControllerBase
    {
        IQuestionService _serv;
        public QuestionChoiceController(IQuestionService serv)
        {
            _serv = serv;
        }
        [HttpPost]
        public ResultViewModel<QuestionChoiceViewModel> AddRange ( QuestionChoiceViewModel questionChoiceViewModel )
        {
        
            var questionChoicedto=questionChoiceViewModel.Mapone<QuestionChoiceDto>();
            _serv.Addrange(questionChoicedto);
            return  ResultViewModel<QuestionChoiceViewModel>.
      Success(questionChoicedto.Mapone<QuestionChoiceViewModel>());
        }
            }
}
