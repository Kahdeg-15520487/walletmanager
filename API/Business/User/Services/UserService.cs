namespace API.Business.User.Services
{
    using API.Business.User.DTOs;
    using API.Business.User.Services.Interfaces;
    using API.DAL;

    using AutoMapper;

    using System.Threading.Tasks;

    public class UserService : IUserService
    {
        private readonly WalletManagerDataContext context;
        private readonly IMapper mapper;

        public UserService(WalletManagerDataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<UserDto> CreateUser(string userIdpId, string userName)
        {
            var user = new DAL.Models.User()
            {
                IdpId = userIdpId,
                Name = userName,
            };
            var res = await context.Users.AddAsync(user);
            if (await context.SaveChangesAsync() > 0)
            {
                return mapper.Map<UserDto>(res.Entity);
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> UpdateUserName(string userIdpId, string userName)
        {
            await context.SaveChangesAsync();

            return false;
        }

        public async Task<UserDto> GetByIdpId(string userIdpId)
        {
            return this.mapper.Map<UserDto>(this.context.Users.FirstOrDefault(u => u.IdpId.Equals(userIdpId)));
        }
    }
}
