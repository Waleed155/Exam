using Exam.Models;

namespace Exam.IRepositories
{
    public interface ICourseStudentRepository
    {
        public IQueryable<StudentCourse> GetCoursesForStudent(int id);

    }
}
