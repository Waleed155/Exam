using Exam.Dto.StudentDto;
using Exam.Models;
using Exam.Service;
using Exam.ViewModels.StudentViewModel;
using Exam.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Exam.Dto.CourseDto;
using Exam.ViewModels.CourseViewModel;
using Exam.Helper;
using Microsoft.AspNetCore.Authorization;
using Exam.Filters;
using Exam.Service.CourseService;
using Exam.Service.CourseInstructorService;
using Exam.ViewModels.CourseStudentViewModel;

namespace Exam.Controllers
{
    [Route("api/[controller] / [Action]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        ICourseService _service;
        public CourseController(ICourseService service)
        {
            _service = service;

        }


        [HttpGet]
        public ResultViewModel<IEnumerable<CourseViewModel>> GetAll()
        {
            return ResultViewModel<IEnumerable<CourseViewModel>>.
                Success(_service.GetAll().MapList<CourseViewModel>().ToList());

        }
        [HttpGet]
        [Authorize]
        [TypeFilter(typeof(CustomizedAuthorizeAttribute),Arguments = new object[] { Feature.GetCourseForInstructor})]
        public ResultViewModel<IEnumerable<CourseViewModel>> GetCoursesForInstructor()
        {
            var courseListDto = _service.GetCourseForInstructor();
            if (courseListDto != null)
            {
                var courseListViewModel = courseListDto.MapList<CourseViewModel>().ToList();
                return ResultViewModel<IEnumerable<CourseViewModel>>
                    .Success(courseListViewModel);
            }
            else {
                return ResultViewModel<IEnumerable<CourseViewModel>>
                   .Success(new List<CourseViewModel>());
            }
        }
        [HttpGet]
        [Authorize]
        [TypeFilter(typeof(CustomizedAuthorizeAttribute),Arguments =new object[] {Feature.GetCoursesForStudent})]
        public ResultViewModel<IEnumerable<CourseStudentViewModel>> GetCoursesForStudent()
        {
            var CoursesForStudentListDto = _service.GetCourseForStudent();
            if(CoursesForStudentListDto.LongCount()>0)
            {
                var CoursesForStudentListViewModel = CoursesForStudentListDto.
                  MapList<CourseStudentViewModel>().ToList();
                return ResultViewModel<IEnumerable<CourseStudentViewModel>>.Success(CoursesForStudentListViewModel);
            }
            else
            {
                return ResultViewModel<IEnumerable<CourseStudentViewModel>>.Success(new List<CourseStudentViewModel>());

            }
        }
        [HttpGet("id:int")]
        [Authorize]
        [TypeFilter(typeof(CustomizedAuthorizeAttribute),Arguments =new object[] {Feature.GetCourse})]
        public ResultViewModel<CourseViewModel> GetById(int id)
        {

            return ResultViewModel<CourseViewModel>.
                    Success(_service.
                    GetById(id).Mapone<CourseViewModel>());
        }
        [HttpPost]
        [Authorize]
        [TypeFilter(typeof(CustomizedAuthorizeAttribute),Arguments =new object[] {Feature.CreateCourse})]
        public ResultViewModel<CourseViewModel> Add(CourseViewModel courseviewmodel)
        {
            var coursedto = courseviewmodel.Mapone<CourseDto>();
            return ResultViewModel<CourseViewModel>.
                Add(_service.Add(coursedto).Mapone<CourseViewModel>())
                ;
        }
        [HttpPut]
        [Authorize]
        [TypeFilter(typeof(CustomizedAuthorizeAttribute),Arguments = new object[] {Feature.EditCourse})]
        public ResultViewModel<CourseViewModel> Update(CourseEditViewModel courseeditviewmodel)
        {
            var courseeditdto = courseeditviewmodel.Mapone<CourseEditDto>();
            var result = _service.Update(courseeditdto).Mapone<CourseEditViewModel>();
            return ResultViewModel<CourseViewModel>.Success(result.Mapone<CourseViewModel>());

        }
        [HttpDelete]
        [Authorize]
        [TypeFilter(typeof(CustomizedAuthorizeAttribute),Arguments =new object[] {Feature.DeleteCourse})]
        public ResultViewModel<CourseViewModel> DeleteById(int id)
        {
            var result = _service.DeleteById(id).Mapone<CourseViewModel>();
            return ResultViewModel<CourseViewModel>.Success(result);

        }
    }
}
