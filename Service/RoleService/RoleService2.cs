using Exam.Dto.RoleDto;
using Exam.Helper;
using Exam.IRepositories;
using Exam.Models;
using Exam.ViewModels.RoleFeatureViewModel;

namespace Exam.Service.RoleService
{
    public class RoleService2: IRoleService
    {
        IRoleRepository _roleRepo;
        IRepository<Models.AuthorizeRole> _repository;
        public RoleService2(IRepository<AuthorizeRole> repository, 
            IRoleRepository roleRepo)
        {
            _repository = repository;
            _roleRepo= roleRepo;
        }
     

        


        public int GetRoleId(string name)
        {
            return _roleRepo.GetRoleId(name);
        }


    }
}
