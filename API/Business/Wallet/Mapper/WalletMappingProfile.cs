using AutoMapper;

using API.Business.Wallet.DTOs;
using API.DAL.Models;

namespace API.Business.Wallet.Mapper
{
    public class WalletMappingProfile : Profile
    {
        public WalletMappingProfile()
        {
            this.WalletMapProfile();
            this.BalanceChangeMapProfile();
        }

        private void WalletMapProfile()
        {
            this.CreateMap<DAL.Models.Wallet, WalletDto>()
                .ForMember(
                            dto => dto.Id,
                            map => map.MapFrom(src => src.Id))
                .ForMember(
                            dto => dto.Name,
                            map => map.MapFrom(src => src.Name))
                .ForMember(
                            dto => dto.Note,
                            map => map.MapFrom(src => src.Note))
                .ForMember(
                            dto => dto.BalanceChanges,
                            map => map.MapFrom(src => src.BalanceChanges))
                ;

        }

        private void BalanceChangeMapProfile()
        {
            this.CreateMap<DAL.Models.BalanceChange, BalanceChangeDto>()
                .ForMember(
                            dto => dto.Id,
                            map => map.MapFrom(src => src.Id))
                .ForMember(
                            dto => dto.WalletId,
                            map => map.MapFrom(src => src.WalletId))
                .ForMember(
                            dto => dto.ChangeType,
                            map => map.MapFrom(src => src.Type))
                .ForMember(
                            dto => dto.Date,
                            map => map.MapFrom(src => src.Date))
                .ForMember(
                            dto => dto.Reason,
                            map => map.MapFrom(src => src.Reason))
                .ForMember(
                            dto => dto.Amount,
                            map => map.MapFrom(src => src.Amount))
                ;
        }
    }
}
