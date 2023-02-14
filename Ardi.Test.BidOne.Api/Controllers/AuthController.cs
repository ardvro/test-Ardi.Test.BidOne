using Ardi.Test.BidOne.Interfaces;
using Ardi.Test.BidOne.Interfaces.Auth.Domain;
using Ardi.Test.BidOne.Interfaces.Auth.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ardi.Test.BidOne.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IUserService _userService;

        public AuthController(ILogger<AuthController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost("register")]
        public object Register(UserRegistration userRegistration)
        {
            if (!ModelState.IsValid)
            {
                if (userRegistration.Password != userRegistration.PasswordConfirm)
                {
                    _logger.LogDebug(UserRegisterCode.InvalidPasswordAndConfirm.ToString());
                    return new { Code = UserRegisterCode.InvalidPasswordAndConfirm.ToString() };
                }
                _logger.LogDebug(UserRegisterCode.Failed.ToString());
                return new { Code = UserRegisterCode.Failed.ToString() };
            }

            var result = _userService.Register(userRegistration);
            return new { Code = result.ToString() };
        }

        [HttpGet("getusers")]
        public List<User> GetUsers()
        {
            var users = _userService.GetUsers();
            return users;
        }

        [HttpGet("get")]
        public IActionResult Get()
        {
            return Ok();
        }

    }
}