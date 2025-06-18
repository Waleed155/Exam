using Exam.Dto.CourseInstructorDto;

namespace Exam.Service.CourseInstructorService
{
    public interface ICourseInstructorService
    {
        public IQueryable<CourseInstructorDto> GetCoursesFprInstructor();
    }
}
