using ISYS366Assignment3.Data;
using ISYS366Assignment3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISYS366Assignment3.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly IMovieRepo _repo;

        public IndexModel(IMovieRepo repo)
        {
            _repo = repo;
        }

        public IList<Movie> Movie { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? MovieGenre { get; set; }

        public async Task OnGetAsync()
        {
            // await a materialized collection then run LINQ-to-Objects
            var all = await _repo.GetAllAsync();
            var genres = all.Select(m => m.Genre).Distinct().OrderBy(g => g).ToList();
            Genres = new SelectList(genres);
            Movie = all.Where(m => 
                (string.IsNullOrEmpty(SearchString) || m.Title.Contains(SearchString)) && 
                (string.IsNullOrEmpty(MovieGenre) || m.Genre == MovieGenre))
                .OrderBy(m => m.Rank)
                .ToList();
        }
    }
}
