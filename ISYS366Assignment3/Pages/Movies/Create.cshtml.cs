using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ISYS366Assignment3.Data;
using ISYS366Assignment3.Models;
using ISYS366Assignment4.Utils;

namespace ISYS366Assignment3.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly ISYS366Assignment3.Data.ISYS366Assignment3Context _context;
        private readonly IWebHostEnvironment _env;

        public CreateModel(ISYS366Assignment3.Data.ISYS366Assignment3Context context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (HttpContext.Request.Form.Files.Count > 0)
            {
                Movie.ImageUri = PictureHelper.UploadNewImage(_env,
                    HttpContext.Request.Form.Files[0]);
            }

            _context.Movie.Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
