using PokemonTeamBuilderApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace PokemonTeamBuilderApi.Services;
public class UserTeamsService
{
    private readonly IMongoCollection<UserTeams> _userTeamsCollection;

    public UserTeamsService(
        IOptions<PokemonTeamBuilderDbSettings> databaseSettings)
    {
        var mongoClient = new MongoClient(
            databaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            databaseSettings.Value.DatabaseName);

        _userTeamsCollection = mongoDatabase.GetCollection<UserTeams>(
            databaseSettings.Value.UserTeamsCollectionName);
    }

    /// <summary>
    /// Gets all UserTeams in the collection.
    /// </summary>
    /// <returns>The List of all UserTeams in the collection.</returns>
    public async Task<List<UserTeams>> GetAsync() =>
        await _userTeamsCollection.Find(_ => true).ToListAsync();

    /// <summary>
    /// Gets the UserTeams by the id
    /// </summary>
    /// <param name="userId">The UserTeams.UserId</param>
    /// <returns>Task with nullable object.</returns>
    public async Task<UserTeams?> GetAsync(int? userId) =>
        await _userTeamsCollection.Find(x => x.UserId == userId).FirstOrDefaultAsync();

    /// <summary>
    /// Used to save a user's first team. All subsequent additional teams are updates of this entry.
    /// </summary>
    /// <param name="newTeam">The user's first team.</param>
    /// <returns>Async task.</returns>
    public async Task CreateAsync(UserTeams newTeam) =>
        await _userTeamsCollection.InsertOneAsync(newTeam);

    /// <summary>
    /// Used to update a user's saved teams.
    /// </summary>
    /// <param name="id">the UserTeams.Id to update.</param>
    /// <param name="updatedTeams">The updated UserTeams</param>
    /// <returns>Async task.</returns>
    public async Task UpdateAsync(string? id, UserTeams updatedTeams) =>
        await _userTeamsCollection.ReplaceOneAsync(x => x.Id == id, updatedTeams);

    /// <summary>
    /// Deletes the given UserTeam by UserTeam.Id.
    /// </summary>
    /// <param name="id">The UserTeam's UserTeam.Id to delete</param>
    /// <returns>Async task.</returns>
    public async Task RemoveAsync(string id) =>
        await _userTeamsCollection.DeleteOneAsync(x => x.Id == id);
}
