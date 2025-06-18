using Exam.Dto.QuestionChoiceDto;
using Exam.Models;

namespace Exam.Dto.ExamQuestionDto
{
    public class ExamQuestionDto
    {
        public double QuestionDegree { get; set; }

        public int CourseId { get; set; }

        public string Name { get; set; }
        public int Time { get; set; }
        public DateTime StartTime { get; set; }

        public ExamLevel ExamLevel { get; set; }
        public int TotalGrade { get; set; }

        public List<QuestionChoiceDto.QuestionChoiceDto>questionChoices { get; set; }
    }
}
