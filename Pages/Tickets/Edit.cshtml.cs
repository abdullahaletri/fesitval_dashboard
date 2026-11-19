using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using fesitval_dashboard.Data;
using fesitval_dashboard.Models;

namespace fesitval_dashboard.Pages.Tickets
{
    public class EditModel : PageModel
    {
        private readonly FestivalDbContext _context;

        public EditModel(FestivalDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Ticket Ticket { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets.FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            Ticket = ticket;
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

            _context.Attach(Ticket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketExists(Ticket.Id))
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

        private bool TicketExists(int id)
        {
            return _context.Tickets.Any(e => e.Id == id);
        }

        private void VulKeuzelijsten()
        {
            ViewData["FestivalId"] = new SelectList(_context.Fesitvals, "Id", "Naam");
            ViewData["TickettypeId"] = new SelectList(_context.Tickettypes, "Id", "Naam");
        }
    }
}
