using Exam.Dto.UserDto;
using Exam.Helper;
using Exam.IRepositories;
using Exam.Models;
using Exam.Service.RoleService;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;

namespace Exam.Service.UserService
{
    public class UserService:IUserService
    {
        IUserRepository _Repo;
        IRoleService _RoleService;
        public UserService(IUserRepository Repo,IRoleService roleService) {
        _Repo = Repo; 
            _RoleService = roleService;
        }
        public UserDto Add(UserDto userDto)
        {
            var check=uservalidate(userDto);
            if (check)
            {
                    var user=_Repo.Add(userDto.Mapone<User>());
                _Repo.SaveChanges();
                return user.Mapone<UserDto>();
            }
            else { throw new Exception("email or pass not valid or email was founded"); }
        }
        public UserDto RegisterStudent(UserDto entityDto) {
            entityDto.RoleID = _RoleService.GetRoleId("Student");
        var check=uservalidate(entityDto);
            if (check)
            {
                var userDto= _Repo.Add(entityDto.Mapone<User>()).Mapone<UserDto>();
                _Repo.SaveChanges();
                return userDto;
            }
            else
            { throw new Exception("check you data "); }
       
            }
        public UserDto RegisterInstructor(UserDto userDto)
        {
            userDto.RoleID = _RoleService.GetRoleId("Instructor");
            var check = uservalidate(userDto);
            if (check)
            {
                var UserDto= _Repo.Add(userDto.Mapone<User>()).Mapone<UserDto>();
                _Repo.SaveChanges();
                return  UserDto;
            }
            else
            { throw new Exception("check you data "); }

        }
        public UserDto RegisterAdmin(UserDto userDto)
        {
            userDto.RoleID = _RoleService.GetRoleId("Admin");
            var check = uservalidate(userDto);
            if (check)
            {

                var User = _Repo.Add(userDto.Mapone<User>());
                _Repo.SaveChanges();
                return userDto.Mapone<UserDto>();
            }
            else
            { throw new Exception("check you data "); }

        }
        public string Get(GetUserDto getUserDTo)
        {
            var user= _Repo.
                GetUser(getUserDTo.Mapone<User>())
                .Mapone<UserEditDto> (); 
            if(user == null)
            {
                return null;
            }
            else
           return
                GenerateTokens.GenerateToken.generateToken(user);

        }
        public bool uservalidate(UserDto userDto)
        {
            var checker = new EmailAddressAttribute();
            var emailUser = checker.IsValid(userDto.Email);
            var passUser= userDto.Password==userDto.ConfirmPassword;
            var user = Get(userDto.Mapone<GetUserDto>());
            if (emailUser && passUser&&user==null) {return true;}
            else return false;
            

        }
    }
}
