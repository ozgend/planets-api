using MongoDB.Driver;
using System.Collections.Generic;
using SolarSystem.Planets.Models;
using SolarSystem.Planets.Services.Contracts;

namespace SolarSystem.Planets.Services
{
    public class PlanetService : IPlanetService
    {
        private IMongoClient _client;
        private IMongoDatabase _database;
        private IMongoCollection<Planet> _collection;

        public PlanetService()
        {
            _client = new MongoClient("mongodb://reader:reader@ds127988.mlab.com:27988/solar-system-planets");         
            _database = _client.GetDatabase("solar-system-planets");
            _collection = _database.GetCollection<Planet>("planets");
        }


        public void CreateInitialData()
        {
            var list = new List<Planet>{
                new Planet { Name= "Mercury", Distance= 57910000, Diameter= 4800 },
                new Planet { Name= "Venus", Distance= 108200000, Diameter= 12100 },
                new Planet { Name= "Earth", Distance= 149600000, Diameter= 12750 },
                new Planet { Name= "Mars", Distance= 227940000, Diameter= 6800 },
                new Planet { Name= "Jupiter", Distance= 778330000, Diameter= 142800 },
                new Planet { Name= "Saturn", Distance= 1424600000, Diameter= 120660 },
                new Planet { Name= "Uranus", Distance= 2873550000, Diameter= 51800 },
                new Planet { Name= "Neptune", Distance= 4497100000, Diameter= 49500 }
            };

            _collection.InsertMany(list);

        }

        public List<Planet> GetPlanets()
        {
            var list = _collection.Find(Builders<Planet>.Filter.Empty).ToList();
            return list;
        }
    }
}