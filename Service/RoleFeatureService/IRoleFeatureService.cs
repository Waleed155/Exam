using Exam.Dto.RoleFeatureDto;
using Exam.Models;
using Exam.Repository;

namespace Exam.Service.RoleFeatureService
{
    public interface IRoleFeatureService
    {
        public RoleFeatureDto Add(RoleFeatureDto roleFeatureDto);
        public IQueryable<RoleFeatureDto> GetAll();
        public bool HasAccess(RoleFeatureDto roleFeatureDto);
    }
}
