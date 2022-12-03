using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Tomagochi.BLL.Interfaces;
using Tomagochi.BLL.Services;
using Tomagochi.WebAssembly;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7289/api/") });
builder.Services.AddScoped<IPetService, PetService>();

await builder.Build().RunAsync();
