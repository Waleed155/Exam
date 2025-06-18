using Exam.IRepositories;
using Exam.Models;
using Microsoft.EntityFrameworkCore;

namespace Exam.Repository
{
    public class Repository<T>:IRepository<T> where T : BasicModel
    {
        DbContext _dbContext;
        public Repository(DbContext dbContext) { 
        _dbContext= dbContext;
        }

        public IQueryable<T> GetAll()
        {
            return _dbContext.
                Set<T>().Where(entity=>entity.IsDeleted==false);
        }
        public T GetById(int id)
        {
            
        return _dbContext.Set<T> ().
       FirstOrDefault (entity => entity.
       Id == id && entity.
       IsDeleted == false);
            
            }
        public int Get(T entity) {
            var c = _dbContext.Set<T>().OrderBy<T, int>(entity => entity.Id).Last();
            return c.Id;
        }
        public T Add(T entity)
        {
                _dbContext.Set<T>().Add(entity);
            return entity;
        }
        public T Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            return GetById(entity.Id);
        }
        public bool DeleteById(int id)
        {
            try
            {
                T entityDeleted = GetById(id);
                entityDeleted.IsDeleted = true;
                return true;
            }
            catch (Exception ) {
                
                return false;
                   }
        }
        public T Delete(T _entity) {
            _dbContext.
                Set<T>().
                FirstOrDefault
 (entity => entity.Id == _entity.Id && !_entity.IsDeleted).
 IsDeleted = true;
        return _entity;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
