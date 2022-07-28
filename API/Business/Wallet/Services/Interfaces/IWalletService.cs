using API.Business.Wallet.DTOs;

namespace API.Business.Wallet.Services.Interfaces
{
    public interface IWalletService
    {
        WalletDto GetById(Guid id);
        IEnumerable<WalletDto> GetAll();
        WalletDto Create(WalletDto dto);
        bool Delete(Guid id);
        bool Update(WalletDto dto);
    }
}
