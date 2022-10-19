using Watchlist.Models.Movies;
using Watchlist.Data.Enntities;

namespace Watchlist.Contracts
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieViewModel>> GetAllAsync();

        Task<IEnumerable<Genre>> GetGenresAsync();

        Task AddMovieAsync(AddMovieViewModel model);

        Task<IEnumerable<MovieViewModel>> GetWatchedAsync(string userId);

        Task AddMovieToCollectionAsync(int movieId, string userId);

        Task RemoveMovieFromCollectionAsync(int movieId, string userId);
    }
}
