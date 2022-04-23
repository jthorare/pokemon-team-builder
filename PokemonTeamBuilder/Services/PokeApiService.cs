using PokeApiNet;
namespace PokemonTeamBuilder.Services;

/// <summary>
/// This class exists to wrap the PokeApiClient. The PokeApiClient extends HttpClient and therefore cannot be instantiated as a Singleton.
/// </summary>
public class PokeApiService
{
    private PokeApiClient Poke { get; set; }

    public PokeApiService()
    {
        Poke = new PokeApiClient();
    }

    public async Task<Pokedex> GetPokedex(int id)
    {
        return await Poke.GetResourceAsync<Pokedex>(id);
    }

    public async Task<Pokedex> GetPokedex(string id)
    {
        return await Poke.GetResourceAsync<Pokedex>(id);
    }

    public async Task<HashSet<string>> GetPokemonOfType(string type)
    {
        PokeApiNet.Type typeInfo = await Poke.GetResourceAsync<PokeApiNet.Type>(type);
        HashSet<string> pokemonOfType = typeInfo.Pokemon.Select(pokemon => pokemon.Pokemon.Name).ToHashSet();
        return pokemonOfType;
    }

    public async Task<Pokemon> GetPokemon(string name)
    {
        return await Poke.GetResourceAsync<Pokemon>(name);
    }

    public async Task<PokeApiNet.NamedApiResourceList<PokeApiNet.Type>> GetAllTypes()
    {
        return await Poke.GetNamedResourcePageAsync<PokeApiNet.Type>();
    }

    public async Task<Ability> GetAbility(string ability)
    {
        return await Poke.GetResourceAsync<Ability>(ability);
    }

    public async Task<Move> GetMove(string move)
    {
        return await Poke.GetResourceAsync<Move>(move);
    }
}