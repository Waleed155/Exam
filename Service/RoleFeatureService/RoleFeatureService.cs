using Exam.Dto.RoleFeatureDto;
using Exam.Helper;
using Exam.IRepositories;
using Exam.Models;
using Exam.Repository;

namespace Exam.Service.RoleFeatureService
{
    public class RoleFeatureService:IRoleFeatureService
    {
        IRepository<RoleFeature> _repo;
        IRoleFeatureRopository _RoleFeatureRepo;
          public RoleFeatureService(IRepository<RoleFeature> repo
              , IRoleFeatureRopository RoleFeatureRepo
)
        {
            _RoleFeatureRepo = RoleFeatureRepo;
            _repo = repo;
        }
        public RoleFeatureDto Add(RoleFeatureDto roleFeatureDto)
        {
            return _repo.
                Add(roleFeatureDto.Mapone<RoleFeature>())
                .Mapone<RoleFeatureDto>();
        }
        public bool HasAccess (RoleFeatureDto roleFeatureDto)
        {
            return _RoleFeatureRepo.
                HasAccess(roleFeatureDto.Mapone<RoleFeature>());
        }
        public IQueryable<RoleFeatureDto> GetAll()
        {
            return _repo.GetAll().MapList<RoleFeatureDto>();     
        }
    }
}
