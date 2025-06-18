using System.ComponentModel.DataAnnotations;

namespace Exam.ViewModels.InstructorViewModel
{
    public class InstructorViewModel
    {
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
    }
}
