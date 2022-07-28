namespace API.Business.Wallet.Services
{
    using AutoMapper;

    using API.Business.Wallet.DTOs;
    using API.Business.Wallet.Services.Interfaces;
    using API.DAL;

    using System;
    using System.Collections.Generic;
    using API.DAL.Models;

    public class BalanceService : IBalanceService
    {
        private readonly WalletManagerDataContext context;
        private readonly IMapper mapper;

        public BalanceService(WalletManagerDataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public BalanceChangeDto Create(BalanceChangeDto dto)
        {
            var e = context.BalanceChanges.Add(mapper.Map<BalanceChange>(dto));
            context.SaveChanges();
            return mapper.Map<BalanceChangeDto>(e.Entity);
        }

        public bool Delete(Guid id)
        {
            context.BalanceChanges.Remove(context.BalanceChanges.First(x => x.Id == id));
            return context.SaveChanges() != 0;
        }

        public IEnumerable<BalanceChangeDto> GetAll()
        {
            return mapper.ProjectTo<BalanceChangeDto>(context.BalanceChanges);
        }

        public BalanceChangeDto GetById(Guid id)
        {
            return mapper.Map<BalanceChangeDto>(context.BalanceChanges.First(x => x.Id == id));
        }

        public bool Update(BalanceChangeDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
