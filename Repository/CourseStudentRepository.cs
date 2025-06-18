using Exam.IRepositories;
using Exam.Models;
using Microsoft.EntityFrameworkCore;

namespace Exam.Repository
{
    public class CourseStudentRepository:ICourseStudentRepository
    {
        DbContext _Db;
        public CourseStudentRepository(DbContext Db) {
        _Db = Db;
        }
        public IQueryable<StudentCourse> GetCoursesForStudent(int id)
        {
            return _Db.Set<StudentCourse>().Where(Sc => !Sc.IsDeleted && Sc.StudentId == id);
            
        }
    }
}
