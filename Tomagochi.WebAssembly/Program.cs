using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Tomagochi.WebAssembly.Interfaces;
using Tomagochi.WebAssembly.Services;
using Tomagochi.WebAssembly;
using System.Net.Http;
using Blazored.Toast;
using FluentValidation;
using Tomagochi.BLL.Validators;
using Tomagochi.BLL.DTO;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7289/api/") });
builder.Services.AddHttpClient("TomagochiClient", config =>
{
    config.BaseAddress = new Uri("https://localhost:7289/api/");
});

builder.Services.AddBlazoredToast();
builder.Services.AddScoped<IPetService, PetService>();
builder.Services.AddTransient<IValidator<PetDTO>, PetValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<PetValidator>();


await builder.Build().RunAsync();
