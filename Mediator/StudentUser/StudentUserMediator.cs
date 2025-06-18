using Exam.Dto.StudentDto;
using Exam.Dto.StudentUserDto;
using Exam.Dto.UserDto;
using Exam.Helper;
using Exam.Service.StudentService;
using Exam.Service.UserService;


namespace Exam.Mediator.StudentUser
{
    public class StudentUserMediator:IStudentUserMediator
    {
        IUserService  _userService;
        IStudentServise _studentServise;

        public StudentUserMediator(IUserService userService,
        IStudentServise studentServise) {
        _userService=userService;
            _studentServise=studentServise;
        }
        public StudentUserDto Add(StudentUserDto studentUserDto)
        {
            var studentDto = studentUserDto.Mapone<StudentDto>();
            var studentEdiDto = _studentServise.Add(studentDto);
            var userDto = studentUserDto.Mapone<UserDto>();
            userDto.StudentId=studentEdiDto.Id;
         var userStudentDto=   _userService.RegisterStudent(userDto);
            return userStudentDto.Mapone<StudentUserDto>();



        }
    }
}
