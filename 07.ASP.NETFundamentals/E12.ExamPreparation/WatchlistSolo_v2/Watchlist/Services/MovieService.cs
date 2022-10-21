namespace Watchlist.Services
{
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Contracts;
    using Models.Movies;

    public class MovieService : IMovieService
    {
        private readonly WatchlistDbContext context;

        public MovieService(WatchlistDbContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<MovieViewModel>> GetAllAsync()
        {
            return await context.Movies
                .Select(m => new MovieViewModel()
                {
                    Id = m.Id,
                    Title = m.Title,
                    Director = m.Director,
                    ImageUrl = m.ImageUrl,
                    Rating = m.Rating,
                    Genre = m.Genre.Name
                }).ToListAsync();
        }
    }
}
