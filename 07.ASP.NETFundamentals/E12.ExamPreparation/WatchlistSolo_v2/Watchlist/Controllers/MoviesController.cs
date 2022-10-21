namespace Watchlist.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Contracts;
    using Microsoft.AspNetCore.Authorization.Infrastructure;
    using System.Security.Claims;

    public class MoviesController : BaseController
    {
        private readonly IMovieService movieService;

        public MoviesController(IMovieService _movieService)
        {
            movieService = _movieService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await movieService.GetAllAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Watched()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var model = await movieService.GetWatchedAsync(userId);

            return View(model);
        }
    }
}
