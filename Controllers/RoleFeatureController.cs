using Exam.Dto.RoleFeatureDto;
using Exam.Helper;
using Exam.Service.RoleFeatureService;
using Exam.ViewModels;
using Exam.ViewModels.RoleFeatureViewModel;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleFeatureController : ControllerBase
    {
         IRoleFeatureService _roleFeatureService;
        public RoleFeatureController(IRoleFeatureService roleFeatureService)
        {
            _roleFeatureService = roleFeatureService;
        }
        [HttpGet]
        public ResultViewModel<IEnumerable<RoleFeatureViewModel>> GetAll() {


            var rolefeatures = _roleFeatureService.
                GetAll().MapList<RoleFeatureViewModel>().ToList();
            return ResultViewModel< IEnumerable<RoleFeatureViewModel>>.Success(rolefeatures);
        }

        [HttpPost]
        public ResultViewModel<RoleFeatureViewModel>
            Add(RoleFeatureViewModel roleFeatureViewModel )
        {
            var viewmodel = _roleFeatureService.
                       Add(roleFeatureViewModel.Mapone<RoleFeatureDto>()).
                       Mapone<RoleFeatureViewModel>();
            return ResultViewModel<RoleFeatureViewModel>.Success(viewmodel);
        }
    }
}
