using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ISYS366Assignment3.Data;
using ISYS366Assignment3.Models;
using ISYS366Assignment4.Utils;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace ISYS366Assignment3.Pages.Movies
{
    public class EditModel : PageModel
    {
        private readonly IMovieRepo _repo;
        private readonly IWebHostEnvironment _env;

        public EditModel(IMovieRepo repo, IWebHostEnvironment env)
        {
            _repo = repo;
            _env = env;
        }

        [BindProperty]
        public Movie Movie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie =  await _repo.GetByIdAsync(id.Value);
            if (movie == null)
            {
                return NotFound();
            }
            Movie = movie;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // handle uploaded file (if any)
            var files = HttpContext.Request.Form.Files;
            if (files != null && files.Count > 0)
            {
                Movie.ImageUri = PictureHelper.UploadNewImage(_env, files[0]);
            }
            else
            {
                // preserve existing image uri when no new file uploaded
                var existing = await _repo.GetByIdAsync(Movie.Id);
                if (existing != null)
                {
                    Movie.ImageUri = existing.ImageUri;
                }
            }

            _repo.Attach(Movie).State = EntityState.Modified;

            try
            {
                await _repo.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await MovieExists(Movie.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private async Task<bool> MovieExists(int id)
        {
            var movie = await _repo.GetByIdAsync(id);
            return movie != null;
        }
    }
}
