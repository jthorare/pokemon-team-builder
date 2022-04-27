using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace PokemonTeamBuilderApi.Models
{
    public class UserTeams
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [BsonElement("user_id")]
        [JsonPropertyName("user_id")]
        public int? UserId { get; set; }

        [BsonElement("user_teams")]
        [JsonPropertyName("user_teams")]
        public Dictionary<string, List<List<int>>>? TeamMappings { get; set; }
    }
}
