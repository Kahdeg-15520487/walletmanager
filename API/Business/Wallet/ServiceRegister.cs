namespace API.Business.Wallet
{
    using API.Business.Wallet.Services;
    using API.Business.Wallet.Services.Interfaces;

    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceRegister
    {
        public static void RegisterWalletServices(this IServiceCollection services)
        {
            services.AddScoped<IWalletService, WalletService>();
        }
    }
}
