using Akshay.ProjectDemo.API.Interface;
using Akshay.ProjectDemo.API.RequestModfels;
using Akshay.ProjectDemo.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Akshay.ProjectDemo.API.Controllers
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
        public string Login([FromBody] LoginRequest loginRequest)
        {
            var result = _authService.Login(loginRequest);
            return result;
        }
        [HttpPost("addUser")]
        public User Adduser([FromBody] User UserRequest)
        {
            var user = _authService.AddUser(UserRequest);
            return user;
        }
    }
}
