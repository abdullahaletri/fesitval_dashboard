using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using fesitval_dashboard.Data;
using fesitval_dashboard.Models;

namespace fesitval_dashboard.Pages.Festival
{
    public class CreateModel : PageModel
    {
        private readonly fesitval_dashboard.Data.FestivalDbContext _context;

        public CreateModel(fesitval_dashboard.Data.FestivalDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Fesitval Fesitval { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Fesitvals.Add(Fesitval);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
