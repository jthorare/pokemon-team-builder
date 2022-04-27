using PokemonTeamBuilderApi.Models;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace PokemonTeamBuilder.Services
{
    public class PokemonTeamBuilderApiService : IApiService
    {
        private readonly HttpClient _client;
        public PokemonTeamBuilderApiService(HttpClient client)
        {
            _client = client;
        }

        public async Task<HttpResponseMessage> SaveTeamAsync(int? userId, Dictionary<string, List<List<int>>> teamsToSave)
        {
            var response = await _client.PostAsJsonAsync($"save?userId={userId}", teamsToSave);
            return response;
        }
        public async Task<HttpResponseMessage> Login(UserInfo userInfo)
        {
            var response = await _client.PostAsync($"login?username={userInfo.Username}&password={userInfo.Password}", null);
            return response;
        }

        public async Task<HttpResponseMessage> Register(UserInfo userInfo)
        {
            var response = await _client.PostAsync($"register?username={userInfo.Username}&password={userInfo.Password}", null);
            return response;
        }

        public async Task<HttpResponseMessage> SubmitSuggestion(string suggestion)
        {
            var response = await _client.PostAsJsonAsync("suggest", suggestion);
            return response;
        }

    }
}
