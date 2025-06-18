using System.ComponentModel.DataAnnotations.Schema;

namespace Exam.Models
{
    public class StudentExam:BasicModel
    {
        public double StudentDegree { get; set; } 


        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public Student ? Student { get; set; }
        [ForeignKey("Exam")]
        public int ExamID { get; set; }
        public Exam ? Exam { get; set; }    

    }
}
