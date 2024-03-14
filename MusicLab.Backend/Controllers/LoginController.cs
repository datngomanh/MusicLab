using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MusicLab.Repository;
using MusicLab.Repository.Models;
using MusicLab.Repository.Models.RequestModel;
using MusicLab.Repository.Models.ResponseModel;
using MusicLab.Repository.Repositories.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MusicLab.Backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public LoginController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _userRepository = unitOfWork.UserRepository;
            _configuration = configuration;
        }

        [HttpPost("/api/login")]
        public async Task<IActionResult> Login(LoginRequestModel entity)
        {
            var user = _userRepository.Find(x => x.Username.Equals(entity.Username) && x.Password.Equals(entity.Password))
                .FirstOrDefault();
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                var token = GenerateToken(user);
                return Ok(new LoginResponseModel
                {
                    Token = token,
                    User = user,
                });
            }
        }

        private string GenerateToken(User user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(_configuration["JWTToken:SecretKey"]);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name, user.FullName),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim("Username", user.Username)
                    }
                ),
                Expires = DateTime.UtcNow.AddDays(1000),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes),
                    SecurityAlgorithms.HmacSha256)
            };
            var token = jwtTokenHandler.CreateToken(tokenDescription);
            return jwtTokenHandler.WriteToken(token);
        }
    }
}
