using Exam.Models;

namespace Exam.Dto.QuestionDto
{
    public class QuestionDto
    {
        public string Name { get; set; }
        public Question_level QuestionLevel { get; set; }
        public int InstructorId { get; set; }

    }
}
