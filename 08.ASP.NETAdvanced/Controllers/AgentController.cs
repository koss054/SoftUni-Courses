using Microsoft.AspNetCore.Mvc;

namespace HouseRenting.Controllers
{
    public class AgentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
