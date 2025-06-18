using Exam.Dto;
using Exam.Helper;
using Exam.IRepositories;
using Exam.Models;

namespace Exam.Service
{
    public class Service<T1, T2, T3> :IService<T1, T2, T3>
    {
        IRepository<T3> _Repo;
        public Service(IRepository<T3> repo)
        {
            _Repo = repo;

        }
        public IQueryable<T1> GetAll()
        {
            return _Repo.GetAll().MapList<T1>();
        }
        public int Get(T1 entity)
        {
            try
            {
                var c = _Repo.Get(entity.Mapone<T3>());
                return c;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public T1 GetById(int id)
        {
            return _Repo.GetById(id).Mapone<T1>();
        }
        public T1 Add(T1 dtoentity)
        {

            T3 entity = dtoentity.Mapone<T3>();
            var returnadd=_Repo.Add(entity);
            _Repo.SaveChanges();
            return returnadd.Mapone<T1>();

        }
        public T1 Update(T2 editdtoentity)
        {


            T3 entity = editdtoentity.Mapone<T3>();
            return _Repo.Update(entity).Mapone<T1>();


        }
        public T1 DeleteById(int id)
        {
            return _Repo.DeleteById(id).Mapone<T1>();

        }

    }
}
