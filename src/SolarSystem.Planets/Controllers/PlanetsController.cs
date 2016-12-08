using SolarSystem.Planets.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using SolarSystem.Planets.Models;

namespace SolarSystem.Planets.Controllers
{
    [Route("api/[controller]")]
    public class PlanetsController : Controller
    {
        private IPlanetService _planetService;

        public PlanetsController(IPlanetService planetService)
        {
            _planetService = planetService;
        }

        [Route("")]
        [Route("list")]
        [HttpGet]
        public List<Planet> List()
        {
            var list = _planetService.GetPlanets();
            return list;
        }

    }
}
