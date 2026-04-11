using ISYS366Assignment3.Data;
using ISYS366Assignment3.Models;

namespace ISYS366Assignment5.Data
{
    public class MovieRepoList : IMovieRepo
    {
        public IEnumerable<Movie> GetAll()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Title = "The Shawshank Redemption", ReleaseDate = new DateTime(1994, 9, 22), Genre = "Drama", Price = 9.99m, Rank = 1, ImageUri = "https://example.com/shawshank.jpg" },
                new Movie { Id = 2, Title = "The Godfather", ReleaseDate = new DateTime(1972, 3, 24), Genre = "Crime", Price = 8.99m, Rank = 2, ImageUri = "https://example.com/godfather.jpg" },
                new Movie { Id = 3, Title = "The Dark Knight", ReleaseDate = new DateTime(2008, 7, 18), Genre = "Action", Price = 10.99m, Rank = 3, ImageUri = "https://example.com/darkknight.jpg" }
            };
        }

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await Task.FromResult(GetAll());
        }

        public Movie? GetById(int id)
        {
            return GetAll().FirstOrDefault(m => m.Id == id);
        }

        public async Task<Movie?> GetByIdAsync(int id)
        {
            return await Task.FromResult(GetById(id));
        }

        public async Task AddAsync(Movie movie)
        {
            // This is a no-op for the list-based repository, as it doesn't persist data.
            await Task.CompletedTask;
        }

        public async Task RemoveAsync(Movie movie) 
        {
            // This is a no-op for the list-based repository, as it doesn't persist data.
            await Task.CompletedTask;
        }

        public async Task SaveChangesAsync()
        {
            // This is a no-op for the list-based repository, as it doesn't persist data.
            await Task.CompletedTask;
        }

        public Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<ISYS366Assignment3.Models.Movie> Attach(ISYS366Assignment3.Models.Movie movie)
        {
            // This is a no-op for the list-based repository, as it doesn't persist data.
            return null!;
        }
    }
}
