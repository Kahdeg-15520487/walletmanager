using API.Business.User.DTOs;

namespace API.Business.User.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetByIdpId(string userIdpId);
        Task<UserDto> CreateUser(string userIdpId, string userName);
    }
}
