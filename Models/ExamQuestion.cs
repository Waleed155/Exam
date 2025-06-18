using System.ComponentModel.DataAnnotations.Schema;

namespace Exam.Models
{
    public class ExamQuestion:BasicModel
    {
        public double QuestionDegree { get; set; }
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        [ForeignKey("Exam")]
        public int ExamId { get; set; }
        public Question ? Question { get; set; }
        public Exam ?Exam { get; set; }
    }
}
