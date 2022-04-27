using PokemonTeamBuilderApi.Models;
using System.Net;
using System.Security.Claims;

namespace PokemonTeamBuilder.Services;
public interface IApiService
{
    public Task<HttpResponseMessage> SaveTeamAsync(int? userId, Dictionary<string, List<List<int>>> teamsToSave);
    public Task<HttpResponseMessage> Login(UserInfo userInfo);
    public Task<HttpResponseMessage> Register(UserInfo userInfo);

    public Task<HttpResponseMessage> SubmitSuggestion(string suggestion);
}
