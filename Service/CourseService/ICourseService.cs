using Exam.Dto.CourseDto;
using Exam.Dto.CourseStudentDto;
using Exam.Models;

namespace Exam.Service.CourseService
{
    public interface ICourseService
    {
        public IQueryable<CourseDto> GetAll();


        public CourseDto GetById(int id);


        public CourseDto Add(CourseDto entitydto);


        public CourseDto Update(CourseEditDto editdtoentity);

        public IQueryable<CourseDto> GetCourseForInstructor();
        public IQueryable<CourseStudentDto> GetCourseForStudent();



       public CourseDto DeleteById(int id);
        

    }
}
