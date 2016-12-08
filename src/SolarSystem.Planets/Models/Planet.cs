using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SolarSystem.Planets.Models
{
    public class Planet
    {
        [BsonId]
        public ObjectId ObjectId { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Description")]
        public string Description { get; set; }

        [BsonElement("Diameter")]
        public double Diameter { get; set; }

        [BsonElement("Distance")]
        public double Distance { get; set; }

    }
}