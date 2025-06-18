using Exam.Dto.QuestionChoiceDto;
using Exam.Models;
using Exam.ViewModels.QuestionChoiceViewModel;

namespace Exam.ViewModels.ExamQuestionViewmodel
{
    public class ExamQuestionViewModel
    {
 
        public int CourseId { get; set; }

        public string Name { get; set; }
        public int Time { get; set; }
        public DateTime StartTime { get; set; }

        public ExamLevel ExamLevel { get; set; }
        public int TotalGrade { get; set; }

        public List<QuestionChoiceViewModel.QuestionChoiceViewModel> questionChoices { get; set; }
    }
}
