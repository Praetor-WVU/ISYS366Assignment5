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
        private readonly ISYS366Assignment3Context _context;

        public IndexModel(ISYS366Assignment3Context context)
        {
            _context = context;
        }

        public IList<Movie> Movies { get; set; } = default!;

        public async Task OnGetAsync()
        {
            // Load all movies sorted by Rank then Title
            Movies = await _context.Movie
                .OrderBy(m => m.Rank)
                .ThenBy(m => m.Title)
                .ToListAsync();
        }
    }
}
