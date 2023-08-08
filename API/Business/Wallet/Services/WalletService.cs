namespace API.Business.Wallet.Services
{
    using AutoMapper;

    using API.Business.Wallet.DTOs;
    using API.Business.Wallet.Services.Interfaces;
    using API.DAL;

    using System;
    using System.Collections.Generic;

    public class WalletService : IWalletService
    {
        private readonly WalletManagerDataContext context;
        private readonly IMapper mapper;

        public WalletService(WalletManagerDataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<WalletDto> Create(WalletCreateRequestDto dto, string userIdpId)
        {
            var user = context.Users.FirstOrDefault(u => u.IdpId == userIdpId);
            if (user == null)
            {
                throw new InvalidOperationException();
            }

            var wallet = new DAL.Models.Wallet()
            {
                Name = dto.Name,
                Note = dto.Note,
                UserId = user.Id,
                IsHidden = false,
            };
            var e = await context.Wallets.AddAsync(wallet);
            if (await context.SaveChangesAsync() > 0)
            {
                return mapper.Map<WalletDto>(e.Entity);
            }
            return null;
        }

        public async Task<bool> Delete(Guid id, string userIdpId)
        {
            var user = context.Users.FirstOrDefault(u => u.IdpId == userIdpId);
            if (user == null)
            {
                throw new KeyNotFoundException();
            }

            var wallet = context.Wallets.FirstOrDefault(x => x.Id == id && x.UserId == user.Id);
            if (wallet == null)
            {
                throw new KeyNotFoundException();
            }
            wallet.IsHidden = true;
            return (await context.SaveChangesAsync()) != 0;
        }

        public WalletDto GetById(string userIdpId, Guid id)
        {
            var user = context.Users.FirstOrDefault(u => u.IdpId == userIdpId);
            if (user == null)
            {
                throw new KeyNotFoundException();
            }
            return this.mapper.Map<WalletDto>(context.Wallets.First(w => w.Id == id && w.UserId == user.Id));
        }

        public IEnumerable<WalletDto> GetAllByUserIdpId(string userIdpId)
        {
            var user = context.Users.FirstOrDefault(u => u.IdpId == userIdpId);
            if (user == null)
            {
                throw new KeyNotFoundException();
            }
            return this.mapper.ProjectTo<WalletDto>(context.Wallets.Where(w => !w.IsHidden && w.UserId == user.Id));
        }

        public bool Update(WalletDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
