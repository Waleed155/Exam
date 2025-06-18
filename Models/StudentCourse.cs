using System.ComponentModel.DataAnnotations.Schema;

namespace Exam.Models
{
    public class StudentCourse:BasicModel

    {
        public double StudentDegree { get; set; } = 0;
        [ForeignKey("Student")]
        public int StudentId{ get; set; }
        public Student ? Student { get; set; }
        [ForeignKey("Course")] 
        public int CourseId { get; set; }
        public Course  ? Course { get; set; }
        
    }
}
