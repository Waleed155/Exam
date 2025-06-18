using Exam.Dto;
using Exam.Dto.ExamDto;
using Exam.Models;
using Exam.Service;
using Exam.ViewModels.ExamViewModel.ExamViewModel;
using Exam.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Exam.ViewModels.ChoiceViewModel;
using Exam.Helper;
using Microsoft.AspNetCore.Authorization;
using Exam.Filters;
using Exam.Service.ChoicesService;

namespace Exam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChoiceController : ControllerBase
    {
        IChoiceService _service;
        public ChoiceController(IChoiceService service)
        {
_service = service;
        }


        [HttpGet]
        [Authorize]
        [TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.CreateExam })]
        public ResultViewModel<IEnumerable<ChoiceViewModel>> GetAll()
        {
            return ResultViewModel<IEnumerable<ChoiceViewModel>>.
                Success(_service.GetAll().MapList<ChoiceViewModel>().
                ToList());

        }
        [HttpGet("id:int")]
        public ResultViewModel<ChoiceViewModel> GetById(int id)
        {

            return ResultViewModel<ChoiceViewModel>.
                    Success(_service.
                    GetById(id).Mapone<ChoiceViewModel>());
        }
        [HttpPost]
        public ResultViewModel<ChoiceViewModel> Add(ChoiceViewModel choiceviewmodel)
        {
            var choicedto = choiceviewmodel.Mapone<ChoiceDto>();
            return ResultViewModel<ChoiceViewModel>.
                Add(_service.Add(choicedto).Mapone<ChoiceViewModel>());
        }
        [HttpPut]
        public ResultViewModel<ChoiceViewModel> Update(ChoiceEditViewModel choiceeditviewmodel)
        {
            var choiceeditdto = choiceeditviewmodel.Mapone<ChoiceEditDto>();
            var result = _service.Update(choiceeditdto).Mapone<ChoiceEditViewModel>();
            return ResultViewModel<ChoiceViewModel>.Success(result.Mapone<ChoiceViewModel>());

        }
        [HttpDelete]
        public ResultViewModel<ChoiceViewModel> DeleteById(int id)
        {
            var result = _service.DeleteById(id).Mapone<ChoiceViewModel>();
            return ResultViewModel<ChoiceViewModel>.Success(result);

        }
    }
}
