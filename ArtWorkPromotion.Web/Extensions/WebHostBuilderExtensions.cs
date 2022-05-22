
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;
using MudBlazor.Services;
using MudBlazor;
using ArtWorkPromotion;
using Microsoft.AspNetCore.Components.Authorization;
using Toolbelt.Blazor.Extensions.DependencyInjection;
using System.Globalization;
using ArtworkPromotion.Constants.Storage;
using Microsoft.AspNetCore.Authorization;

public static class WebHostBuilderExtensions
{

    private const string ClientName = "ArtworkPromotion.API";

    public static IServiceCollection AddManagers(this IServiceCollection services)
    {
       services.AddTransient<IUserManager, AppUserManager>();
       services.AddTransient<IArtManager, ArtManager>();
       services.AddTransient<IBlobStorageManager, BlobStorageManager>();
       services.AddScoped<IClientPreferenceManager, ClientPreferenceManager>();
       services.AddTransient<IHttpInterceptorManager, HttpInterceptorManager>();
       services.AddTransient<IAuthenticationManager, AuthenticationManager>();
       return services;
    }
    public static WebAssemblyHostBuilder AddClientServices(this WebAssemblyHostBuilder builder)
    {
        builder
            .Services
            .AddBlazoredLocalStorage()
            .AddMudServices(configuration =>
            {
                configuration.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;
                configuration.SnackbarConfiguration.HideTransitionDuration = 100;
                configuration.SnackbarConfiguration.ShowTransitionDuration = 100;
                configuration.SnackbarConfiguration.VisibleStateDuration = 3000;
                configuration.SnackbarConfiguration.ShowCloseIcon = false;
            })
            .AddScoped<AccessStateProvider>()
            .AddScoped<AuthenticationStateProvider, AccessStateProvider>()
            .AddManagers()
            .AddTransient<AuthenticationHeaderHandler>()
            .AddScoped(sp => sp
                .GetRequiredService<IHttpClientFactory>()
                .CreateClient(ClientName).EnableIntercept(sp))
            .AddHttpClient(ClientName, client =>
            {
                client.DefaultRequestHeaders.AcceptLanguage.Clear();
                client.DefaultRequestHeaders.AcceptLanguage.ParseAdd(CultureInfo.DefaultThreadCurrentCulture?.TwoLetterISOLanguageName);
                client.BaseAddress = new Uri(Constants.Local.BaseAddress);
            })
            .AddHttpMessageHandler<AuthenticationHeaderHandler>();
        builder.Services.AddHttpClientInterceptor();
        return builder;
    }
}