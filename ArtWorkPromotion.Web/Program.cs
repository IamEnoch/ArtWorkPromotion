using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ArtWorkPromotion.Web;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args)
                                    .AddClientServices();
                                    
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
await builder.Build().RunAsync();
