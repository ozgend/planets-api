using System.Collections.Generic;
using SolarSystem.Models;

namespace SolarSystem.Services.Contracts
{
    public interface ISpaceObjectService
    {
        List<SpaceObject> GetAll();

        List<SpaceObject> GetPlanets();

        void CreateInitialData();
    }
}