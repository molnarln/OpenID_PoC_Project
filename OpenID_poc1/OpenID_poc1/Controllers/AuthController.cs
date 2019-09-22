using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OpenID_poc1.Services;

namespace OpenID_poc1.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IConfiguration configuration { get; set; }
        private AuthService authService;

        public AuthController(IConfiguration config, AuthService auths)
        {
            this.configuration = config;
            this.authService = auths;
        }

        [Authorize]
        [HttpGet("/auth")]
        public IActionResult Authenticate()
        {
            return Ok(new { emailAdress = authService.GetUserEmail(User) });
        }

        [Authorize]
        [HttpGet("/name")]
        public IActionResult GetName()
        {
            return Ok(new { name = authService.GetUserName(User) });
        }
    }
}
