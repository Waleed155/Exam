using System.ComponentModel.DataAnnotations;

namespace Exam.Models
{
    public class Instructor:BasicModel
    {
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
        public HashSet<ExamInstructor>? InstructorExams { get; set; }
        public HashSet<CourseInstructor>? InstructorCourses { get; set; }
        public HashSet<Question>? Questions { get; set; }
        public HashSet<Choice> ? Choices { get; set; }
        public HashSet<User>? Users { get; set; }


    }
}
