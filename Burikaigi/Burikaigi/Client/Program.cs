using Burikaigi.Client;
using Burikaigi.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using Sotsera.Blazor.Toaster.Core.Models;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("Burikaigi.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("Burikaigi.ServerAPI"));

builder.Services.AddScoped(sp => {
    var httpClient = new HttpClient
    {
        BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
    };

    var jsRuntime = (IJSInProcessRuntime)sp.GetService<IJSRuntime>()!;
    var cookie = jsRuntime.Invoke<string>("window.jsFunctions.getCookie");
    var token = cookie.Split(";").Select(e => e.Trim().Split("=")).Where(e => e.Length == 2 && e[0] == "X-ANTIFORGERY-TOKEN").Select(e => e[1]).FirstOrDefault();
    httpClient.DefaultRequestHeaders.Add("X-ANTIFORGERY-TOKEN", token);

    return httpClient;
});

builder.Services.AddToaster(config =>
{
    config.PositionClass = Defaults.Classes.Position.BottomRight;
    config.MaximumOpacity = 100;
    config.VisibleStateDuration = 1000 * 10;
    config.ShowTransitionDuration = 10;
    config.HideTransitionDuration = 500;
});

builder.Services.AddScoped<HttpService>();

await builder.Build().RunAsync();
