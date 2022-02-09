using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PaymentAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PaymentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserLoginModel userLogin)
        {
            var user = Authenticate(userLogin);

            if (userLogin != null)
            {
                var token = Generate(user);
                return Ok(token);
            };

            return NotFound("User not found");
        }



        private UserModel Authenticate(UserLoginModel userLogin)
        {
            var currentUser = UserConstantsModel.Users.FirstOrDefault(
                ob => ob.UserName.ToLower() == userLogin.UserName.ToLower() && ob.Password == userLogin.Password);
            if (currentUser != null)
            {
                return currentUser;
            }


            return null;

        }

        private string Generate(UserModel user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.UserName),
                new Claim(ClaimTypes.Email,user.EmailAddress),
                new Claim(ClaimTypes.Role,user.RoleName)
            };

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"], 
                _config["Jwt:Audience"], 
                claims, 
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credential);

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
