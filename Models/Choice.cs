using System.ComponentModel.DataAnnotations.Schema;

namespace Exam.Models
{
    public class Choice:BasicModel
    {
        public string Text { get; set; }
        public HashSet<QuestionChoice>? ChoiceQuestions { get; set; }
        [ForeignKey("Instructor")]
        public int InstructorId { get; set; }
        public Instructor?  Instructor { get; set; }
    }
}
