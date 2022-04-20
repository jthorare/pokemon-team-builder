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

    public async Task<HashSet<string>> GetPokemonOfType(string type)
    {
        PokeApiNet.Type typeInfo = await Poke.GetResourceAsync<PokeApiNet.Type>(type);
        List<TypePokemon> typePokemon = typeInfo.Pokemon;
        HashSet<string> pokemonOfType = new();
        foreach(TypePokemon pokemon in typePokemon)
        {
            pokemonOfType.Add(pokemon.Pokemon.Name);
        }
        return pokemonOfType;
    }
}