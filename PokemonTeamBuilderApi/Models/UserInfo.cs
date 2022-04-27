using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PokemonTeamBuilderApi.Models;
public class UserInfo
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("username")]
    public string? Username { get; set; }

    [BsonElement("password")]
    public string? Password { get; set; }

    [BsonElement("user_id")]
    public int? UserId { get; set; }

    [BsonElement("is_contr")]
    public bool? IsContributor { get; set; }
}


