using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam.Models
{
    public class User:BasicModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
        [ForeignKey("AuthorizeRole")]
        public int RoleID { get; set; }
        public AuthorizeRole ? AuthorizeRole { get; set; }
        [ForeignKey("Instructor")]
        public int ? InstructorId { get; set; }
        public Instructor? Instructor { get; set; }
        [ForeignKey("Student")]

        public int ? StudentId { get; set; }
        public Student? Student { get; set; }



    }
}
