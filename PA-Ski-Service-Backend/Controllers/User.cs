using Microsoft.AspNetCore.Mvc;
using SkiServiceBackend.Models;
using SkiServiceBackend.Dtos;
using SkiServiceBackend.Services;

namespace SkiServiceBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationContext _dbContext;
        private readonly ITokenService _tokenService;

        public AuthController(ApplicationContext dbContext, ITokenService tokenService)
        {
            _dbContext = dbContext;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto model)
        {
            var user = _dbContext.AppUsers.FirstOrDefault(u => u.Name == model.UserName);

            if (user == null)
            {
                return BadRequest("Benutzer nicht vorhanden");
            }

            if (user.UserPassword.Equals(model.Password))
            {
                var token = _tokenService.CreateToken(model.UserName);
                return Ok(new { Token = token, Username = user.Name });
            }

            return BadRequest("Ungültige Anmeldedaten");
        }
    }
}
