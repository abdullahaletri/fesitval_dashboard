using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using fesitval_dashboard.Data;
using fesitval_dashboard.Models;

namespace fesitval_dashboard.Pages.Tickets
{
    public class DetailsModel : PageModel
    {
        private readonly FestivalDbContext _context;

        public DetailsModel(FestivalDbContext context)
        {
            _context = context;
        }

        public Ticket Ticket { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets
                .Include(t => t.Festival)
                .Include(t => t.Tickettype)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (ticket is null)
            {
                return NotFound();
            }

            Ticket = ticket;
            return Page();
        }
    }
}
