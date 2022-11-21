namespace HouseRenting.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Models.Houses;
    using Infrastructure;
    using Services.Houses;
    using Services.Agents;
    using Services.Houses.Models;

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

        public IActionResult Details(int id)
        {
            return View(new AllHousesQueryModel());
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
