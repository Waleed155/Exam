using Exam.Dto.CourseInstructorDto;
using Exam.Helper;
using Exam.IRepositories;

namespace Exam.Service.CourseInstructorService
{
    public class CourseInstructorService
    {
        ICourseInstructorRepository _courseInstructorRepository;
        HttpContextAccessor _httpContextAccessor;
        public CourseInstructorService(ICourseInstructorRepository courseInstructorRepository,HttpContextAccessor httpContextAccessor)
        {
            _courseInstructorRepository = courseInstructorRepository;
            _httpContextAccessor = httpContextAccessor;
        }
       

        }
}
