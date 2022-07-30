namespace API.Business.Wallet.Mapper
{
    using AutoMapper;

    using API.Business.User.DTOs;
    using API.DAL.Models;

    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            this.UserMapProfile();
        }

        private void UserMapProfile()
        {
            this.CreateMap<DAL.Models.User, UserDto>()
                .ForMember(
                            dto => dto.UserName,
                            map => map.MapFrom(src => src.Name))
                ;

        }
    }
}
