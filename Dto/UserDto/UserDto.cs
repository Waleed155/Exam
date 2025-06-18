using System.ComponentModel.DataAnnotations;

namespace Exam.Dto.UserDto
{
    public class UserDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int? InstructorId { get; set; }
        public int ?StudentId { get; set; }

        public string Email { get; set; }
        public int RoleID { get; set; }

        public string Phone { get; set; }
    }
}
