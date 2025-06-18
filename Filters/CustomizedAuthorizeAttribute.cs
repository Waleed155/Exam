using Exam.Dto.RoleFeatureDto;
using Exam.Models;
using Exam.Service.RoleFeatureService;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Identity.Client;
using System.Security.Authentication;
using System.Security.Claims;

namespace Exam.Filters
{
    public class CustomizedAuthorizeAttribute:ActionFilterAttribute 
    {
        IRoleFeatureService _roleFeatureService;
        Feature _feature;
        public CustomizedAuthorizeAttribute(IRoleFeatureService
            roleFeatureService, Feature feature )
        {
            _feature = feature;
            _roleFeatureService = roleFeatureService;
        }
       public override void OnActionExecuting(ActionExecutingContext context) 

        {
            var user = context.HttpContext.User;
            var email = user.FindFirst("Email");
            var RoleId = user.FindFirst("RoleId");
            var Id = user.FindFirst("Id");
            var userName = user.FindFirst("Name");
            var Phone = user.FindFirst("Phone");

            if(string.IsNullOrEmpty(RoleId.Value))
            {
                throw new AuthenticationException();
            }
            var rolefeature = new RoleFeatureDto()
            { Feature = _feature, AuthorizeRoleId = int.Parse(RoleId.Value) };
            bool access = _roleFeatureService.HasAccess(rolefeature);
            if (!access)
            {
                  throw new AuthenticationException("unauthorized"); 
            }
             




        }
       

    }
}
