using Exam.Dto;
using Exam.IRepositories;
using Exam.Models;

namespace Exam.Service.InstructorService
{
    public interface IInstructorService
    {
       

        public IQueryable<InstructorDto> GetAll();
       
        public InstructorDto GetById(int id);
        
        public InstructorEditDto Add(InstructorDto entityDto);
       
         
        
        public InstructorDto Update(InstructorEditDto insteditentity);


        public InstructorDto DeleteById(int id);
        
    }
}
