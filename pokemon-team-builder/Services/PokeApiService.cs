namespace Services;
using PokeApiNet;
public class PokeApiService {
    private PokeApiClient Poke { get; set; }

    public PokeApiService()
    {
        Poke = new PokeApiClient();
    }
}