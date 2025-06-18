using Exam.Dto.RoleDto;
using Exam.Helper;
using Exam.IRepositories;
using Exam.Models;

namespace Exam.Service.RoleService
{
    public class RoleService<T1, T2, T3> :IService<T1, T2, T3>,IRoleService
    {
        IRoleRepository _roleRepo;
        IRepository<T3> _repository;
        public RoleService(IRepository<T3> repository, 
            IRoleRepository roleRepo)
        {
            _repository = repository;
            _roleRepo= roleRepo;
        }
        public IQueryable<T1> GetAll()
        {
            return _repository.GetAll().MapList<T1>();
        }

        public T1 GetById(int id)
        {
            return _repository.GetById(id).Mapone<T1>();    
        }
        public int Get(T1 entity)
        {
            return _repository.Get(entity.Mapone<T3>());
        }

        public T1 Add(T1 entitydto)
        {
            return _repository.Add(entitydto.Mapone<T3>()).Mapone<T1>();    
        }

        public T1 Update(T2 editdtoentity)
        {
            return _repository.
                Update(editdtoentity.Mapone<T3>()).Mapone<T1>();
        }

        public T1 DeleteById(int id)
        {
             return _repository.DeleteById(id).Mapone<T1>();
        }


        public int GetRoleId(string name)
        {
            return _roleRepo.GetRoleId(name);
        }


    }
}
