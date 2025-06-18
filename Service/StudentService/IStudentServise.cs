using Exam.Dto.StudentDto;
using Exam.Models;

namespace Exam.Service.StudentService
{
    public interface IStudentServise
    {
        public IQueryable<StudentDto> GetAll();
        
        public StudentDto GetById(int id);


        public StudentEditDto Add(StudentDto entitydto);


        public StudentEditDto Update(StudentEditDto editdtoentity);


        public StudentDto DeleteById(int id);
        
    }
}
