using System.ComponentModel.DataAnnotations;

namespace Exam.Dto
{
    public class InstructorDto
    {
        public string  Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string  Phone { get; set; }
    }
}
