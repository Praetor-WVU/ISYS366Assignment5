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
        private readonly ISYS366Assignment3.Data.ISYS366Assignment3Context _context;
        private readonly IWebHostEnvironment _env;

        public EditModel(ISYS366Assignment3.Data.ISYS366Assignment3Context context, IWebHostEnvironment env)
        {
            _context = context;
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

            var movie =  await _context.Movie.FirstOrDefaultAsync(m => m.Id == id);
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
                var existing = await _context.Movie.AsNoTracking().FirstOrDefaultAsync(m => m.Id == Movie.Id);
                if (existing != null)
                {
                    Movie.ImageUri = existing.ImageUri;
                }
            }

            _context.Attach(Movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(Movie.Id))
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

        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.Id == id);
        }
    }
}
