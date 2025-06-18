using Exam.Dto;
using Exam.Models;
using System.Text.RegularExpressions;

namespace Exam.Service.ChoicesService
{
    public interface IChoiceService
    {
        public IQueryable<ChoiceDto> GetAll();
        
        public ChoiceDto GetById(int id);
        
        public int Get(ChoiceDto entity);
       

        
        public ChoiceDto Add(ChoiceDto choicedtoentity);
       
        public ChoiceDto Update(ChoiceEditDto choiceditoentity);
        
        public ChoiceDto DeleteById(int id);
        
        public bool Validate(Dto.ChoiceDto entitydto);
        public string GetCurrentInstructorId();




    }
}
