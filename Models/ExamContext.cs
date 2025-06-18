using System;
using Microsoft.EntityFrameworkCore;
namespace Exam.Models
{
    public class ExamContext:DbContext
    {
        public ExamContext(DbContextOptions options):base(options) 
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseInstructor> CoursesInstructors { get;set; }
        public DbSet<Exam>Exams { get; set; }
        public DbSet<ExamInstructor> ExamsInstructors { get; set; }
        public DbSet<ExamQuestion> ExamSQuestions { get; set; }
        public DbSet<Instructor> Instructors { get; set; }  
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionChoice> QuestionsChoices { get; set; }
        public DbSet<StudentCourse> StudentsCourses { get; set; }
        public DbSet <StudentExam> studentSExams { get; set; } 
        public DbSet<AuthorizeRole> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RoleFeature> RoleFeatures { get; set; }


    }
}
