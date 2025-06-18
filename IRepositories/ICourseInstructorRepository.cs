using Exam.Models;

namespace Exam.IRepositories
{
    public interface ICourseInstructorRepository
    {
        public IQueryable<CourseInstructor> GetCoursesInstructorsForInstructor(int id);

    }
}
