namespace PokemonTeamBuilder.Services
{
    public class AppData
    {
        public int? UserId { get; set; }
        public Dictionary<string, List<List<int>>>? TeamMappings { get; set; }

        public bool? IsContributor { get; set; }
    }
}
