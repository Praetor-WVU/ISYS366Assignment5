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
    public class DeleteModel : PageModel
    {
        private readonly IMovieRepo _repo;

        public DeleteModel(IMovieRepo repo)
        {
            _repo = repo;
        }

        [BindProperty]
        public Movie Movie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _repo.GetByIdAsync(id.Value);

            if (movie is not null)
            {
                Movie = movie;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _repo.GetByIdAsync(id.Value);
            if (movie != null)
            {
                Movie = movie;
                await _repo.RemoveAsync(Movie);
            }

            return RedirectToPage("./Index");
        }
    }
}
