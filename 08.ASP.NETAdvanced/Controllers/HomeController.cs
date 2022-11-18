namespace HouseRenting.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;

    using HouseRenting.Models;
    using HouseRenting.Models.Home;

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new IndexViewModel());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}