using Exam.Helper;
using Exam.IRepositories;
using Exam.Models;
using Exam.Repository;
using System.Reflection.Metadata.Ecma335;
using Exam.Dto.StudentDto;
namespace Exam.Service.StudentService
{
    public class StudentService:IStudentServise
    {
        IRepository<Student> _Repo;
        public StudentService(IRepository<Student> repo) {
            _Repo = repo;
        }
        public IQueryable<StudentDto> GetAll()
        {
            return _Repo.GetAll().MapList<StudentDto>();
        }
        public StudentDto GetById(int id)
        {
           return _Repo.GetById(id).Mapone<StudentDto>();
        }
        public StudentEditDto Add(StudentDto entitydto)
        {
            var entity=entitydto.Mapone<Student>();
            _Repo.Add(entity);
            _Repo.SaveChanges();
            var studentEditDto = entity.Mapone<StudentEditDto>();
            return studentEditDto;
        }
        public StudentEditDto Update(StudentEditDto editdtoentity)
        {
            var entity =editdtoentity.Mapone<Student>();

            return _Repo.Update(entity).Mapone<StudentEditDto>();
        }
        public StudentDto DeleteById(int id)
        {
         return   _Repo.DeleteById(id).Mapone<StudentDto>();
        }
    }
}
