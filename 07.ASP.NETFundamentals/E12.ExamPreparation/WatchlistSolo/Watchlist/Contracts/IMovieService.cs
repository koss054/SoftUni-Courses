namespace Watchlist.Contracts
{
    using Models.Movies;
    using Data.Entities;

    public interface IMovieService
    {
        Task<IEnumerable<MovieViewModel>> GetAllAsync();

        Task<IEnumerable<MovieViewModel>> GetWatchedAsync(string userId);

        Task<IEnumerable<Genre>> GetGenresAsync();

        Task AddMovieAsync(AddMovieViewModel model);

        Task AddMovieToCollectionAsync(string userId, int movieId);

        Task RemoveMovieFromCollectionAsync(string userId, int movieId);
    }
}
