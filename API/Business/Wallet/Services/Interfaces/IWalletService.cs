using API.Business.Wallet.DTOs;

namespace API.Business.Wallet.Services.Interfaces
{
    public interface IWalletService
    {
        WalletDto GetById(string userIdpId, Guid id);
        IEnumerable<WalletDto> GetAllByUserIdpId(string userIdpId);
        Task<WalletDto> Create(WalletCreateRequestDto dto, string userIdpId);
        bool Delete(Guid id);
        bool Update(WalletDto dto);
    }
}
