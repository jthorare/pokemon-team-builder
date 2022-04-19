using System;
namespace pokemon_team_builder.PokemonCommon;
public static class PokeApiConstants
{
    public static Dictionary<string, List<int>> RegionMappings = new()
    {
        { "alola", new List<int>() { 16, 17, 18, 19, 20 } },
        { "kalos", new List<int>() { 12, 13, 14 } },
        { "updated-hoenn", new List<int>() { 15 } },
        { "galar", new List<int>() { 27, 28, 29 } },
        { "letsgo-kanto", new List<int> { 26 } }
    };

    public static Dictionary<string, int> TypeMappings = new()
    {
        { "normal", 0 },
        { "fighting", 1 },
        { "flying", 2 },
        { "poison", 3 },
        { "ground", 4 },
        { "rock", 5 },
        { "bug", 6 },
        { "ghost", 7 },
        { "steel", 8 },
        { "fire", 9 },
        { "water", 10 },
        { "grass", 11 },
        { "electric", 12 },
        { "psychic", 13 },
        { "ice", 14 },
        { "dragon", 15 },
        { "dark", 16 },
        { "fairy", 17 },
        { "unknown", 18 },
        { "shadow", 19 }
    };
}


