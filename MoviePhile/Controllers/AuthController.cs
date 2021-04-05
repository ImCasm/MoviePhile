using Application.Common.Interfaces.Auth;
using Application.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MoviePhile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequestDto user)
        {
            return Ok(await _authService.Login(user));
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequestDto user)
        {
            return Ok(await _authService.Register(user));
        }
    }
}
