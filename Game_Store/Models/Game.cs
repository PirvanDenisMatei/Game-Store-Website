using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Game_Store.Models
{
    public class Game
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Name")]
        public string GameName { get; set; } = null!;

        public decimal Price { get; set; }

        public string Category { get; set; } = null!;

        public string Developer { get; set; } = null!;
    }
}
