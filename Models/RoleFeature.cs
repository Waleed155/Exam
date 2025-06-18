using System.ComponentModel.DataAnnotations.Schema;

namespace Exam.Models
{
    public class RoleFeature:BasicModel
    {
        public Feature Feature { get; set; }
        [ForeignKey( "AuthorizeRole")]
        public int AuthorizeRoleId { get; set; }
        public AuthorizeRole? AuthorizeRole { get; set; }
    }
}
