using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SolarSystem.Models
{
    public class SpaceObject
    {
        [BsonId]
        public ObjectId ObjectId { get; set; }

        [BsonElement("Uid")]
        public string Uid { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Description")]
        public string Description { get; set; }

        [BsonElement("Diameter")]
        public double Diameter { get; set; }

        [BsonElement("Distance")]
        public double Distance { get; set; }

        [BsonElement("Type")]
        public string Type { get; set; }

        [BsonElement("Parent")]
        public ObjectId ParentObjectId { get; set; }

        public struct SpaceObjectType
        {
            public const string Star = "star";
            public const string Satellite = "satellite";
            public const string Planet = "planet";
            public const string Astreoid = "astreoid";
        }

    }
}