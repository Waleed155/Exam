using Exam.Dto.ExamDto;
using Exam.Dto.ExamQuestionDto;
using Exam.Dto.QuestionChoiceDto;
using Exam.Dto.QuestionDto;
using Exam.Helper;
using Exam.Models;
using Exam.Service;
using Exam.Service.QuestionChoiceService;
using Microsoft.OpenApi.Models;

namespace Exam.Mediator.ExamQuestion
{
    public class ExamQuestionMediator:IExamQuestionMediator
    {
        IService<QuestionDto, QuestionEditDto, Question> _QuestServ;
            
        IService<ExamQuestionAddDto, ExamQuestionEditDto, Models.ExamQuestion> _examquestionserv;
           IService<ExamDto, ExamEditDto, Models.Exam> _examserv;
        IQuestionService _questionChoiceServ;
   public ExamQuestionMediator(
IService<ExamQuestionAddDto, ExamQuestionEditDto, Models.ExamQuestion> examquestionserv,
   IService<ExamDto, ExamEditDto, Models.Exam> examserv,
           IQuestionService questionChoiceServ ,
           IService<QuestionDto, QuestionEditDto, Question> QuestServ)
        {
            _examquestionserv = examquestionserv;
            _examserv = examserv;
            _questionChoiceServ = questionChoiceServ;
            _QuestServ = QuestServ;
        }
        public void 
            AddExam(ExamQuestionDto examQuestionDto)
        {
            ExamDto exam = new ExamDto { 
            ExamLevel=examQuestionDto.ExamLevel,
            StartTime=examQuestionDto.StartTime,
            Name=examQuestionDto.Name,
            Time=examQuestionDto.Time,
            TotalGrade=examQuestionDto.TotalGrade,
            CourseId=examQuestionDto.CourseId,
            };
           var examdto=_examserv.Add(exam);
         int idAddedExam =  _examserv.Get(examdto);
            foreach (var item in examQuestionDto.questionChoices)
            {
                _questionChoiceServ.Addrange(item);
                ExamQuestionAddDto examQuestionAddDto = new ExamQuestionAddDto
                {
                    QuestionId = _QuestServ.Get(examQuestionDto.Mapone<QuestionDto>()),
                    ExamId = idAddedExam,
                    QuestionDegree = item.QuestionDegree,
                };
                _examquestionserv.Add(examQuestionAddDto);
            }
        }
            }
}
