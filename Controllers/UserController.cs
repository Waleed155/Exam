 using Exam.Dto.UserDto;
using Exam.Filters;
using Exam.Helper;
using Exam.Models;
using Exam.Service;
using Exam.Service.UserService;
using Exam.ViewModels;
using Exam.ViewModels.UserViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        IUserService _usersevice;
        public UserController(
             IUserService usersevice)
        { 
            _usersevice = usersevice;
        }
        [HttpGet]
        public ResultViewModel<string> Get([FromQuery] GetUserViewModel getuserviewmodel)
        {
            var userdto=_usersevice.Get(getuserviewmodel.Mapone<GetUserDto>());
            return ResultViewModel<string>.Success(userdto);   
             
        }
        [HttpPost]
        [Authorize]

        [TypeFilter(typeof(CustomizedAuthorizeAttribute),Arguments =new object []{ Feature.AddAmin})]
        public ResultViewModel<UserViewModel> AddAdmin ([FromQuery] UserViewModel userViewModel)
        {
          var userDto=  _usersevice.RegisterAdmin(userViewModel.Mapone<UserDto>());
       return ResultViewModel<UserViewModel>.Success(userDto.Mapone<UserViewModel>());
        }
    
    }
}
