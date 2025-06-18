using Exam.IRepositories;
using Exam.Models;
using Microsoft.EntityFrameworkCore;

namespace Exam.Repository
{
    public class RoleFeatureRepository:IRoleFeatureRopository
    { 
        DbContext _dbContext;
        public RoleFeatureRepository(DbContext dbContext)
        {
            _dbContext=dbContext;
        }
         public  bool  HasAccess(RoleFeature roleFeature)
        {
            var roleid = _dbContext.
                Set<RoleFeature>().
                FirstOrDefault(r => !r.IsDeleted
            && r.Feature == roleFeature.Feature &&
            r.AuthorizeRoleId == roleFeature.AuthorizeRoleId);
            if(roleid!=null)
            {
                return true;
            }
            else { return false; }
        }

    }
}
