using Exam.Dto.CourseDto;
using Exam.Models;
using Exam.Service;
using Exam.ViewModels.CourseViewModel;
using Exam.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Exam.Dto.QuestionDto;
using Exam.ViewModels.QuestionViewModel;
using Exam.Helper;

namespace Exam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {

        IService<QuestionDto, QuestionEditDto, Question> _service;
        public QuestionController(IService<QuestionDto, QuestionEditDto, Question> service)
        {
            _service = service;
        }


        [HttpGet]
        public ResultViewModel<IEnumerable<QuestionViewModel>> GetAll()
        {
            return ResultViewModel<IEnumerable<QuestionViewModel>>.
                Success(_service.GetAll().MapList<QuestionViewModel>().ToList());

        }
        [HttpGet("id:int")]
        public ResultViewModel<QuestionViewModel> GetById(int id)
        {

            return ResultViewModel<QuestionViewModel>.
                    Success(_service.
                    GetById(id).Mapone<QuestionViewModel>());
        }
        [HttpPost]
        public ResultViewModel<QuestionViewModel> Add(QuestionViewModel questionviewmodel)
        {
            var questiondto = questionviewmodel.Mapone<QuestionDto>();
            return ResultViewModel<QuestionViewModel>.
                Add(_service.Add(questiondto).Mapone<QuestionViewModel>())
                ;
        }
        [HttpPut]
        public ResultViewModel<QuestionViewModel> Update(QuestionEditViewModel questioneditviewmodel)
        {
            var questioneditdto = questioneditviewmodel.Mapone<QuestionEditDto>();
            var result = _service.Update(questioneditdto).Mapone<QuestionEditViewModel>();
            return ResultViewModel<QuestionViewModel>.Success(result.Mapone<QuestionViewModel>());

        }
        [HttpDelete]
        public ResultViewModel<QuestionViewModel> DeleteById(int id)
        {
            var result = _service.DeleteById(id).Mapone<QuestionViewModel>();
            return ResultViewModel<QuestionViewModel>.Success(result);

        }
    }
}
