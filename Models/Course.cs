namespace Exam.Models
{
    public class Course:BasicModel
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Hours { get; set; }
        
        public HashSet<CourseInstructor>? CourseInstructors { get; set; }
        public HashSet<Exam> ? Exams {  get; set; }
        public HashSet<StudentCourse>? CourseStudents { get; set; }

    }
}
