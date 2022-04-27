namespace PokemonTeamBuilderApi.Models
{
    public class PokemonTeamBuilderDbSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string UserInfoCollectionName { get; set; } = null!;

        public string UserTeamsCollectionName { get; set; } = null!;

        public string UserSuggestionsCollectionName { get; set; } = null!;
    }
}
