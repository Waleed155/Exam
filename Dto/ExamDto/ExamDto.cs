 using Exam.Models;

namespace Exam.Dto.ExamDto
{
    public class ExamDto
    {
        public string Name { get; set; }
        public int Time { get; set; }
        public DateTime StartTime { get; set; }

        public ExamLevel ExamLevel { get; set; }
        public int TotalGrade { get; set; }
        public int CourseId { get; set; }
    }
}
