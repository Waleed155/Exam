using Exam.Dto.RoleDto;
using Exam.Filters;
using Exam.Helper;
using Exam.Models;
using Exam.Service;
using Exam.ViewModels;
using Exam.ViewModels.RoleViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        IService<RoleDto, RoleEditDto, AuthorizeRole> _serv;
        public RoleController(IService<RoleDto, RoleEditDto, AuthorizeRole> serv)
        {
            _serv = serv;
        }

        [HttpGet]
        public ResultViewModel<IEnumerable<RoleViewModel>> GetAll()
        {
            var rolesviewmodel = _serv.GetAll().MapList<RoleViewModel>().ToList();
            return ResultViewModel<IEnumerable<RoleViewModel>>.Success(rolesviewmodel);
        }

        [HttpPost]
        [Authorize]
        [TypeFilter(typeof(CustomizedAuthorizeAttribute), Arguments = new object[] { Feature.ADDRole })]

        public ResultViewModel<RoleViewModel> Add(RoleViewModel roleViewModel)
        {

            var roledto = roleViewModel.Mapone<RoleDto>();
            var addedRole = _serv.Add(roledto).Mapone<RoleViewModel>();
            return ResultViewModel<RoleViewModel>.Success(addedRole);
        }
        }
}
