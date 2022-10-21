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

            try
            {
                var model = await movieService.GetWatchedAsync(userId);

                return View(model);
            }
            catch (ArgumentException ae)
            {
                TempData[nameof(ErrorMessages)] = ae.Message;

                return RedirectToAction(nameof(All));
            }

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

            await movieService.AddMovieAsync(model);

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> AddToCollection(int movieId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            try
            {
                await movieService.AddMovieToCollection(userId, movieId);

                return RedirectToAction(nameof(All));
            }
            catch (ArgumentException ae)
            {
                TempData[nameof(ErrorMessages)] = ae.Message;

                return RedirectToAction(nameof(All));
            }
        }

        public async Task<IActionResult> RemoveFromCollection(int movieId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            try
            {
                await movieService.RemoveMovieFromCollection(userId, movieId);

                return RedirectToAction(nameof(Watched));
            }
            catch (ArgumentException ae)
            {
                TempData[nameof(ErrorMessages)] = ae.Message;

                return RedirectToAction(nameof(Watched));
            }
        }
    }
}
