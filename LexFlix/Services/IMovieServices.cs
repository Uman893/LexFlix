using LexFlix.Models;

namespace LexFlix.Services
{
    public interface IMovieServices
    {
        Task AddMovie(Movies movies);
        Task DeleteMovies(int id);
        Task DeleteConfirmed(int id);
        Task EditMovies(int id);
        Task EditMovies(Movies Model);
    }
}
