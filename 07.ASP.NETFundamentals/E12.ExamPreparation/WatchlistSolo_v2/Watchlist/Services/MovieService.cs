namespace Watchlist.Services
{
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Data.Constants;
    using Data.Entities;
    using Contracts;
    using Models.Movies;

    public class MovieService : IMovieService
    {
        private readonly WatchlistDbContext context;

        public MovieService(WatchlistDbContext _context)
        {
            context = _context;
        }

        // Get movies from the database.
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

        public async Task<IEnumerable<MovieViewModel>> GetWatchedAsync(string userId)
        {
            var user = await context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.UsersMovies)
                .ThenInclude(um => um.Movie)
                .ThenInclude(m => m.Genre)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException(ErrorMessages.InvalidUserId);
            }

            return user.UsersMovies
                .Select(um => new MovieViewModel()
                {
                    Id = um.Movie.Id,
                    Title = um.Movie.Title,
                    Director = um.Movie.Director,
                    ImageUrl = um.Movie.ImageUrl,
                    Rating = um.Movie.Rating,
                    Genre = um.Movie.Genre.Name
                });
        }

        // Add movies to the database.
        public async Task AddMovieAsync(AddMovieViewModel model)
        {
            var entity = new Movie()
            {
                Title = model.Title,
                Director = model.Director,
                ImageUrl = model.ImageUrl,
                Rating = model.Rating,
                GenreId = model.GenreId
            };

            await context.Movies.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        // Add movies to watched.
        public async Task AddMovieToCollection(string userId, int movieId)
        {
            var user = await context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.UsersMovies)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException(ErrorMessages.InvalidUserId);
            }

            var movie = await context.Movies
                .FirstOrDefaultAsync(m => m.Id == movieId);

            if (movie == null)
            {
                throw new ArgumentException(ErrorMessages.InvalidMovieId);
            }

            if (!user.UsersMovies.Any(um => um.MovieId == movieId))
            {
                user.UsersMovies.Add(new UserMovie()
                {
                    UserId = userId,
                    User = user,
                    MovieId = movieId,
                    Movie = movie
                });

                await context.SaveChangesAsync();
            }
        }

        // Remove movies from watched.
        public async Task RemoveMovieFromCollection(string userId, int movieId)
        {
            var user = await context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.UsersMovies)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException(ErrorMessages.InvalidUserId);
            }

            var movie = user.UsersMovies
                .FirstOrDefault(um => um.MovieId == movieId);

            if (movie == null)
            {
                throw new ArgumentException(ErrorMessages.InvalidMovieId);
            }

            context.Remove(movie);
            await context.SaveChangesAsync();
        }

        // Gets genres for movies.
        public async Task<IEnumerable<Genre>> GetGenresAsync()
        {
            return await context.Genres.ToListAsync();
        }
    }
}
