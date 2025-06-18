using Exam.IRepositories;
using Exam.Models;
using Microsoft.EntityFrameworkCore;

namespace Exam.Repository
{
    public class UserRepository:IUserRepository
    {
        DbContext _db;
    public UserRepository(DbContext db)
        {
           _db = db;
        }
        public User Add(User user)
         {
          _db.Set<User>().Add(user);
            return user;
               
        }
        public User GetUser(User user)
        {
         User User= _db.Set<User>().FirstOrDefault(u=>
          !u.IsDeleted&&
          u.Email==user.Email
        );
            if (User==null)
            {
                return null;
            }
            else
            {
                return User;            }
        }
        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
