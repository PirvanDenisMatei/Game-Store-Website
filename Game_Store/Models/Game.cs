using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Game_Store.Models
{
    public class Game
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Name")]
        [JsonPropertyName("Name")]
        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public string Genre { get; set; } = null!;

        public string Nplayers { get; set; } = null!;

        public string Catchphrase { get; set; } = null!;

        public string Developer { get; set; } = null!;

        public string ImagesPath { get; set; } = null!;
    }
}
