namespace HouseRenting.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;

    using Models;
    using Models.Home;
    using Services.Houses;


    public class HomeController : Controller
    {
        private readonly IHouseService houseService;

        public HomeController(IHouseService _houseService)
        {
            houseService = _houseService;
        }

        public IActionResult Index()
        {
            var houses = houseService.LastThreeHouses();
            return View(houses);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}