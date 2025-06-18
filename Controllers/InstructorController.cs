using Exam.Dto.StudentDto;
using Exam.Models;
using Exam.Service;
using Exam.ViewModels.StudentViewModel;
using Exam.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Exam.Dto;
using Exam.ViewModels.InstructorViewModel;
using Exam.Helper;
using Exam.Service.InstructorService;

namespace Exam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {

      IInstructorService     _service;
        public InstructorController(IInstructorService service)
        {
            _service = service;
        }


        [HttpGet]
        public ResultViewModel<IEnumerable<InstructorViewModel>> GetAll()
        {
            return ResultViewModel<IEnumerable<InstructorViewModel>>.
                Success(_service.GetAll().MapList<InstructorViewModel>().ToList());

        }
        [HttpGet("id:int")]
        public ResultViewModel<InstructorViewModel> GetById(int id)
        {

            return ResultViewModel<InstructorViewModel>.
                    Success(_service.
                    GetById(id).Mapone<InstructorViewModel>());
        }
        [HttpPost]
        public ResultViewModel<InstructorViewModel> Add(InstructorViewModel instructorviewmodel)
        {
            var instructordto = instructorviewmodel.Mapone<InstructorDto>();
            return ResultViewModel<InstructorViewModel>.
                Add(_service.Add(instructordto).Mapone<InstructorViewModel>());
        }
        [HttpPut]
        public ResultViewModel<InstructorViewModel> Update(InstructorEditViewModel instructoreditviewmodel)
        {
            var instructoreditdto = instructoreditviewmodel.Mapone<InstructorEditDto>();
            var result = _service.Update(instructoreditdto).Mapone<StudentEditViewModel>();
            return ResultViewModel<InstructorViewModel>.Success(result.Mapone<InstructorViewModel>());

        }
        [HttpDelete]
        public ResultViewModel<InstructorViewModel> DeleteById(int id)
        {
            var result = _service.DeleteById(id).Mapone<InstructorViewModel>();
            return ResultViewModel<InstructorViewModel>.Success(result);

        }
    }
}
