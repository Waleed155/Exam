namespace Exam.Dto.StudentUserDto
{
    public class StudentUserDto
    {

        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int? StudentId { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}
