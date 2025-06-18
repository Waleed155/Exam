 using System.ComponentModel.DataAnnotations.Schema;

namespace Exam.Models
{
    [Flags]
    public enum ExamLevel
    {
         quiz = 0,
        final =2
            
    }
    public class Exam:BasicModel
    {
        public string Name { get; set; }
        public int  Time {  get; set; }
        public DateTime StartTime { get; set; }

        public ExamLevel ExamLevel { get; set; }
        public int TotalGrade { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course? Course { get; set; }

        public HashSet<ExamInstructor>? ExamInstructors { get; set; }
        public HashSet<ExamQuestion>? ExamQuestions { get; set; }
        public HashSet<StudentExam>? ExamStudents { get; set; }


    }
}
