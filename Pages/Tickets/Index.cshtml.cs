using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using fesitval_dashboard.Data;
using fesitval_dashboard.Models;

namespace fesitval_dashboard.Pages.Tickets
{
    public class IndexModel : PageModel
    {
        private readonly FestivalDbContext _context;

        public IndexModel(FestivalDbContext context)
        {
            _context = context;
        }

        public IList<Ticket> Ticket { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Ticket = await _context.Tickets
                .Include(t => t.Festival)
                .Include(t => t.Tickettype)
                .OrderByDescending(t => t.Verkoopdatum)
                .ToListAsync();
        }
    }
}
