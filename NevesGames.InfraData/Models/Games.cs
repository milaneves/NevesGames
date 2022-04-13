using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace NevesGames.InfraData.Models
{
    public class Games
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; } 
        public string Genre { get; set; }
        public string Classification { get; set; }
        public string Oringinal_Language { get; set; }

    }
}
