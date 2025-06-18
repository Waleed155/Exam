using System.ComponentModel.DataAnnotations.Schema;

namespace Exam.Models
{
    public class ExamInstructor:BasicModel
    {
        [ForeignKey("Exam")]
        public int ExamId { get; set; }
        [ForeignKey("Instructor")]
        public int InstructorId { get; set; }
         public Exam ? Exam {  get; set; }
        public Instructor ? Instructor { get; set; }    
    }
}
