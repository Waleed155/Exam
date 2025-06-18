using System.ComponentModel.DataAnnotations;

namespace Exam.Models
{
    public class Student:BasicModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public HashSet<StudentCourse> ? StudentCourses { get; set; }
        public HashSet <StudentExam>   ? StudentExams { get; set; }
        public HashSet<User>? Users { get; set; }


    }
}
