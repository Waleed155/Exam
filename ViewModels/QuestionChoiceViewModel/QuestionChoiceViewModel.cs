using Exam.Dto;
using Exam.Models;
using Exam.ViewModels.ChoiceViewModel;

namespace Exam.ViewModels.QuestionChoiceViewModel
{
    public class QuestionChoiceViewModel
    {
        public double QuestionDegree { get; set; } = 0;

        public int InstructorId {  get; set; }
        public string Name { get; set; }
        public Question_level QuestionLevel { get; set; }
        public List< ChoiceViewModel.ChoiceViewModel> Choices { get; set; }
    }
}
