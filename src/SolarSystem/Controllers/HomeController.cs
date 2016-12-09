using Microsoft.AspNetCore.Mvc;

namespace SolarSystem.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet]
        public dynamic Index()
        {
            return new { ok = true };
        }

    }
}
