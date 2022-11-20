namespace HouseRenting.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Models.Agents;
    using Services.Agents;
    using Infrastructure;

    public class AgentController : Controller
    {
        private readonly IAgentService agentService;

        public AgentController(IAgentService _agentService)
        {
            agentService = _agentService;
        }

        [Authorize]
        public IActionResult Become()
        {
            if (this.agentService.ExistsById(this.User.Id()))
            {
                return BadRequest();
            }

            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Become(BecomeAgentFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = this.User.Id();
            if (this.agentService.ExistsById(userId))
            {
                return BadRequest();
            }
            
            if (this.agentService.UserWithPhoneNumberExists(model.PhoneNumber))
            {
                ModelState.AddModelError(nameof(model.PhoneNumber),
                    "Phone number already exists. Enter another one.");
            }

            if (this.agentService.UserHasRents(userId))
            {
                ModelState.AddModelError("Error",
                    "You should have no rents to become an agent.");
            }

            this.agentService.Create(userId, model.PhoneNumber);
            return RedirectToAction(nameof(HousesController.All), "Houses");
        }
    }
}
