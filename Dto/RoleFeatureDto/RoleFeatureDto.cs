using Exam.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam.Dto.RoleFeatureDto
{
    public class RoleFeatureDto
    {
        public Feature Feature { get; set; }
        public int AuthorizeRoleId { get; set; }
    }
}
