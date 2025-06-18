using System.ComponentModel.DataAnnotations.Schema;

namespace Exam.Models
{
    public class CourseInstructor:BasicModel
    {
        [ForeignKey("Course")]
        public int CourseId {  get; set; }
        [ForeignKey("Instructor")]
        public int InstructorId { get; set; }   
        public Course? Course { get; set; }
        public Instructor? Instructor { get; set; }

        
    }
}
