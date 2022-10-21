﻿namespace Watchlist.Services
{
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Data.Constants;
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

        public async Task<IEnumerable<MovieViewModel>> GetWatchedAsync(string userId)
        {
            var user = await context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.UsersMovies)
                .ThenInclude(um => um.Movie)
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
                }).ToList();
        }
    }
}
