using PokemonTeamBuilderApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;


namespace PokemonTeamBuilderApi.Services;
public class UserInfoService
{
    private readonly IMongoCollection<UserInfo> _userInfoCollection;

    public UserInfoService(
        IOptions<PokemonTeamBuilderDbSettings> databaseSettings)
    {
        var mongoClient = new MongoClient(
            databaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            databaseSettings.Value.DatabaseName);

        _userInfoCollection = mongoDatabase.GetCollection<UserInfo>(
            databaseSettings.Value.UserInfoCollectionName);
    }

    /// <summary>
    /// Gets all UserInfo's.
    /// </summary>
    /// <returns>List of all UserInfos.</returns>
    public async Task<List<UserInfo>> GetAsync() =>
        await _userInfoCollection.Find(_ => true).ToListAsync();

    /// <summary>
    /// Gets the UserInfo matching the given UserInfo.Username and UserInfo.password.
    /// </summary>
    /// <param name="username">The UserInfo.Username to match on</param>
    /// <param name="pw">The UserInfo.Password to match on</param>
    /// <returns>The nullable UserInfo matching the criteria.</returns>
    public async Task<UserInfo?> GetAsync(string username, string pw) =>
        await _userInfoCollection.Find(x => x.Username == username && x.Password == pw).FirstOrDefaultAsync();

    /// <summary>
    /// Gets the UserInfo matching the given UserInfo.UserId.
    /// </summary>
    /// <param name="userId">The UserInfo.UserId to match on</param>
    /// <returns>The nullable UserInfo matching the criteria.</returns>
    public async Task<UserInfo?> GetAsync(int? userId) =>
        await _userInfoCollection.Find(x => x.UserId == userId).FirstOrDefaultAsync();

    /// <summary>
    /// Creates a new UserInfo in the collection.
    /// </summary>
    /// <param name="newUser">The new user's UserInfo.</param>
    /// <returns>Async task.</returns>
    public async Task CreateAsync(UserInfo newUser) =>
        await _userInfoCollection.InsertOneAsync(newUser);

    /// <summary>
    /// Deletes the UserInfo matching the given UserInfo.Id
    /// </summary>
    /// <param name="id">The UserInfo's UserInfo.Id to delete</param>
    /// <returns>Async task</returns>
    public async Task RemoveAsync(string id) =>
        await _userInfoCollection.DeleteOneAsync(x => x.Id == id);
}
