using PokeApiNet;
namespace pokemon_team_builder.Services;

public class PokeApiService {
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

    public async Task<Type> GetPokemonOfType(string type)
    {
        return await Poke.GetResourceAsync<Type>(type);
    }
}