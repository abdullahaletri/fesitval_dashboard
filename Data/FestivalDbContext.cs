using System.Collections.Generic;
using fesitval_dashboard.Models;
using Microsoft.EntityFrameworkCore;

namespace fesitval_dashboard.Data
{ 
    public class FestivalDbContext : DbContext
    {
        public FestivalDbContext(DbContextOptions<FestivalDbContext> options)
            : base(options)
        {
        }
        public DbSet<Fesitval> Fesitvals { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Tickettype> Tickettypes { get; set; }


    }
}
