using PokemonTeamBuilderApi.Models;
using PokemonTeamBuilderApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<PokemonTeamBuilderDbSettings>(
    builder.Configuration.GetSection("PokemonTeamBuilderDb"));
builder.Services.AddSingleton<UserTeamsService>();
builder.Services.AddSingleton<UserInfoService>();
builder.Services.AddSingleton<UserSuggestionsService>();
builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
{
    policy.WithOrigins("https://localhost:7207")
          .AllowAnyHeader()
          .AllowAnyMethod();
}));
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseHttpsRedirection();
app.MapControllers();
app.UseRouting();
app.Run();
