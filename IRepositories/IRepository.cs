using Exam.Models;
using Microsoft.Identity.Client;

namespace Exam.IRepositories

{
    public interface IRepository<T>
    {
        public IQueryable<T> GetAll();
        public T GetById(int id);
         public int Get(T entity);
        public T Add(T entity);
        public T Update(T entity);
        public bool DeleteById(int id);
        public T Delete(T _entity);
        public void SaveChanges();

    }
}
