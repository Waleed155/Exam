using System.ComponentModel.DataAnnotations.Schema;

namespace Exam.Dto.CourseInstructorDto
{
    public class CourseInstructorDto
    {
        public int CourseId { get; set; }
        public int InstructorId { get; set; }
    }
}
