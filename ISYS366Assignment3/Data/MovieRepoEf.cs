using Microsoft.EntityFrameworkCore;

namespace ISYS366Assignment3.Data;

public class MovieRepoEf : IMovieRepo
{
    private readonly ISYS366Assignment3Context _context;

    public MovieRepoEf(ISYS366Assignment3Context context)
    {
        _context = context;
    }

    public IEnumerable<ISYS366Assignment3.Models.Movie> GetAll()
    {
        return _context.Movie.OrderBy(m => m.Rank).ThenBy(m => m.Title).ToList();
    }

    public async Task<IEnumerable<ISYS366Assignment3.Models.Movie>> GetAllAsync()
    {
        return await _context.Movie.OrderBy(m => m.Rank).ThenBy(m => m.Title).ToListAsync();
    }

    public ISYS366Assignment3.Models.Movie? GetById(int id)
    {
        return _context.Movie.FirstOrDefault(m => m.Id == id);
    }

    public async Task<ISYS366Assignment3.Models.Movie?> GetByIdAsync(int id)
    {
        return await _context.Movie.FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task AddAsync(ISYS366Assignment3.Models.Movie movie)
    {
        _context.Movie.Add(movie);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(ISYS366Assignment3.Models.Movie movie)
    {
        _context.Movie.Remove(movie);
        await _context.SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<ISYS366Assignment3.Models.Movie> Attach(ISYS366Assignment3.Models.Movie movie)
    {
        return _context.Movie.Attach(movie);
    }
}
