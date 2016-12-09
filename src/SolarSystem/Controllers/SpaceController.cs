using SolarSystem.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using SolarSystem.Models;

namespace SolarSystem.Controllers
{
    [Route("api/[controller]")]
    public class SpaceController : Controller
    {
        private ISpaceObjectService _spaceObjectService;

        public SpaceController(ISpaceObjectService spaceObjectService)
        {
            _spaceObjectService = spaceObjectService;
        }

        [Route("")]
        [Route("all")]
        [HttpGet]
        public List<SpaceObject> All()
        {
            var list = _spaceObjectService.GetAll();
            return list;
        }

        [Route("planets")]
        [HttpGet]
        public List<SpaceObject> Planets()
        {
            var list = _spaceObjectService.GetPlanets();
            return list;
        }

        [Route("create")]
        [HttpGet]
        public bool Create()
        {
            _spaceObjectService.CreateInitialData();
            return true;
        }




    }
}
