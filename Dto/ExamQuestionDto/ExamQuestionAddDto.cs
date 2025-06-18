using System.ComponentModel.DataAnnotations.Schema;

namespace Exam.Dto.ExamQuestionDto
{
    public class ExamQuestionAddDto
    {
        public double QuestionDegree { get; set; }
        public int QuestionId { get; set; }
        public int ExamId { get; set; }
    }
}
