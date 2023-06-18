using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FQ.Server.Controllers
{
    public class UserRegistrationPost
    {
        public string username { set; get; }
        public string password { set; get; }
    }

    [ApiController]
    [Route("[controller]")]
    public class AuthorizationController : Controller
    {
        private readonly ILogger<RealmStatus> _logger;
        private readonly UserHandler _userHandler;
        private readonly RealmStatus _realmStatus;

        public AuthorizationController(ILogger<RealmStatus> logger, UserHandler userHandler, RealmStatus realmStatus)
        {
            _logger = logger;
            _userHandler = userHandler;
            _realmStatus = realmStatus;
        }

        [HttpGet("get")]
        public RealmStatusMessage Status()
        {
            return _realmStatus.Status();
        }

        [HttpPost("register")]
        public IActionResult Register([FromForm] UserRegistrationPost user)
        {
            if (_userHandler.IsUserExist(user.username))
                return BadRequest("User already exists");
		
            if (!UsernameValidator.ValidateUsername(user.username))
                return BadRequest("Username is not valid format, user name should not contains any spaces or speciall characters");
            
            if(!PasswordValidator.ValidatePassword(user.password))
                return BadRequest("Password, should have at least 8 characters, at least one uppercase letter, one lowercase letter, and one digit, and should not contains any spaces");
            
            PrivateKeyType privateKey = PrivateKeyType.GenerateFromString(user.password + user.username);
	
            _userHandler.AddUser(user.username, privateKey);

            return Ok("User successfully created");
        }
    }
}
