using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ISYS366Assignment3.Data;
using ISYS366Assignment3.Models;

namespace ISYS366Assignment3.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly IMovieRepo _repo;

        public DetailsModel(IMovieRepo repo)
        {
            _repo = repo;
        }

        public Models.Movie MovieObject { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            MovieObject = await _repo.GetByIdAsync(id);
            return Page();
        }

    }
}
