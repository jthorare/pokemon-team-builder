using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using PokemonTeamBuilder.Services;
using PokemonTeamBuilder;
using System.Net.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("PokemonTeamBuilderApi", (sp, cl) =>
{
    cl.BaseAddress = new Uri("https://localhost:7095/api/");
});

builder.Services.AddScoped(
    sp => sp.GetService<IHttpClientFactory>().CreateClient("PokemonTeamBuilderApi"));
builder.Services.AddScoped<IApiService, PokemonTeamBuilderApiService>();
builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
    })
    .AddBootstrapProviders()
    .AddFontAwesomeIcons();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
                      policy =>
                      {
                          policy.WithOrigins("https://localhost:7095",
                              "https://pokeapi.co/api/v2",
                              "https://login.microsoftonline.com/.well-known/openid-configuration")
                          .AllowAnyHeader().AllowAnyMethod();
                      });
});

builder.Services.AddSingleton<PokeApiService>();
builder.Services.AddSingleton<AppData>();

await builder.Build().RunAsync();
