using Exam.Models;
using Exam.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Exam.Repository
{
    public class CourseInstructorRepository:ICourseInstructorRepository
    {
        DbContext _db;

        public CourseInstructorRepository(
        DbContext db) {
            _db = db;
        }
        public IQueryable<CourseInstructor> GetCoursesInstructorsForInstructor(int id) {
        var courseslist=_db.Set<CourseInstructor>().Where(c=>c.InstructorId==id&&!c.IsDeleted);   
       return courseslist;
        }
        

    }
}
