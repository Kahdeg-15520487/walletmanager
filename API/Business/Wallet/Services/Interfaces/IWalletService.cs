using API.Business.Wallet.DTOs;

namespace API.Business.Wallet.Services.Interfaces
{
    public interface IWalletService
    {
        WalletDto GetById(Guid id);
        IEnumerable<WalletDto> GetAll();
        Task<WalletDto> Create(WalletCreateRequestDto dto, string userIdpId);
        bool Delete(Guid id);
        bool Update(WalletDto dto);
    }
}
