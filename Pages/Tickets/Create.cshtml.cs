using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using fesitval_dashboard.Data;
using fesitval_dashboard.Models;

namespace fesitval_dashboard.Pages.Tickets
{
    public class CreateModel : PageModel
    {
        private readonly FestivalDbContext _context;

        public CreateModel(FestivalDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Ticket Ticket { get; set; } = default!;

        public IActionResult OnGet()
        {
            VulKeuzelijsten();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Ticket.Verkoopdatum.Date > DateTime.Today)
            {
                ModelState.AddModelError("Ticket.Verkoopdatum", "De verkoopdatum mag niet in de toekomst liggen.");
            }

            if (!ModelState.IsValid)
            {
                VulKeuzelijsten();
                return Page();
            }

            _context.Tickets.Add(Ticket);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private void VulKeuzelijsten()
        {
            ViewData["FestivalId"] = new SelectList(_context.Fesitvals, "Id", "Naam");
            ViewData["TickettypeId"] = new SelectList(_context.Tickettypes, "Id", "Naam");
        }
    }
}
