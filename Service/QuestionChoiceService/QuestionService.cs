using Exam.Controllers;
using Exam.Dto;
using Exam.Dto.QuestionChoiceDto;
using Exam.Dto.QuestionDto;
using Exam.Helper;
using Exam.Models;

namespace Exam.Service.QuestionChoiceService
{
    public class QuestionService:IQuestionService
    {
        IService<QuestionDto, QuestionEditDto, Question> _QuestServ;
        IService<ChoiceDto, ChoiceEditDto, Choice> _ChoiceServ;
        IService<QuestionChoiceAddDto, QuestionChoiceEDitDto, QuestionChoice > _questChoiceServ;


        public QuestionService(
              IService<QuestionDto, QuestionEditDto, Question>
            QuestServ
        ,IService<ChoiceDto, ChoiceEditDto, Choice> ChoiceServ
    , IService<QuestionChoiceAddDto, QuestionChoiceEDitDto, QuestionChoice>
            questChoiceServ) 
        {
        _ChoiceServ= ChoiceServ;
            _QuestServ= QuestServ;
            _questChoiceServ = questChoiceServ;
        }
    
    public void Addrange(QuestionChoiceDto questionChoiceDto)
        {
            QuestionDto questionDto = new QuestionDto() { Name=
                questionChoiceDto.Name,
                QuestionLevel=questionChoiceDto.QuestionLevel,
            InstructorId=questionChoiceDto.InstructorId,
            
            };
            QuestionDto addedquestiondto= _QuestServ.Add(questionDto);
            foreach(var item in questionChoiceDto.Choices)
            {
                ChoiceDto choiceDto = new ChoiceDto
                {
                    InstructorId = questionChoiceDto.InstructorId,
                    Text = item.Text,
                    IsCorrect=item.IsCorrect
                };
                _ChoiceServ.Add(choiceDto);
                QuestionChoiceAddDto questchoiceadddto =
                    new QuestionChoiceAddDto
                    {
                        ChoiceId = _ChoiceServ.Get(choiceDto),
                        QuestionId = _QuestServ.Get(addedquestiondto),
                        IsCorrect = choiceDto.IsCorrect
                    };
                _questChoiceServ.Add(questchoiceadddto);

            }

        }
    
    
    }
}
