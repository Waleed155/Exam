using Exam.Models;
using Exam.Dto;
namespace Exam.Service
{
    public interface IService<T1,T2,T3>
    {
        public IQueryable<T1> GetAll();

        public T1 GetById(int id);
        public int Get(T1 entity);

        public T1 Add(T1 entitydto);

        public T1 Update(T2 editdtoentity);

        public T1 DeleteById(int id);

    }
}
