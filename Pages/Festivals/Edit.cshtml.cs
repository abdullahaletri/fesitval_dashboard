using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using fesitval_dashboard.Data;
using fesitval_dashboard.Models;

namespace fesitval_dashboard.Pages.Festival
{
    public class EditModel : PageModel
    {
        private readonly fesitval_dashboard.Data.FestivalDbContext _context;

        public EditModel(fesitval_dashboard.Data.FestivalDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Fesitval Fesitval { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fesitval =  await _context.Fesitvals.FirstOrDefaultAsync(m => m.Id == id);
            if (fesitval == null)
            {
                return NotFound();
            }
            Fesitval = fesitval;
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

            _context.Attach(Fesitval).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FesitvalExists(Fesitval.Id))
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

        private bool FesitvalExists(int id)
        {
            return _context.Fesitvals.Any(e => e.Id == id);
        }
    }
}
