using System.ComponentModel.DataAnnotations.Schema;

namespace Exam.Dto.QuestionChoiceDto
{
    public class QuestionChoiceAddDto
    {
        public bool IsCorrect { get; set; } = false;
        public int QuestionId { get; set; }
       
        public int ChoiceId { get; set; }

    }
}
