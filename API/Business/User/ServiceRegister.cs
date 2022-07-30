namespace API.Business.User
{
    using API.Business.User.Services;
    using API.Business.User.Services.Interfaces;

    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceRegister
    {
        public static void RegisterUserServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}
