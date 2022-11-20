﻿namespace HouseRenting.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Models.Houses;
    using Infrastructure;
    using Services.Houses;
    using Services.Agents;

    public class HousesController : Controller
    {
        private readonly IHouseService houseService;
        private readonly IAgentService agentService;

        public HousesController(
            IHouseService _houseService,
            IAgentService _agentService)
        {
            houseService = _houseService;
            agentService = _agentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult All()
        {
            return View(new AllHousesQueryModel());
        }

        [Authorize]
        public IActionResult Mine()
        {
            return View(new AllHousesQueryModel());
        }

        public IActionResult Details(int id)
        {
            return View(new AllHousesQueryModel());
        }

        [Authorize]
        public IActionResult Add()
        {
            if (!this.agentService.ExistsById(this.User.Id()))
            {
                return RedirectToAction(nameof(AgentController.Become), "Agents");
            }

            return View(new HouseFormModel
            {
                Categories = this.houseService.AllCategories()
            });
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(HouseFormModel model)
        {
            return RedirectToAction(nameof(Details), new { id = "1" });
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            return View(new HouseFormModel());
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(int id, HouseFormModel model)
        {
            return RedirectToAction(nameof(Details), new { id = "1" });
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            return View(new HouseDetailsViewModel());
        }

        [HttpPost]
        [Authorize]
        public IActionResult Delete(HouseDetailsViewModel model)
        {
            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        [Authorize]
        public IActionResult Rent(int id)
        {
            return RedirectToAction(nameof(Mine));
        }

        [HttpPost]
        [Authorize]
        public IActionResult Leave(int id)
        {
            return RedirectToAction(nameof(Mine));
        }
    }
}
