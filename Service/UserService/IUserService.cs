using Exam.Dto;
using Exam.Dto.UserDto;
using Exam.Helper;
using Exam.Models;

namespace Exam.Service.UserService
{
    public interface IUserService
    {

        public UserDto RegisterStudent(UserDto userDto);
        public UserDto RegisterInstructor(UserDto userDto);
        public UserDto RegisterAdmin(UserDto userDto);


        public UserDto Add(UserDto userDto);
        public string Get(GetUserDto getUserDTo);
     
    }
}
