using Exam.Dto;
using Exam.Models;
using Exam.Service;
using Exam.ViewModels.ChoiceViewModel;
using Exam.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Exam.Dto.StudentDto;
using Exam.ViewModels.StudentViewModel;
using Exam.Helper;

namespace Exam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        IService<StudentDto, StudentEditDto, Student > _service;
        public StudentController(IService<StudentDto, StudentEditDto, Student> service)
        {
            _service = service;
        }


        [HttpGet]
        public ResultViewModel<IEnumerable<StudentViewModel>> GetAll()
        {
            return ResultViewModel<IEnumerable<StudentViewModel>>.
                Success(_service.GetAll().MapList<StudentViewModel>().ToList());

        }
        [HttpGet("id:int")]
        public ResultViewModel<StudentViewModel> GetById(int id)
        {

            return ResultViewModel<StudentViewModel>.
                    Success(_service.
                    GetById(id).Mapone<StudentViewModel>());
        }
        [HttpPost]
        public ResultViewModel<StudentViewModel> Add(StudentViewModel studentviewmodel)
        {
            var studentdto = studentviewmodel.Mapone<StudentDto>();
            return ResultViewModel<StudentViewModel>.
                Add(_service.Add(studentdto).Mapone<StudentViewModel>());
        }
        [HttpPut]
        public ResultViewModel<StudentViewModel> Update(StudentEditViewModel studenteditviewmodel)
        {
            var studenteditdto = studenteditviewmodel.Mapone<StudentEditDto>();
            var result = _service.Update(studenteditdto).Mapone<StudentEditViewModel>();
            return ResultViewModel<StudentViewModel>.Success(result.Mapone<StudentViewModel>());

        }
        [HttpDelete]
        public ResultViewModel<StudentViewModel> DeleteById(int id)
        {
            var result = _service.DeleteById(id).Mapone<StudentViewModel>();
            return ResultViewModel<StudentViewModel>.Success(result);

        }
    }
}
