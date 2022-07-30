using UI;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace UI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            var serverUrl = builder.HostEnvironment.BaseAddress;
            if (builder.HostEnvironment.IsDevelopment())
            {
                serverUrl = builder.Configuration["APIURL"];
            }

            builder.Services.AddScoped(sp =>
            {
                var configuredAuthorizationMessageHandler = sp.GetRequiredService<AuthorizationMessageHandler>()
                    .ConfigureHandler(
                        authorizedUrls: new[] { serverUrl },
                        scopes: new string[] { });
                configuredAuthorizationMessageHandler.InnerHandler = new HttpClientHandler();
                return new HttpClient(configuredAuthorizationMessageHandler)
                {
                    BaseAddress = new Uri(serverUrl)
                };
            });

            builder.Services.AddOidcAuthentication(options =>
            {
                builder.Configuration.Bind("Auth0", options.ProviderOptions);
                options.ProviderOptions.ResponseType = "code";
                options.ProviderOptions.AdditionalProviderParameters.Add("audience", builder.Configuration["Auth0:Audience"]);
            });

            await builder.Build().RunAsync();
        }
    }
}