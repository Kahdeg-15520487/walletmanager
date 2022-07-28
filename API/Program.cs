namespace API
{
    using API.Business.Wallet;
    using API.DAL;

    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.IdentityModel.Tokens;

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration
                    .SetBasePath(builder.Environment.ContentRootPath)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile("appsettings.json".Insert("appsettings".Length, $".{builder.Environment.EnvironmentName}"), optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables();

            // Add services to the container.

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = builder.Configuration["Auth0:Authority"];
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudiences = new List<string>
                    {
                        builder.Configuration["Auth0:Audience"]
                    },
                };
                options.Audience = builder.Configuration["Auth0:Audience"];
                options.RequireHttpsMetadata = false;
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder
                    .WithOrigins("*")
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            builder.Services.AddDbContext<WalletManagerDataContext>();
            builder.Services.AddControllers();
            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.RegisterWalletServices();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var config = serviceScope.ServiceProvider.GetRequiredService<IConfiguration>();
                Console.WriteLine(config.GetConnectionString("WebApiDatabase"));
                using (var context = serviceScope.ServiceProvider.GetRequiredService<WalletManagerDataContext>())
                {
                    if (context.Database.GetPendingMigrations().Any())
                    {
                        context.Database.Migrate();
                    }
                }
            }

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors("CorsPolicy");

            app.MapControllers();

            app.Run();
        }
    }
}