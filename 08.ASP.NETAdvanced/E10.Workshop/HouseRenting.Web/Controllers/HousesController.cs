﻿namespace HouseRenting.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using AutoMapper;

    using Models.Houses;
    using Infrastructure;
    using Services.Houses;
    using Services.Agents;
    using Services.Houses.Models;

    public class HousesController : Controller
    {
        private readonly IHouseService houseService;
        private readonly IAgentService agentService;
        private readonly IMapper mapper;

        public HousesController(
            IHouseService _houseService,
            IAgentService _agentService,
            IMapper _mapper)
        {
            houseService = _houseService;
            agentService = _agentService;
            mapper = _mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult All([FromQuery] AllHousesQueryModel query)
        {
            var queryResult = this.houseService.All(
                query.Category,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                AllHousesQueryModel.HousesPerPage);
            query.TotalHousesCount = queryResult.TotalHousesCount;
            query.Houses = queryResult.Houses;

            var houseCategories = this.houseService.AllCategories();
            //query.Categories = houseCategories;
            return View(query);
        }

        [Authorize]
        public IActionResult Mine()
        {
            IEnumerable<HouseServiceModel> myHouses = null;
            var userId = this.User.Id();

            if (this.agentService.ExistsById(userId))
            {
                var currentAgentId = this.agentService.GetAgentId(userId);
                myHouses = this.houseService.AllHousesByAgentId(currentAgentId);
            }
            else
            {
                myHouses = this.houseService.AllHousesByUserId(userId);
            }

            return View(myHouses);
        }

        public IActionResult Details(int id, string information)
        {
            if (!this.houseService.Exists(id))
            {
                return BadRequest();
            }

            var houseModel = this.houseService.HouseDetailsById(id);

            if (information != houseModel.GetInformation())
            {
                return BadRequest();
            }

            return View(houseModel);
        }

        [Authorize]
        public IActionResult Add()
        {
            if (!this.agentService.ExistsById(this.User.Id()))
            {
                return RedirectToAction(nameof(AgentsController.Become), "Agents");
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
            if (!ModelState.IsValid)
            {
                model.Categories = this.houseService.AllCategories();
                return View(model);
            }

            if (!this.agentService.ExistsById(this.User.Id()))
            {
                return RedirectToAction(nameof(AgentsController.Become), "Agents");
            }

            if (!this.houseService.CategoryExists(model.CategoryId))
            {
                this.ModelState.AddModelError(nameof(model.CategoryId),
                    "Category does not exist.");
            }

            var agentId = this.agentService.GetAgentId(this.User.Id());

            var newHouseId = this.houseService.Create(model.Title, model.Address,
                model.Description, model.ImageUrl, model.PricePerMonth,
                model.CategoryId, agentId);

            return RedirectToAction(nameof(Details), 
                new { id = newHouseId, information = model.GetInformation() });
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            if (!this.houseService.Exists(id))
            {
                return BadRequest();
            }

            if (!this.houseService.HasAgentWithId(id, this.User.Id()) &&
                !this.User.IsAdmin())
            {
                return Unauthorized();
            }

            var house = this.houseService.HouseDetailsById(id);
            var houseCategoryId = this.houseService.GetHouseCategoryId(house.Id);

            var houseModel = this.mapper.Map<HouseFormModel>(house);
            houseModel.CategoryId = houseCategoryId;
            houseModel.Categories = this.houseService.AllCategories();

            return View(houseModel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(int id, HouseFormModel model)
        {
            if (!this.houseService.Exists(id))
            {
                return this.View();
            }

            if (!this.houseService.HasAgentWithId(id, this.User.Id()) &&
                !this.User.IsAdmin())
            {
                return Unauthorized();
            }

            if (!this.houseService.CategoryExists(model.CategoryId))
            {
                this.ModelState.AddModelError(nameof(model.CategoryId),
                    "Category does not exist.");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = this.houseService.AllCategories();
                return View(model);
            }

            this.houseService.Edit(id, model.Title, model.Address, model.Description,
                model.ImageUrl, model.PricePerMonth, model.CategoryId);
            return RedirectToAction(nameof(Details), 
                new { id = id, information = model.GetInformation() });
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            if (!this.houseService.Exists(id))
            {
                return BadRequest();
            }

            if (!this.houseService.HasAgentWithId(id, this.User.Id()) &&
                !this.User.IsAdmin())
            {
                return Unauthorized();
            }

            var house = this.houseService.HouseDetailsById(id);
            var model = this.mapper.Map<HouseDetailsViewModel>(house);

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Delete(HouseDetailsViewModel model)
        {
            if (!this.houseService.Exists(model.Id))
            {
                return BadRequest();
            }

            if (!this.houseService.HasAgentWithId(model.Id, this.User.Id()) &&
                !this.User.IsAdmin())
            {
                return Unauthorized();
            }

            this.houseService.Delete(model.Id);
            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        [Authorize]
        public IActionResult Rent(int id)
        {
            if (!this.houseService.Exists(id))
            {
                return BadRequest();
            }

            if (this.agentService.ExistsById(this.User.Id()) &&
                !this.User.IsAdmin())
            {
                return Unauthorized(id);
            }

            if (this.houseService.IsRented(id))
            {
                return BadRequest();
            }

            this.houseService.Rent(id, this.User.Id());
            return RedirectToAction(nameof(Mine));
        }

        [HttpPost]
        [Authorize]
        public IActionResult Leave(int id)
        {
            if (!this.houseService.Exists(id) ||
                !this.houseService.IsRented(id))
            {
                return BadRequest();
            }

            if (!this.houseService.IsRentedByUserWithId(id, this.User?.Id()))
            {
                return Unauthorized();
            }

            this.houseService.Leave(id);
            return RedirectToAction(nameof(Mine));
        }
    }
}
