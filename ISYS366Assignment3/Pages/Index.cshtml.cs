using ISYS366Assignment3.Data;
using ISYS366Assignment3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISYS366Assignment3.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IMovieRepo _repo;

        public IndexModel(IMovieRepo repo)
        {
            _repo = repo;
        }

        public IList<Movie> Movies { get; set; } = default!;

        public async Task OnGetAsync()
        {
            // Load all movies sorted by Rank then Title
            Movies = (IList<Movie>)await _repo.GetAllAsync();
        }
    }
}
