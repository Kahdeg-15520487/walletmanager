namespace API.Business.Wallet.Services
{
    using AutoMapper;

    using API.Business.Wallet.DTOs;
    using API.Business.Wallet.Services.Interfaces;
    using API.DAL;

    using System;
    using System.Collections.Generic;
    using API.DAL.Models;
    using Microsoft.EntityFrameworkCore;

    public class BalanceService : IBalanceService
    {
        private readonly WalletManagerDataContext context;
        private readonly IMapper mapper;

        public BalanceService(WalletManagerDataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<BalanceChangeDto> Create(string userIdpId, BalanceChangeCreateRequestDto dto)
        {
            if (!await CheckValidRequest(userIdpId, dto.WalletId))
            {
                return null;
            }

            var newBalance = new BalanceChange()
            {
                WalletId = dto.WalletId,
                Amount = dto.Amount,
                Date = DateTime.UtcNow,
                Reason = dto.Reason,
                Type = dto.ChangeType,
            };
            var changeResult = await context.BalanceChanges.AddAsync(newBalance);

            if (await context.SaveChangesAsync() > 0)
            {
                return mapper.Map<BalanceChangeDto>(changeResult.Entity);
            }
            return null;
        }

        public bool Delete(string userIdpId, Guid balanceId)
        {
            var bal = context.BalanceChanges.First(x => x.Id == balanceId);
            var wallet = context.Wallets.First(x => x.Id == bal.WalletId);
            context.BalanceChanges.Remove(bal);
            return context.SaveChanges() != 0;
        }

        public BalanceChangeDto GetBalanceChange(string userIdpId, Guid balanceId)
        {
            return mapper.Map<BalanceChangeDto>(context.BalanceChanges.Find(balanceId));
        }

        public IEnumerable<BalanceChangeDto> GetByWallet(string userIdpId, Guid walletId)
        {
            if (!CheckValidRequest(userIdpId, walletId).Result)
            {
                return null;
            }

            return mapper.ProjectTo<BalanceChangeDto>(context.BalanceChanges.Where(bc => bc.WalletId.Equals(walletId)));
        }

        public bool Update(string userIdpId, BalanceChangeDto dto)
        {
            throw new NotImplementedException();
        }

        private async Task<bool> CheckValidRequest(string userIdpId, Guid walletId)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.IdpId == userIdpId);
            if (user == null)
            {
                return false;
            }
            var wallet = await context.Wallets.FindAsync(walletId);
            if (wallet == null)
            {
                return false;
            }
            if (wallet.UserId != user.Id)
            {
                return false;
            }
            return true;
        }
    }
}
