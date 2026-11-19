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
    public class IndexModel : PageModel
    {
        private readonly fesitval_dashboard.Data.FestivalDbContext _context;

        public IndexModel(fesitval_dashboard.Data.FestivalDbContext context)
        {
            _context = context;
        }

        public IList<Fesitval> Fesitval { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Fesitval = await _context.Fesitvals.ToListAsync();
        }
    }
}
