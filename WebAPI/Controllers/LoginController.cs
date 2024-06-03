using DomainLayer.Entities;
using DomainLayer.Models;
using InfrastrutureLayer.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly MyDbContext _dbContext;
        private readonly IConfiguration _configuration;
        public static CurrentUser currentUser = new CurrentUser();

        public LoginController(MyDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        [HttpPost]
        public ActionResult<Authenticate> Post(UserDTO request)
        {
            try
            {
                var result = _dbContext.Users.Include(x => x.Role).FirstOrDefault(u => u.Username.Equals(request.UserName));

                if (result == null)
                    return BadRequest("User not found.");

                if (result.IsActive != true)
                    return BadRequest("Account disabled.");

                bool isMatch = BCrypt.Net.BCrypt.Verify(request.Password, result.PasswordHash);

                if (!isMatch)
                    return BadRequest("Wrong password.");
                string token = CreateToken(result);
                currentUser.UserId = result.UserID;

                var response = new
                {
                    jwt = token
                };

                return Ok(response);
            }
            catch (Exception e)
            {

                return BadRequest("Bad request" + e);
            }

        }

        //Generation de token
        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role.RoleName),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
