using Exam.Models;

namespace Exam.ViewModels.ExamViewModel.ExamViewModel
{
    public class ExamViewModel
    {
        public string Name { get; set; }
        public int Time { get; set; }
        public DateTime StartTime { get; set; }=DateTime.Now;

        public ExamLevel ExamLevel { get; set; }
        public int TotalGrade { get; set; }
    }
}
