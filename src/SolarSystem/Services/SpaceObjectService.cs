using MongoDB.Driver;
using System.Collections.Generic;
using SolarSystem.Models;
using SolarSystem.Services.Contracts;

namespace SolarSystem.Services
{
    public class SpaceObjectService : ISpaceObjectService
    {
        private IMongoClient _client;
        private IMongoDatabase _database;

        private const string MongoDbUri = "mongodb://read:read@ds129028.mlab.com:29028/solar-system";
        private const string DatabaseName = "solar-system";
        private const string CollectionName = "space-objects";

        public SpaceObjectService()
        {
            _client = new MongoClient(MongoDbUri);
            _database = _client.GetDatabase(DatabaseName);
        }


        public void CreateInitialData()
        {
            _database.CreateCollection(CollectionName);
            var collection = _database.GetCollection<SpaceObject>(CollectionName);

            var sun = new SpaceObject { Name = "Sun", Distance = 0, Diameter = 694999, Uid = Helper.Uid(), Type = SpaceObject.SpaceObjectType.Star };

            collection.InsertOne(sun);

            sun = collection.Find(o => o.Type == SpaceObject.SpaceObjectType.Star).First();

            var list = new List<SpaceObject>{
                new SpaceObject { Name= "Mercury", Distance= 57910000, Diameter= 4800, Uid = Helper.Uid()   ,Type=SpaceObject.SpaceObjectType.Planet, ParentObjectId=sun.ObjectId   },
                new SpaceObject { Name= "Venus", Distance= 108200000, Diameter= 12100 , Uid = Helper.Uid()  ,Type=SpaceObject.SpaceObjectType.Planet, ParentObjectId=sun.ObjectId   },
                new SpaceObject { Name= "Earth", Distance= 149600000, Diameter= 12750, Uid = Helper.Uid()   ,Type=SpaceObject.SpaceObjectType.Planet, ParentObjectId=sun.ObjectId    },
                new SpaceObject { Name= "Mars", Distance= 227940000, Diameter= 6800 , Uid = Helper.Uid()    ,Type=SpaceObject.SpaceObjectType.Planet, ParentObjectId=sun.ObjectId   },
                new SpaceObject { Name= "Jupiter", Distance= 778330000, Diameter= 142800, Uid = Helper.Uid(),Type=SpaceObject.SpaceObjectType.Planet, ParentObjectId=sun.ObjectId },
                new SpaceObject { Name= "Saturn", Distance= 1424600000, Diameter= 120660, Uid = Helper.Uid(),Type=SpaceObject.SpaceObjectType.Planet, ParentObjectId=sun.ObjectId },
                new SpaceObject { Name= "Uranus", Distance= 2873550000, Diameter= 51800 , Uid = Helper.Uid(),Type=SpaceObject.SpaceObjectType.Planet, ParentObjectId=sun.ObjectId   },
                new SpaceObject { Name= "Neptune", Distance= 4497100000, Diameter= 49500 , Uid = Helper.Uid(),Type=SpaceObject.SpaceObjectType.Planet, ParentObjectId=sun.ObjectId    }
            };

            collection.InsertMany(list);

        }

        public List<SpaceObject> GetAll()
        {
            var collection = _database.GetCollection<SpaceObject>(CollectionName);
            var list = collection.Find(Builders<SpaceObject>.Filter.Empty).ToList();
            return list;
        }

        public List<SpaceObject> GetPlanets()
        {
            var collection = _database.GetCollection<SpaceObject>(CollectionName);
            var list = collection.Find(o => o.Type == SpaceObject.SpaceObjectType.Planet).ToList();
            return list;
        }
    }
}