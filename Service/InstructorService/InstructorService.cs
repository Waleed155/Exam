using Exam.Helper;
using Exam.IRepositories;
using Exam.Models;
using Exam.Dto;

using System.Text.RegularExpressions;

namespace Exam.Service.InstructorService
{
    public class InstructorService:IInstructorService
    {
        IRepository<Instructor> _Repo;

        public InstructorService(IRepository<Instructor> repo)
        {
            _Repo = repo;
        }
        public IQueryable<InstructorDto> GetAll()
        {
            return _Repo.GetAll().MapList<InstructorDto>();
        }
        public InstructorDto GetById(int id)
        {
            return _Repo.GetById(id).Mapone<InstructorDto>();
        }
        public InstructorEditDto Add( InstructorDto entityDto)
        {
            var entity=entityDto?.Mapone<Instructor>();
            if (entity is Instructor)
            {
                var instructorEditDto = _Repo.
                    Add(entity).
                    Mapone<InstructorEditDto>();
                _Repo.SaveChanges();
                return entity.Mapone<InstructorEditDto>();
                    
            }
            else
                return entityDto.Mapone<InstructorEditDto>();
        }
        public InstructorDto Update(InstructorEditDto insteditentity)
        {
           Instructor entity =insteditentity.Mapone<Instructor>();
            return _Repo.Update(entity).Mapone<InstructorDto>();    
        }
        public InstructorDto DeleteById(int id)
        {
          return  _Repo.DeleteById(id).Mapone<InstructorDto>();
        }
       

    }
}
