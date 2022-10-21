namespace Watchlist.Contracts
{
    using Models.Movies;

    public interface IMovieService
    {
        Task<IEnumerable<MovieViewModel>> GetAllAsync();

        Task<IEnumerable<MovieViewModel>> GetWatchedAsync(string userId);
    }
}
