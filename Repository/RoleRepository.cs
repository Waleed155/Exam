using Exam.IRepositories;
using Exam.Models;
using Microsoft.EntityFrameworkCore;

namespace Exam.Repository
{
    public class RoleRepository:IRoleRepository
    {
        DbContext _dbContext;
        public RoleRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int GetRoleId(string name)
        {
            var role = _dbContext.Set<AuthorizeRole>().FirstOrDefault(u =>
                 !u.IsDeleted && u.RoleName.Contains(name));
            return role.Id;
                
        }
    }
}
