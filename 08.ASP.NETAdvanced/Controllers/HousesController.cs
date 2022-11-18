using Microsoft.AspNetCore.Mvc;

namespace HouseRenting.Controllers
{
    public class HousesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
