 using System.ComponentModel.DataAnnotations.Schema;

namespace Exam.Models
{
    public class QuestionChoice:BasicModel
    {

        public bool IsCorrect { get; set; }=false;
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        [ForeignKey("Choice")]
        public int ChoiceId { get; set; }
    
        public Question ? Question { get; set; }
        public Choice ? Choice { get; set; }

    }
}
