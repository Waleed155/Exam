using Exam.Dto;

using Exam.Exceptions;
using Exam.Helper;
using Exam.IRepositories;
using Exam.Models;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace Exam.Service.ChoicesService
{
    public class ChoiceService:IChoiceService
    {
        IHttpContextAccessor _contextAccessor;
        IRepository<Choice> _Repo;
        public ChoiceService(IRepository<Choice> repo,
        IHttpContextAccessor contextAccessor)
        {
            _Repo = repo;
            _contextAccessor = contextAccessor;
        }
        public IQueryable<ChoiceDto> GetAll()
        {
            var instructorId=int.Parse(GetCurrentInstructorId());
            return _Repo.
                GetAll().
                MapList<ChoiceDto>().
                Where(c => c.InstructorId == instructorId);
        }
        public ChoiceDto GetById(int id)
        {
            var instructorId = int.Parse(GetCurrentInstructorId());

            return _Repo.GetById(id).Mapone<ChoiceDto>();

        }
        public int Get(ChoiceDto entity) 
        {
            try
            {
                var c = _Repo.Get(entity.Mapone<Choice>());
                return c;
            }
            catch (Exception ex) {
                throw ex;
            }
              
        }
        public ChoiceDto Add(ChoiceDto choicedtoentity)
        {
            
                Choice entity = choicedtoentity.Mapone<Choice>();
                return _Repo.Add(entity).Mapone<ChoiceDto>();
           
        }
        public ChoiceDto Update(ChoiceEditDto choiceditoentity) {

            
                Choice entity = choiceditoentity.Mapone<Choice>();
                return _Repo.Update(entity).Mapone<ChoiceDto>();
            
            
        }
        public ChoiceDto DeleteById(int id) {
            return _Repo.DeleteById(id).Mapone<ChoiceDto>();
        
        }
        public bool Validate(Dto.ChoiceDto entitydto)
        {
            
            var text = entitydto.Text;
            if (!Regex.IsMatch(text, @"(^\s)") )
            {
                return true;
                
            }
            else
                return false;

        }
        public string GetCurrentInstructorId()
        {
       var instid= _contextAccessor.HttpContext?.User.FindFirst("InstructorId").Value;
            return instid ?? throw new UnauthorizedAccessException("instructorid not exist");
        }

    }
}
