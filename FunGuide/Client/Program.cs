global using FunGuide.Shared;
global using FunGuide.Client.Services.SportsmanServices;
global using FunGuide.Client.Services.SportServices;
global using Microsoft.EntityFrameworkCore;

using FunGuide.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Globalization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<ISportService, SportService>();

builder.Services.AddScoped<ISportsmanService,SportsmanService>();
await builder.Build().RunAsync();
