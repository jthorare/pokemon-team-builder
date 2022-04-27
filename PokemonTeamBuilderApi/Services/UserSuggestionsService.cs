using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PokemonTeamBuilderApi.Models;

namespace PokemonTeamBuilderApi.Services
{
    public class UserSuggestionsService
    {

    private readonly IMongoCollection<UserSuggestion> _userSuggestionsCollection;

    public UserSuggestionsService(
        IOptions<PokemonTeamBuilderDbSettings> databaseSettings)
    {
        var mongoClient = new MongoClient(
            databaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            databaseSettings.Value.DatabaseName);

            _userSuggestionsCollection = mongoDatabase.GetCollection<UserSuggestion>(
            databaseSettings.Value.UserSuggestionsCollectionName);
    }
        /// <summary>
        /// Creates a new suggestion in the collection.
        /// </summary>
        /// <param name="suggestion">The suggestion.</param>
        /// <returns>Async task.</returns>
        public async Task CreateAsync(UserSuggestion suggestion) =>
            await _userSuggestionsCollection.InsertOneAsync(suggestion);
    }
}
