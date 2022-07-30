namespace API.Controllers
{
    using API.Business.User.DTOs;
    using API.Business.User.Services.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;

    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<UserDto> Get()
        {
            return await this.userService.GetByIdpId(this.HttpContext.GetUserIdpId());
        }

        [HttpPost]
        public async Task<UserDto> RegisterUser([FromBody] UserCreateRequestDto dto)
        {
            return await userService.CreateUser(this.HttpContext.GetUserIdpId(), dto.UserName);
        }
    }
}