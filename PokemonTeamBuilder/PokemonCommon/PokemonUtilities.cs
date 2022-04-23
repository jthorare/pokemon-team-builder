using System;
namespace PokemonTeamBuilder.PokemonCommon;

public static class PokemonUtilities
{

    public static int GetNatDexId(string url)
    {
        string[] urlSplit = url.Split("/"); // url is of form "https://pokeapi.co/api/v2/pokemon-species/650/"
        return Int32.Parse(urlSplit[^2]); // the last # is what we want for our img navigation
    }


}


