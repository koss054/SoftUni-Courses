using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

using Watchlist.Data;
using Watchlist.Contracts;
using Watchlist.Models.Movies;
using Microsoft.AspNetCore.Mvc;
using Watchlist.Data.Enntities;

namespace Watchlist.Services
{
    [Authorize]
    public class MovieService : IMovieService
    {
        private readonly WatchlistDbContext db;

        public MovieService(WatchlistDbContext _db)
        {
            db = _db;
        }

        [HttpGet]
        public async Task<IEnumerable<MovieViewModel>> GetAllAsync()
        {
            var entity = await db.Movies
                .Include(m => m.Genre)
                .ToListAsync();

            return entity
                .Select(m => new MovieViewModel()
                {
                    Id = m.Id,
                    Title = m.Title,
                    Director = m.Director,
                    ImageUrl = m.ImageUrl,
                    Rating = m.Rating,
                    Genre = m?.Genre?.Name
                });
        }

        public async Task<IEnumerable<Genre>> GetGenresAsync()
        {
            return await db.Genres.ToListAsync();
        }

        public async Task AddMovieAsync(AddMovieViewModel model)
        {
            var entity = new Movie()
            {
                Title = model.Title,
                GenreId = model.GenreId,
                ImageUrl = model.ImageUrl,
                Rating = model.Rating,
                Director = model.Director
            };

            await db.Movies.AddAsync(entity);
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<MovieViewModel>> GetWatchedAsync(string userId)
        {
            var user = await db.Users
                .Where(u => u.Id == userId)
                .Include(u => u.UsersMovies)
                .ThenInclude(um => um.Movie)
                .ThenInclude(m => m.Genre)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            return user.UsersMovies
                .Select(um => new MovieViewModel()
                {
                    Director = um.Movie.Director,
                    Genre = um.Movie.Genre?.Name,
                    ImageUrl = um.Movie.ImageUrl,
                    Rating = um.Movie.Rating,
                    Title = um.Movie.Title,
                    Id = um.MovieId
                });
        }

        public async Task AddMovieToCollectionAsync(int movieId, string userId)
        {
            var user = await db.Users
                .Where(u => u.Id == userId)
                .Include(u => u.UsersMovies)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            var movie = await db.Movies.FirstOrDefaultAsync(m => m.Id == movieId);

            if (movie == null)
            {
                throw new ArgumentException("Invalud movie ID");
            }

            if (!user.UsersMovies.Any(m => m.MovieId == movieId))
            {
                user.UsersMovies.Add(new UserMovie()
                {
                    MovieId = movie.Id,
                    UserId = user.Id,
                    Movie = movie,
                    User = user
                });

                await db.SaveChangesAsync();
            }
        }

        public async Task RemoveMovieFromCollectionAsync(int movieId, string userId)
        {
            var user = await db.Users
                .Where(u => u.Id == userId)
                .Include(u => u.UsersMovies)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            var movie = user.UsersMovies.FirstOrDefault(um => um.MovieId == movieId);

            if (movie != null)
            {
                user.UsersMovies.Remove(movie);

                await db.SaveChangesAsync();
            }
        }
    }
}
