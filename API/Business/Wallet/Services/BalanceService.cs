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

        public async Task<BalanceChangeDto> Create(BalanceChangeCreateRequestDto dto)
        {
            var balance = new BalanceChange()
            {
                WalletId = dto.WalletId,
                Amount = dto.Amount,
                Date = DateTime.UtcNow,
                Reason = dto.Reason,
                Type = dto.ChangeType,
            };
            var e = await context.BalanceChanges.AddAsync(balance);
            var wallet = await context.Wallets.FindAsync(dto.WalletId);
            if (wallet == null)
            {
                return null;
            }
            wallet.Balance = dto.ChangeType ? wallet.Balance + dto.Amount : wallet.Balance - dto.Amount;

            if (await context.SaveChangesAsync() > 0)
            {
                return mapper.Map<BalanceChangeDto>(e.Entity);
            }
            return null;
        }

        public bool Delete(Guid balanceId)
        {
            var bal = context.BalanceChanges.First(x => x.Id == balanceId);
            var wallet = context.Wallets.First(x => x.Id == bal.WalletId);
            context.BalanceChanges.Remove(bal);
            wallet.Balance = wallet.Balance + (bal.Type ? -1 : 1) * bal.Amount;
            return context.SaveChanges() != 0;
        }

        public IEnumerable<BalanceChangeDto> GetByWallet(Guid walletId)
        {
            return mapper.ProjectTo<BalanceChangeDto>(context.BalanceChanges.Where(bc => bc.WalletId.Equals(walletId)));
        }

        public bool Update(BalanceChangeDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
