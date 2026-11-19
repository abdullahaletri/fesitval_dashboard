using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using fesitval_dashboard.Data;
using fesitval_dashboard.Models;

namespace fesitval_dashboard.Pages.Festival
{
    public class DetailsModel : PageModel
    {
        private readonly fesitval_dashboard.Data.FestivalDbContext _context;

        public DetailsModel(fesitval_dashboard.Data.FestivalDbContext context)
        {
            _context = context;
        }

        public Fesitval Fesitval { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fesitval = await _context.Fesitvals.FirstOrDefaultAsync(m => m.Id == id);

            if (fesitval is not null)
            {
                Fesitval = fesitval;

                return Page();
            }

            return NotFound();
        }
    }
}
