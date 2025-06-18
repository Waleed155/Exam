using Exam.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam.Dto.QuestionChoiceDto
{
    public class QuestionChoiceDto
    {
        public double QuestionDegree { get; set; } = 0;

        public int InstructorId { get; set; }
        public bool IsCorrect { get; set; } = false;
        public string Name { get; set; }
        public Question_level QuestionLevel { get; set; }
        public List< ChoiceDto> Choices { get; set; }
    }
}
