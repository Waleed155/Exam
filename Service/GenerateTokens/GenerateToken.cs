using Exam.Dto.UserDto;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Exam.Service.GenerateTokens
{
    public static
        class GenerateToken
    {
        public static string generateToken(UserEditDto userDto)
        {

            #region Define claims
            List<Claim> userData = new List<Claim>() { };
            userData.Add(new Claim("Email", userDto.Email));
            userData.Add(new Claim("RoleId", userDto.RoleID.ToString()));
            userData.Add(new Claim("Phone", userDto.Phone));
            userData.Add(new Claim("Id", userDto.Id.ToString()));
            userData.Add(new Claim("Name", userDto.UserName));
            userData.Add(new Claim("InstructorId", userDto.InstructorId.ToString()));
            userData.Add(new Claim("StudentId", userDto.StudentId.ToString()));





            #endregion
            #region  secret Key
            string key =
"masr gamila geda 5als ya 7omsany kan m3kmwaled beeh abooelnasr 5alek faker ya ebny tamtam tamam tamam trump";
            var secretKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(key));
            
                #endregion
            #region define Token
            var signcer=new SigningCredentials
                (secretKey,SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                claims: userData,
                signingCredentials: signcer,
                expires: DateTime.Now.AddMinutes(30));

            var encoddedtoken = new JwtSecurityTokenHandler().WriteToken(token);
           return encoddedtoken;
            #endregion

        }

    }
}

