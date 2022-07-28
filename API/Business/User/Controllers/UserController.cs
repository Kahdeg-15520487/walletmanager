namespace API.Controllers
{
    using API.Business.User.DTOs;
    using API.Business.User.Services.Interfaces;

    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public UserDto Get()
        {
            return null;
        }
    }
}