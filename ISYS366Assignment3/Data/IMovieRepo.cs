using ISYS366Assignment3.Models;

namespace ISYS366Assignment3.Data
{
    public interface IMovieRepo
    {
        IEnumerable<Movie> GetAll();
        Task<IEnumerable<Movie>> GetAllAsync();
        Movie? GetById(int id);
        Task<Movie?> GetByIdAsync(int id);
        Task AddAsync(Movie movie);
        Task RemoveAsync(Movie movie);
        Task SaveChangesAsync();
        Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Movie> Attach(Movie movie);
    }
}