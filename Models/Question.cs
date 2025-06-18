using System.ComponentModel.DataAnnotations.Schema;

namespace Exam.Models
{
    [Flags]
    public enum Question_level
    {
        simple
            ,hard,medium
    }

    public class Question:BasicModel
    {
        public string Name { get; set; }
        public Question_level QuestionLevel { get; set; }
        [ForeignKey("Instructor")]
        public int InstructorId { get; set; }
        public Instructor? Instructor { get; set; }
       
        public HashSet<QuestionChoice> ? QuestionChoices { get; set; }
        public HashSet<ExamQuestion>? QuestionExams { get; set; }



    }
}
