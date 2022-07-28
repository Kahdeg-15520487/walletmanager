using API.DAL.Models;

using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

using System.Diagnostics;

namespace API.DAL
{
    public class WalletManagerDataContext : DbContext
    {
        private readonly IConfiguration configuration;

        public WalletManagerDataContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("WebApiDatabase"));

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<BalanceChange> BalanceChanges { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
