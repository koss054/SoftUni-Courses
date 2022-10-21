namespace Watchlist.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Contracts;

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
    }
}
