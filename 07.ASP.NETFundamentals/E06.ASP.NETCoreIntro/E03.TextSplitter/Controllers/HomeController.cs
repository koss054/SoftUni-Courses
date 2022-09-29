namespace E03.TextSplitter.Controllers
{
    using System.Diagnostics;
    using System.Reflection.Metadata;
    using Microsoft.AspNetCore.Mvc;

    using Models;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //GET
        public IActionResult Index(TextViewModel model)
        {
            return View(model);
        }

        //POST
        [HttpPost]
        public IActionResult Split(TextViewModel model)
        {
            var splitTextArray = model.Text
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            model.SplitText = String.Join(Environment.NewLine, splitTextArray);

            return RedirectToAction("Index", model);
        }
    }
}