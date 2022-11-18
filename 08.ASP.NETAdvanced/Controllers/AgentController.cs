namespace HouseRenting.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Models.Agents;

    public class AgentController : Controller
    {
        [Authorize]
        public IActionResult Become()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Become(BecomeAgentFormModel model)
        {
            return RedirectToAction(nameof(HousesController.All), "Houses");
        }
    }
}
