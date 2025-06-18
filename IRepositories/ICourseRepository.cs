using Exam.Models;
using Microsoft.EntityFrameworkCore;

namespace Exam.IRepositories
{
    public interface ICourseRepository
    {
        public IQueryable<Course> GetAll();


        public Course GetById(int id);
        int Get(Course entity);
       
        public Course Add(Course entity);

        public Course Update(Course entity);
       
        public bool DeleteById(int id);
       
        public Course Delete(Course _entity);
        

        public void SaveChanges();
        
    }
}
