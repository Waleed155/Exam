using Exam.Models;

namespace Exam.IRepositories
{
    public interface IUserRepository
    {
        public User Add (User user);    
        public User GetUser (User user);
        public void SaveChanges ();
    }
}
