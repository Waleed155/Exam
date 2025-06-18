using Exam.Dto.ExamDto;
using Exam.Models;
using Exam.Helper;
using Exam.Service;
using Exam.ViewModels;
using Exam.ViewModels.ExamViewModel.ExamViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        IService <ExamDto, ExamEditDto,Exam.Models.Exam> _Servise;
        public ExamController(IService<ExamDto, ExamEditDto, Exam.Models.Exam> Servise) {
        _Servise = Servise;
        }
        [HttpGet]
        public ResultViewModel<IEnumerable<ExamViewModel>> GetAll() {


            return ResultViewModel<IEnumerable<ExamViewModel>>.
                Success(_Servise.GetAll().MapList<ExamViewModel>().ToList());

        }
        [HttpGet("id:int")]
        public ResultViewModel<ExamViewModel> GetById(int id) {
        
        return ResultViewModel<ExamViewModel>.
                Success(_Servise.
                GetById(id).Mapone<ExamViewModel>());
        }
        [HttpPost]
        public ResultViewModel<ExamViewModel> Add(ExamViewModel examviewmodel)
        { 
        var examdto=examviewmodel.Mapone<ExamDto>();
            return ResultViewModel<ExamViewModel>.
                Add(_Servise.Add(examdto).Mapone<ExamViewModel>());
        }
        [HttpPut]
        public ResultViewModel<ExamViewModel> Update(ExamEditViewModel exameditviewmodel)
        { 
            var exameditdto=exameditviewmodel.Mapone<ExamEditDto>();
            var result=_Servise.Update(exameditdto).Mapone<ExamEditViewModel>();
            return ResultViewModel<ExamViewModel>.Success(result.Mapone<ExamViewModel>());
        
        }
        [HttpDelete]
        public ResultViewModel<ExamViewModel> DeleteById(int id)
        {
            var result = _Servise.DeleteById(id).Mapone<ExamViewModel>();
            return ResultViewModel<ExamViewModel>.Success(result);

        }

    }
}
