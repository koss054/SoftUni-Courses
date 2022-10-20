namespace Watchlist.Controllers
{
    using System.Security.Claims;

    using Microsoft.AspNetCore.Mvc;

    using Contracts;
    using Models.Movies;
    using Data.Constants;

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

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddMovieViewModel()
            {
                Genres = await movieService.GetGenresAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddMovieViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await movieService.AddMovieAsync(model);

                return RedirectToAction("All");
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, ErrorMessages.SomethingWentWrong);

                return View(model);
            }
        }

        public async Task<IActionResult> AddToCollection(int movieId)
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                await movieService.AddMovieToCollectionAsync(userId, movieId);
            }
            catch (ArgumentException ae)
            {
                ModelState.AddModelError(string.Empty, ae.Message);
            }

            return RedirectToAction("All");
        }

        public async Task<IActionResult> RemoveFromCollection(int movieId)
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                await movieService.RemoveMovieFromCollectionAsync(userId, movieId);
            }
            catch (ArgumentException ae)
            {
                ModelState.AddModelError(string.Empty, ae.Message);
            }

            return RedirectToAction("Watched");
        }
    }
}
