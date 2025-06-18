using Exam.Models;

namespace Exam.IRepositories
{
    public interface IRoleFeatureRopository
    {
        public bool HasAccess(RoleFeature roleFeature);
    }
}
