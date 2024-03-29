﻿namespace Watchlist.Contracts
{
    using Models.Movies;
    using Data.Entities;

    public interface IMovieService
    {
        // Get movies from the database.
        Task<IEnumerable<MovieViewModel>> GetAllAsync();

        Task<IEnumerable<MovieViewModel>> GetWatchedAsync(string userId);

        // Add movies to the database.
        Task AddMovieAsync(AddMovieViewModel model);

        // Add movies to watched.
        Task AddMovieToCollection(string userId, int movieId);

        // Remove movies from watched.
        Task RemoveMovieFromCollection(string userId, int movieId);

        // Get genres for adding movies.
        Task<IEnumerable<Genre>> GetGenresAsync();
    }
}
