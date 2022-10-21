namespace Watchlist.Contracts
{
    using Models.Movies;

    public interface IMovieService
    {
        Task<IEnumerable<MovieViewModel>> GetAllAsync();
    }
}
