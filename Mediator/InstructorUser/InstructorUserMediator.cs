using Exam.Service.InstructorService;
using Exam.Service.UserService;
using Exam.ViewModels.InstructorUserViewMdel;

using Exam.Service.StudentService;
using Exam.Helper;
using Exam.Dto;
using Exam.Dto.UserDto;

namespace Exam.Mediator.InstructorUser
{
    public class InstructorUserMediator:IInstructorUserMediator
    {
        public IInstructorService _InstructorService;
        public IUserService _UserService;
        public InstructorUserMediator(IInstructorService InstructorService,
        IUserService UserService) 
            {
            _InstructorService = InstructorService;
            _UserService = UserService;
        }
        public InstructorUserViewModel Add(InstructorUserViewModel instructorUserViewModel)
        {
            var instructorDto = instructorUserViewModel.Mapone<InstructorDto>();
            var instructorEditDto = _InstructorService.Add(instructorDto);
            UserDto userDto =instructorUserViewModel.Mapone<UserDto>();
             userDto.InstructorId=instructorEditDto.Id;
            _UserService.RegisterInstructor(userDto);
            return instructorUserViewModel;


        }
    }
}
