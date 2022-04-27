using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PokemonTeamBuilderApi.Models
{
    public class UserSuggestion
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("suggestion")]
        public string? Suggestion { get; set; }
    }
}
