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
            var user = context.Users.FirstOrDefault(u => u.IdpId.Equals(userIdpId));
            if (user == null)
            {
                throw new InvalidOperationException();
            }

            var wallet = new DAL.Models.Wallet()
            {
                Name = dto.Name,
                Note = dto.Note,
                UserId = user.Id,
            };
            var e = await context.Wallets.AddAsync(wallet);
            if (await context.SaveChangesAsync() > 0)
            {
                return mapper.Map<WalletDto>(e.Entity);
            }
            return null;
        }

        public bool Delete(Guid id)
        {
            context.Wallets.Remove(context.Wallets.First(x => x.Id == id));
            return context.SaveChanges() != 0;
        }

        public IEnumerable<WalletDto> GetAll()
        {
            return this.mapper.ProjectTo<WalletDto>(context.Wallets);
        }

        public WalletDto GetById(Guid id)
        {
            return this.mapper.Map<WalletDto>(context.Wallets.First(s => s.Id.Equals(id)));
        }

        public bool Update(WalletDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
