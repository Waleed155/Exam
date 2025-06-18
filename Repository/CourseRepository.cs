using Exam.Models;
using Exam.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Exam.Repository
{
    public class CourseRepository:ICourseRepository
    {

        DbContext _dbContext;
        public CourseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Course> GetAll()
        {
            return _dbContext.
                Set<Course>().Where(entity => entity.IsDeleted == false);
        }
        public Course GetById(int id)
        {

            return _dbContext.Set<Course>().
           FirstOrDefault(entity => entity.
           Id == id && entity.
           IsDeleted == false);

        }
        public int Get(Course entity)
        {
            var c = _dbContext.Set<Course>().OrderBy<Course, int>(entity => entity.Id).Last();
            return c.Id;
        }
        public Course Add(Course entity)
        {
            _dbContext.Set<Course>().Add(entity);
            return entity;
        }
        public Course Update(Course entity)
        {
            _dbContext.Set<Course>().Update(entity);
            return GetById(entity.Id);
        }
        public bool DeleteById(int id)
        {
            try
            {
                Course entityDeleted = GetById(id);
                entityDeleted.IsDeleted = true;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public Course Delete(Course _entity)
        {
            try
            {
                _dbContext.
                    Set<Course>().
                    FirstOrDefault
     (entity => entity.Id == _entity.Id && !_entity.IsDeleted).
     IsDeleted = true;
                return _entity;
            }catch(Exception ex)
            {
                throw new Exception("not found in Db");
            }
        }
        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
