using Exam.Dto.ExamQuestionDto;

namespace Exam.Mediator.ExamQuestion
{
    public interface IExamQuestionMediator
    {
        public void AddExam(ExamQuestionDto entity);
    }
}
