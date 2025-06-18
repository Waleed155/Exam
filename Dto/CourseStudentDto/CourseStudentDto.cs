using Exam.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam.Dto.CourseStudentDto
{
    public class CourseStudentDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Hours { get; set; }
        public double StudentDegree { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }

    }
}
