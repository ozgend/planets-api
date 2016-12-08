using System.Collections.Generic;
using SolarSystem.Planets.Models;

namespace SolarSystem.Planets.Services.Contracts
{
    public interface IPlanetService
    {
        List<Planet> GetPlanets();

        void CreateInitialData();
    }
}